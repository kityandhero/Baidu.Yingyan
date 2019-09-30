using Baidu.YingYan.Entity;
using System.Collections.Generic;

namespace Baidu.YingYan.Track
{
    /// <summary>
    /// 轨迹查询与纠偏结果
    /// </summary>
    /// <seealso cref="CommonResult" />
    public class TrackHistoryGetTrackResult : CommonResult
    {
        /// <summary>
        /// 忽略掉page_index，page_size后的轨迹点数量
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 返回的结果条数
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 此段轨迹的里程数，单位：米
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// 此段轨迹的收费里程数，单位：米
        /// </summary>
        public double TollDistance { get; set; }

        /// <summary>
        /// 起点信息
        /// </summary>
        public LocationPointWithTime StartPoint { get; set; }

        /// <summary>
        /// 终点信息
        /// </summary>
        public LocationPointWithTime EndPoint { get; set; }

        /// <summary>
        /// 历史轨迹点列表
        /// </summary>
        public List<EntityLocationPoint> Points { get; set; }
    }
}