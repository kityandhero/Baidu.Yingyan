namespace Baidu.YingYan.Entity
{
    /// <summary>
    /// entity 搜索类接口通用返回结果
    /// </summary>
    /// <seealso cref="CommonResult" />
    public class EntityListResult : CommonResult
    {
        /// <summary>
        /// 本页返回的结果条数
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 本次检索总结果条数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// entity详细信息列表
        /// </summary>
        public EntityItem[] Entities { get; set; }
    }
}