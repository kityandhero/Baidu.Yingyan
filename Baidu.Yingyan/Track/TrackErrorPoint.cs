namespace Baidu.YingYan.Track
{
    /// <summary>
    /// 批量添加的错误点
    /// </summary>
    /// <seealso cref="Baidu.YingYan.Track.TrackPoint" />
    public abstract class TrackErrorPoint : TrackPoint
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string error { get; set; }
    }
}