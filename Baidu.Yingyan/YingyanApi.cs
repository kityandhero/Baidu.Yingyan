using Baidu.YingYan.Analysis;
using Baidu.YingYan.Entity;
using Baidu.YingYan.Export;
using Baidu.YingYan.Fence;
using Baidu.YingYan.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Baidu.YingYan.Extensions;

namespace Baidu.YingYan
{
    /// <summary>
    /// 鹰眼轨迹服务接口
    /// </summary>
    public class YingYanApi
    {
        /// <summary>
        /// 用户的ak
        /// </summary>
        public string Ak { get; private set; }

        /// <summary>
        /// service的ID，service 的唯一标识。
        /// </summary>
        public string ServiceId { get; private set; }

        /// <summary>
        /// sn签名的验证方式的 Security Key
        /// </summary>
        public string Sk { get; private set; }

        /// <summary>
        /// 终端管理/实时位置搜索
        /// </summary>
        public EntityApi Entity { get; private set; }

        /// <summary>
        /// 轨迹上传/轨迹查询和纠偏
        /// </summary>
        public TrackApi Track { get; private set; }

        /// <summary>
        /// 轨迹分析
        /// </summary>
        public AnalysisApi Analysis { get; private set; }

        /// <summary>
        /// 地理围栏管理/报警
        /// </summary>
        public FenceApi Fence { get; private set; }

        /// <summary>
        /// 批量导出轨迹
        /// </summary>
        public ExportApi Export { get; private set; }

        /// <summary>
        /// 接口地址
        /// </summary>
        public const string Url = "http://yingyan.baidu.com/api/v3/";

        private readonly HttpClient _client;

        /// <summary>
        /// 鹰眼轨迹服务接口
        /// </summary>
        /// <param name="ak">用户的ak</param>
        /// <param name="serviceId">service的ID，service 的唯一标识</param>
        /// <param name="sk">sn签名的验证方式的 Security Key</param>
        public YingYanApi(string ak, string serviceId, string sk = null)
        {
            this.Ak = ak;
            ServiceId = serviceId;
            this.Sk = sk;
            _client = new HttpClient();
            Entity = new EntityApi(this);
            Track = new TrackApi(this);
            Fence = new FenceApi(this);
            Analysis = new AnalysisApi(this);
            Export = new ExportApi(this);
            _client = new HttpClient { BaseAddress = new Uri(Url) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// GET 操作
        /// </summary>
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="requestUri">方法</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        internal Task<TResult> Get<TResult>(string requestUri, Dictionary<string, string> param)
            where TResult : CommonResult, new()
        {
            return Get<TResult>(requestUri, new DictionaryYingYanParam(param));
        }

        /// <summary>
        /// GET 操作
        /// </summary>
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="requestUri">方法</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        internal async Task<TResult> Get<TResult>(string requestUri, IYingYanParam param = null)
        where TResult : CommonResult, new()
        {
            var args = GetDefaultArgs();
            if (param != null)
                args = param.FillArgs(args);

            CalcSn(requestUri, args);

            if (args?.Count > 0)
            {
                var q = args.ToUriQuery();
                if (string.IsNullOrEmpty(requestUri))
                    requestUri = "?" + q;
                else if (requestUri.IndexOf('?') >= 0)
                {
                    requestUri += "&" + q;
                }
                else
                    requestUri += "?" + q;
            }

            var response = await _client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
                return await response.Content.JsonReadAsAsync<TResult>();

            var r = new TResult();
            r.Status = StatusCodeEnums.error999;
            r.Message = $"http 请求错误：StatusCode={response.StatusCode}, ReasonPhrase={response.ReasonPhrase}";
            return r;
        }

        /// <summary>
        /// GET 操作
        /// </summary>
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="requestUri">方法</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        internal Task<TResult> Post<TResult>(string requestUri, Dictionary<string, string> param)
            where TResult : CommonResult, new()
        {
            return Post<TResult>(requestUri, new DictionaryYingYanParam(param));
        }

        /// <summary>
        /// GET 操作
        /// </summary>
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="requestUri">方法</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        internal async Task<TResult> Post<TResult>(string requestUri, IYingYanParam param = null)
        where TResult : CommonResult, new()
        {
            var args = GetDefaultArgs();
            if (param != null)
                args = param.FillArgs(args);

            CalcSn(requestUri, args, true);

            var content = new FormUrlEncodedContent(args);

            var response = await _client.PostAsync(requestUri, content);
            if (response.IsSuccessStatusCode)
                return await response.Content.JsonReadAsAsync<TResult>();
            var r = new TResult();
            r.Status = StatusCodeEnums.error999;
            r.Message = $"http 请求错误：StatusCode={response.StatusCode}, ReasonPhrase={response.ReasonPhrase}";
            return r;
        }

        /// <summary>
        /// 构造参数
        /// </summary>
        /// <param name="otherValues">The other values.</param>
        /// <returns></returns>
        internal Dictionary<string, string> GetDefaultArgs(Dictionary<string, string> otherValues = null)
        {
            var args = new Dictionary<string, string>()
            {
                ["ak"] = Ak,
                ["service_id"] = ServiceId
            };

            if (otherValues?.Any() == true)
            {
                foreach (var kv in otherValues)
                    args[kv.Key] = kv.Value;
            }
            return args;
        }

        /// <summary>
        /// 计算sn
        /// </summary>
        /// <param name="requestUri">特殊的请求地址</param>
        /// <param name="args">请求参数</param>
        /// <param name="post">是Post或者是Get方式</param>
        private void CalcSn(string requestUri, IDictionary<string, string> args, bool post = false)
        {
            if (string.IsNullOrWhiteSpace(Sk))
                return;

            var uri = new Uri(new Uri(Url), requestUri);
            var requestPath = uri.AbsolutePath;

            //POST计算sn时，参数要排序
            var dic = post ? new SortedDictionary<string, string>(args) : args;

            var sn = BaiduSnCalculate.CalculateSn(Sk, requestPath, dic);
            args["sn"] = sn;
        }
    }
}