namespace Baidu.YingYan.Entity
{
    /// <summary>
    /// 行政区搜索结果
    /// </summary>
    /// <seealso cref="EntityListResult" />
    public class EntityDistrictSearchResult : EntityListResult
    {
        /// <summary>
        /// 关键字匹配的行政区划列表
        /// </summary>
        public string[] DistrictList { get; set; }
    }
}