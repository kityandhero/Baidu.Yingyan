using Baidu.YingYan.Converters;
using Newtonsoft.Json;

namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 删除围栏结果
    /// </summary>
    public class FenceListFenceResult : CommonResult
    {
        /// <summary>
        /// 满足条件并返回的围栏个数
        /// </summary>
        public int size { get; set; }

        /// <summary>
        /// 围栏列表
        /// </summary>
        [JsonConverter(typeof(FenceBaseInfoConverter))]
        public FenceBaseData[] Fences { get; set; }
    }
}