﻿using Baidu.YingYan.Track;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Baidu.YingYan.Extensions;

namespace Baidu.YingYan.Analysis
{
    /// <summary>
    /// 停留点分析参数
    /// </summary>
    /// <seealso cref="TrackHistoryGetLatestPointParam" />
    public class TrackAnalysisStayPointParam : TrackHistoryGetLatestPointParam
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// 结束时间不能大于当前时间，且起止时间区间不超过24小时。为提升响应速度，同时避免轨迹点过多造成请求超时（3s）失败，建议缩短每次请求的时间区间，将一天轨迹拆分成多段进行拼接
        /// </summary>
        [Required]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 停留时间 单位：秒，默认值：600。该字段用于设置停留点判断规则，即若系统判断在半径为stay_radius的圆形范围内停留时间超过stay_time，则被认为是一次停留
        /// </summary>
        public int StayTime { get; set; } = 600;

        /// <summary>
        /// 停留半径
        /// 单位：米，取值范围：[1,500]，默认值：20。该字段用于设置停留点判断规则，即若系统判断在半径为stay_radius的圆形范围内停留时间超过stay_time，则被认为是一次停留
        /// </summary>
        public int StayRadius { get; set; } = 20;

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public override Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            args = base.FillArgs(args);
            args["start_time"] = StartTime.ToUtcTicks().ToString();
            args["end_time"] = EndTime.ToUtcTicks().ToString();
            args["stay_time"] = StayTime.ToString();
            if (StayRadius < 1)
                StayRadius = 1;
            else if (StayRadius > 500)
                StayRadius = 500;
            args["stay_radius"] = StayRadius.ToString();
            return args;
        }
    }
}