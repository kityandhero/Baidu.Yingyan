using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Baidu.YingYan.Extensions;

namespace Baidu.YingYan.Track
{
    /// <summary>
    /// 为 entity 上传轨迹点，支持为一个 entity上传一个或多个轨迹点，也支持为多个 entity 上传多个轨迹点。
    /// 轨迹纠偏类接口为开发者提供轨迹去噪、抽稀、绑路功能，包括实时位置纠偏、轨迹纠偏、里程计算功能。 <a
    /// href="http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/trackupload">轨迹上传</a><a
    /// href="http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/trackprocess">轨迹查询和纠偏</a>
    /// </summary>
    public class TrackApi
    {
        private readonly YingYanApi _framework;
        private const string Url = "track/";

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackApi" /> class.
        /// </summary>
        /// <param name="framework">The framework.</param>
        public TrackApi(YingYanApi framework)
        {
            _framework = framework;
        }

        #region 上传轨迹点

        /// <summary>
        /// 为一个track添加最新轨迹点。
        /// </summary>
        /// <param name="point">坐标</param>
        /// <returns></returns>
        public async Task<CommonResult> AddPoint(TrackPoint point)
        {
            var args = _framework.GetDefaultArgs(point?.Columns?.ToDictionary(o => o.Key, o => o.Value?.ToString()));

            if (point != null)
            {
                args["entity_name"] = point.EntityName;
                args["latitude"] = point.Latitude.ToString(CultureInfo.InvariantCulture);
                args["longitude"] = point.Longitude.ToString(CultureInfo.InvariantCulture);
                args["loc_time"] = point.LocTime.ToUtcTicks().ToString();
                args["coord_type_input"] = point.CoordTypeInput.ToString();
                if (point.Speed > 0)
                    args["speed"] = point.Speed.ToString();
                if (point.Direction > 0)
                    args["direction"] = point.Direction.ToString();
                if (point.Height > 0)
                    args["height"] = point.Height.ToString();
                if (point.Radius > 0)
                    args["radius"] = point.Radius.ToString();
                if (string.IsNullOrWhiteSpace(point.ObjectName) == false)
                    args["object_name"] = point.ObjectName;
            }

            return await _framework.Post<CommonResult>(Url + "addpoint", args);
        }

        /// <summary>
        /// 对于一个track批量上传轨迹点。按照时间顺序保留最后一个点作为实时点，过程耗时等信息。
        /// </summary>
        /// <param name="points">坐标，轨迹点总数不超过100个，json 格式。轨迹点字段描述参见</param>
        /// <returns></returns>
        public async Task<BatchAddPointResult> AddPoints(TrackPoint[] points)
        {
            var args = _framework.GetDefaultArgs();

            if (points?.Any() == true)
                args["point_list"] = Newtonsoft.Json.JsonConvert.SerializeObject(points);

            return await _framework.Post<BatchAddPointResult>(Url + "addpoints", args);
        }

        #endregion 上传轨迹点

        #region 轨迹纠偏

        /// <summary>
        /// 查询某 entity 的实时位置，支持纠偏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<TrackHistoryGetLatestPointResult> GetLatestPoint(TrackHistoryGetLatestPointParam param)
        {
            return _framework.Get<TrackHistoryGetLatestPointResult>(Url + "getlatestpoint", param);
        }

        /// <summary>
        /// 查询某 entity 一段时间内的轨迹里程，支持纠偏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<TrackHistoryGetDistanceResult> GetDistance(TrackHistoryGetDistanceParam param)
        {
            return _framework.Get<TrackHistoryGetDistanceResult>(Url + "getdistance", param);
        }

        /// <summary>
        /// 查询某 entity 一段时间内的轨迹点，支持纠偏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<TrackHistoryGetTrackResult> GetTrack(TrackHistoryGetTrackParam param)
        {
            return _framework.Get<TrackHistoryGetTrackResult>(Url + "gettrack", param);
        }

        #endregion 轨迹纠偏
    }
}