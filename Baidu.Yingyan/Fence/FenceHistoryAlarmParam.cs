using System;
using System.Collections.Generic;
using Baidu.YingYan.Extensions;

namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 查询某监控对象的围栏报警信息
    /// </summary>
    /// <seealso cref="Baidu.YingYan.Fence.FenceQueryStatusParam" />
    public abstract class FenceHistoryAlarmParam : FenceQueryStatusParam
    {
        /// <summary>
        /// 开始时间, 若不填，则返回7天内所有报警信息
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间 若不填，则返回7天内所有报警信息
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 返回坐标类型
        /// </summary>
        public CoordTypeEnums CoordTypeOutput { get; set; } = CoordTypeEnums.bd09Ll;

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">原有参数</param>
        /// <returns>填充后的参数</returns>
        public override Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            args = base.FillArgs(args);
            if (StartTime != null)
                args["start_time"] = StartTime.Value.ToUtcTicks().ToString();
            if (EndTime != null)
                args["end_time"] = EndTime.Value.ToUtcTicks().ToString();
            args["coord_type_output"] = CoordTypeOutput.ToString();
            return args;
        }
    }
}