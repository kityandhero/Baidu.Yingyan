namespace Baidu.YingYan.Track
{
    /// <summary>
    /// 查询轨迹里程结果
    /// </summary>
    /// <seealso cref="CommonResult" />
    public class TrackHistoryGetDistanceResult : CommonResult
    {
        /// <summary>
        /// 轨迹里程
        /// </summary>
        public double distance { get; set; }
    }
}