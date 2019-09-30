using Baidu.YingYan.Entity;

namespace Baidu.YingYan.Track
{
    /// <summary>
    /// 实时纠偏结果
    /// </summary>
    /// <seealso cref="CommonResult" />
    public class TrackHistoryGetLatestPointResult : CommonResult
    {
        /// <summary>
        ///实时位置信息
        /// </summary>
        public EntityLocationPoint LatestPoint { get; set; }

        /// <summary>
        /// 道路限速,单位：km/h
        /// </summary>
        public double LimitSpeed { get; set; }
    }
}