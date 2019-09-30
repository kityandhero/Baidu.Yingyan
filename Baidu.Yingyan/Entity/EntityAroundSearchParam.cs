using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Baidu.YingYan.Entity
{
    /// <summary>
    /// 周边搜索参数
    /// </summary>
    public abstract class EntityAroundSearchParam : EntityListWithOrderParam
    {
        /// <summary>
        /// 中心点经纬度,格式为：纬度,经度
        /// </summary>
        [Required]
        public LocationPoint Center { get; set; }

        /// <summary>
        /// 右上角,单位：米，取值范围[1,5000]
        /// </summary>
        [Required]
        public int Radius { get; set; } = 1000;

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
            args["center"] = $"{Center?.Latitude ?? 0},{Center?.Longitude ?? 0}";
            if (Radius < 1)
                Radius = 1;
            else if (Radius > 5000)
                Radius = 5000;
            args["radius"] = Radius.ToString();
            return args;
        }
    }
}