using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Baidu.YingYan.Entity
{
    /// <summary>
    /// 矩形范围搜索参数
    /// </summary>
    public abstract class EntityBoundSearchParam : EntityListWithOrderParam
    {
        /// <summary>
        /// 左下角
        /// </summary>
        [Required]
        public LocationPoint a { get; set; }

        /// <summary>
        /// 右上角
        /// </summary>
        [Required]
        public LocationPoint b { get; set; }

        /// <summary>
        /// 请求参数 bounds 的坐标类型
        /// </summary>
        public CoordTypeEnums CoordTypeInput { get; set; } = CoordTypeEnums.bd09Ll;

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public override Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            args = base.FillArgs(args);
            args["coord_type_input"] = CoordTypeInput.ToString();
            args["bounds"] = $"{Math.Min(a?.Latitude ?? 0, b?.Latitude ?? 0)},{Math.Min(a?.Longitude ?? 0, b?.Longitude ?? 0)};{Math.Max(a?.Latitude ?? 0, b?.Latitude ?? 0)},{Math.Max(a?.Longitude ?? 0, b?.Longitude ?? 0)}";

            return args;
        }
    }
}