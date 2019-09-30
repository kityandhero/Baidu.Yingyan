using System;
using System.Collections.Generic;
using System.Linq;
using Baidu.YingYan.Extensions;

namespace Baidu.YingYan.Entity
{
    /// <summary>
    /// 查询entity参数
    /// </summary>
    public class EntityListParam : IYingYanParam
    {
        /// <summary>
        /// entity_name列表，多个entity用逗号分隔，精确筛选。示例："entity_names:张三,李四"
        /// </summary>
        public string[] EntityNames { get; set; }

        /// <summary>
        /// unix时间戳，查询在此时间之后有定位信息上传的entity（loc_time&gt;=active_time）。如查询2016-8-21
        /// 00:00:00之后仍活跃的entity，示例："active_time:1471708800"。active_time 和 inactive_time 不可同时输入
        /// </summary>
        public DateTime? ActiveTime { get; set; }

        /// <summary>
        /// inactive_time：unix时间戳，查询在此时间之后无定位信息上传的entity（loc_time &lt; inactive_time）。如查询2016-8-21
        /// 00:00:00之后不活跃的entity示例："inactive_time:1471708800"。active_time 和 inactive_time 不可同时输入
        /// </summary>
        public DateTime? InactiveTime { get; set; }

        /// <summary>
        /// 开发者自定义的可筛选的entity属性字段，示例："team:北京"
        /// </summary>
        public Dictionary<string, string> Columns { get; set; }

        /// <summary>
        /// 返回结果的坐标类型，默认值：bd09
        /// </summary>
        public CoordTypeEnums CoordTypeOutput { get; set; } = CoordTypeEnums.bd09Ll;

        /// <summary>
        /// 可选，默认值为1。page_index与page_size一起计算从第几条结果返回，代表返回第几页。
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 可选，默认值为100。最大值1000。page_size与page_index一起计算从第几条结果返回，代表返回结果中每页有几条记录。
        /// </summary>
        public int PageSize { get; set; } = 100;

        /// <summary>
        /// 过滤条件(filter)
        /// </summary>
        /// <returns></returns>
        public virtual string GetFilter()
        {
            var filters = new Dictionary<string, string>();
            if (EntityNames?.Any() == true)
                filters.Add("entity_names", string.Join(",", EntityNames));

            if (ActiveTime != null)
                filters.Add("active_time", ActiveTime.Value.ToUtcTicks().ToString());
            else if (InactiveTime != null)
                filters.Add("inactive_time", InactiveTime.Value.ToUtcTicks().ToString());

            if (Columns?.Any() == true)
            {
                foreach (var c in Columns)
                    filters[c.Key] = c.Value;
            }
            if (filters.Any())
                return string.Join("|", filters.Select(o => $"{o.Key}:{o.Value}"));
            else
                return null;
        }

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public virtual Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            if (args == null)
                args = new Dictionary<string, string>();
            var filter = GetFilter();
            if (string.IsNullOrWhiteSpace(filter) == false)
                args["filter"] = filter;

            args["coord_type_output"] = CoordTypeOutput.ToString();
            args["page_index"] = PageIndex.ToString();
            args["page_size"] = PageSize.ToString();

            return args;
        }
    }
}