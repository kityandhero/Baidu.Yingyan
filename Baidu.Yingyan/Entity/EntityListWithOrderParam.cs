using System.Collections.Generic;

namespace Baidu.YingYan.Entity
{
    /// <summary>
    /// 搜索参数
    /// </summary>
    public class EntityListWithOrderParam : EntityListParam
    {
        /// <summary>
        /// 默认值：entity_name:asc（按 entity_name 升序排序） 只支持按一个字段排序，支持的排序字段如下： loc_time：entity 最新定位时间
        /// entity_name：entity 唯一标识 entity_desc：entity描述信息 custom-key：开发者自定义的 entity 属性字段
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// 排序方向
        /// </summary>
        public bool Asc { get; set; } = true;

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public override Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            args = base.FillArgs(args);

            if (string.IsNullOrWhiteSpace(SortBy) == false)
            {
                var aa = Asc ? "asc" : "desc";
                args["sortby"] = $"{SortBy.Trim()}:{aa}";
            }

            return args;
        }
    }
}