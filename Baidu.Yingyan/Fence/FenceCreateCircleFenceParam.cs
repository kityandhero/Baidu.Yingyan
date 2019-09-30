using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 创建圆形围栏
    /// </summary>
    public class FenceCreateCircleFenceParam : FenceBaseData
    {
        /// <summary>
        /// 围栏类型
        /// </summary>
        public override FenceShapeEnums Shape => FenceShapeEnums.circle;

        /// <summary>
        /// 围栏圆心
        /// </summary>
        [Required]
        public LocationPoint Center { get; set; }

        /// <summary>
        /// 围栏半径 单位：米，取值范围(0,5000]
        /// </summary>
        [Required]
        public double Radius { get; set; }

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">原有参数</param>
        /// <returns>填充后的参数</returns>
        public override Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            args = base.FillArgs(args);
            args["longitude"] = Center?.Longitude.ToString(CultureInfo.InvariantCulture);
            args["latitude"] = Center?.Latitude.ToString(CultureInfo.InvariantCulture);
            if (Radius <= 0)
                Radius = 1;
            else if (Radius > 5000)
                Radius = 5000;
            args["radius"] = Radius.ToString(CultureInfo.InvariantCulture);
            return args;
        }
    }
}