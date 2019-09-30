namespace Baidu.YingYan.Track
{
    /// <summary>
    /// 批量添加点返回结果
    /// </summary>
    /// <seealso cref="CommonResult" />
    public class BatchAddPointResult : CommonResult
    {
        /// <summary>
        /// 上传成功的点个数
        /// </summary>
        public int SuccessNum { get; set; }

        /// <summary>
        /// 上传失败的点信息
        /// </summary>
        public BatchAddPointFailInfo FailInfo { get; set; }
    }

    /// <summary>
    /// 上传失败的点信息
    /// </summary>
    public abstract class BatchAddPointFailInfo
    {
        /// <summary>
        /// 输入参数不正确导致的上传失败的点
        /// </summary>
        public TrackErrorPoint[] ParamError { get; set; }

        /// <summary>
        /// 服务器内部错误导致上传失败的点
        /// </summary>
        public TrackErrorPoint[] InternalError { get; set; }
    }
}