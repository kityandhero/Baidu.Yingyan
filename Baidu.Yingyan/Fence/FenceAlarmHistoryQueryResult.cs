namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 围栏报警记录查询结果
    /// </summary>
    /// <seealso cref="CommonResult" />
    public class FenceAlarmHistoryQueryResult : CommonResult
    {
        /// <summary>
        /// 返回结果的数量
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 报警的数量
        /// </summary>
        public FenceAlarmHistory[] Alarms { get; set; }
    }
}