namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 围栏状态查询
    /// </summary>
    /// <seealso cref="CommonResult" />
    public class FenceQueryStatusResult : CommonResult
    {
        /// <summary>
        /// 返回结果的数量
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 报警的数量
        /// </summary>
        public FenceAlarmMonitoredStatus[] MonitoredStatuses { get; set; }
    }

    /// <summary>
    /// 围栏状态
    /// </summary>
    public abstract class FenceAlarmMonitoredStatus
    {
        /// <summary>
        /// 围栏 id
        /// </summary>
        public int FenceId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public FenceAlarmMonitoredStatusEnums MonitoredStatus { get; set; }
    }

    /// <summary>
    /// 围栏状态
    /// </summary>
    public enum FenceAlarmMonitoredStatusEnums
    {
        /// <summary>
        /// 未知状态
        /// </summary>
        unknown,

        /// <summary>
        /// 在围栏内
        /// </summary>
        inFrance,

        /// <summary>
        /// 在围栏外
        /// </summary>
        outFrance,
    }
}