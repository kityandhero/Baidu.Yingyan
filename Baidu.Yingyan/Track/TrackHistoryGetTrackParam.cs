using System.Collections.Generic;

namespace Baidu.YingYan.Track
{
    /// <summary>
    /// 轨迹查询与纠偏参数
    /// </summary>
    /// <seealso cref="Baidu.YingYan.Track.TrackHistoryGetDistanceParam" />
    public abstract class TrackHistoryGetTrackParam : TrackHistoryGetDistanceParam
    {
        /// <summary>
        /// 返回轨迹点的排序规则
        /// </summary>
        public bool asc { get; set; } = true;

        /// <summary>
        /// 可选，默认值为1。page_index与page_size一起计算从第几条结果返回，代表返回第几页。
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 可选，默认值为100。最大值5000。page_size与page_index一起计算从第几条结果返回，代表返回结果中每页有几条记录。
        /// </summary>
        public int PageSize { get; set; } = 100;

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public override Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            args = base.FillArgs(args);
            args["sort_type"] = asc ? "asc" : "desc";
            args["page_index"] = PageIndex.ToString();
            args["page_size"] = PageSize.ToString();
            return args;
        }
    }
}