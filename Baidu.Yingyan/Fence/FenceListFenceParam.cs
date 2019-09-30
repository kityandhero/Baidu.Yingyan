using System.Collections.Generic;

namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 查询围栏参数
    /// </summary>
    public abstract class FenceListFenceParam : FenceDeleteFenceParam
    {
        /// <summary>
        /// 输出坐标类型
        /// </summary>
        public CoordTypeEnums CoordTypeOutput { get; set; } = CoordTypeEnums.bd09Ll;

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">原有参数</param>
        /// <returns>填充后的参数</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            args = base.FillArgs(args);
            args["coord_type_output"] = CoordTypeOutput.ToString();
            return args;
        }
    }
}