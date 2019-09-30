using System.Collections.Generic;
using System.Linq;

namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 删除围栏参数
    /// </summary>
    public class FenceDeleteFenceParam : IYingYanParam
    {
        /// <summary>
        /// 监控对象 1、仅填写monitored_person字段：根据监控对象删除围栏，仅适用于删除“指定entity创建的围栏”，并删除该entity上的所有围栏（兼容旧版本）。
        /// 2、仅填写fence_ids字段：根据围栏id删除（针对该service下所有entity创建的围栏，使用此方法删除） 3、二字段均填写：根据该监控对象上的指定围栏删除
        /// </summary>
        public string MonitoredPerson { get; set; }

        /// <summary>
        /// 围栏id列表 1、仅填写monitored_person字段：根据监控对象删除围栏，仅适用于删除“指定entity创建的围栏”，并删除该entity上的所有围栏（兼容旧版本）。
        /// 2、仅填写fence_ids字段：根据围栏id删除（针对该service下所有entity创建的围栏，使用此方法删除） 3、二字段均填写：根据该监控对象上的指定围栏删除
        /// </summary>
        public int[] FenceIds { get; set; }

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">原有参数</param>
        /// <returns>填充后的参数</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            if (args == null)
                args = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(MonitoredPerson) == false)
                args["monitored_person"] = MonitoredPerson;
            if (FenceIds?.Any() == true)
            {
                args["fence_ids"] = string.Join(",", FenceIds);
            }
            return args;
        }
    }
}