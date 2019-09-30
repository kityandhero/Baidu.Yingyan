using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Baidu.YingYan.Extensions;

namespace Baidu.YingYan.Export
{
    /// <summary>
    /// 创建任务
    /// </summary>
    public abstract class ExportCreateJobParam : IYingYanParam
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间 注：结束时间需比当前最新时间小12小时（即只能下载12小时以前的轨迹），且结束时间和起始时间差在24小时之内（即一次只能下载24小时区间内的轨迹）。
        /// </summary>
        [Required]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 返回的坐标类型
        /// </summary>
        public CoordTypeEnums CoordTypeOutput { get; set; } = CoordTypeEnums.bd09Ll;

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public virtual Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            if (args == null)
                args = new Dictionary<string, string>();
            args["start_time"] = StartTime.ToUtcTicks().ToString();
            args["end_time"] = EndTime.ToUtcTicks().ToString();
            args["coord_type_output"] = CoordTypeOutput.ToString();
            return args;
        }
    }
}