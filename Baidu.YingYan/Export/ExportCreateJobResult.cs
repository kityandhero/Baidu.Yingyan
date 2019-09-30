namespace Baidu.YingYan.Export
{
    /// <summary>
    /// 停留点分析结果
    /// </summary>
    /// <seealso cref="CommonResult" />
    public class ExportCreateJobResult : CommonResult
    {
        /// <summary>
        /// 任务id，每个任务的唯一标识
        /// </summary>
        public int JobId { get; set; }
    }
}