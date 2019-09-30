using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 围栏报警查询参数
    /// </summary>
    /// <seealso cref="IYingYanParam" />
    public class FenceQueryStatusParam : IYingYanParam
    {
        /// <summary>
        /// 监控对象
        /// </summary>
        [Required]
        public string MonitoredPerson { get; set; }

        /// <summary>
        /// 围栏实体的id列表
        /// </summary>
        public int[] FenceIds { get; set; }

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">原有参数</param>
        /// <returns>填充后的参数</returns>
        public virtual Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            if (args == null)
                args = new Dictionary<string, string>();
            if (FenceIds?.Any() == true)
                args["fence_ids"] = string.Join(",", FenceIds);
            args["monitored_person"] = MonitoredPerson;
            return args;
        }
    }
}