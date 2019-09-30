using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 查询围栏监控的所有entity参数
    /// </summary>
    /// <seealso cref="IYingYanParam" />
    public abstract class FenceMonitoredPersonQueryParam : IYingYanParam
    {
        /// <summary>
        /// 围栏的唯一标识
        /// </summary>
        [Required]
        public int FenceId { get; set; }

        /// <summary>
        /// 可选，默认值为1。page_index与page_size一起计算从第几条结果返回，代表返回第几页。
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 可选，默认值为100。最大值1000。page_size与page_index一起计算从第几条结果返回，代表返回结果中每页有几条记录。
        /// </summary>
        public int PageSize { get; set; } = 100;

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">原有参数</param>
        /// <returns>填充后的参数</returns>
        public virtual Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            if (args == null)
                args = new Dictionary<string, string>();
            args["fence_id"] = FenceId.ToString();

            args["page_index"] = PageIndex.ToString();
            args["page_size"] = PageSize.ToString();

            return args;
        }
    }
}