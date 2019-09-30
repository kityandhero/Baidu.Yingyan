using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Baidu.YingYan.Entity
{
    /// <summary>
    /// 多边形搜索参数
    /// </summary>
    public abstract class EntityPolygonSearchParam : EntityListWithOrderParam
    {
        /// <summary>
        /// 中心点经纬度,格式为：纬度,经度 经纬度顺序为：纬度,经度； 顶点顺序可按顺时针或逆时针排列。 多边形外接矩形面积不超过3000平方公里
        /// </summary>
        [Required]
        public List<LocationPoint> Vertexes { get; set; }

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
            if (Vertexes?.Any() == true)
            {
                args["vertexes"] = string.Join(";", Vertexes.Select(o => $"{o?.Latitude ?? 0},{o?.Longitude ?? 0}"));
            }
            return args;
        }
    }
}