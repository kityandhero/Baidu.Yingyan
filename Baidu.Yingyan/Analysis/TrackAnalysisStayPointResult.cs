using Baidu.YingYan.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Baidu.YingYan.Analysis
{
    /// <summary>
    /// 停留点分析结果
    /// </summary>
    /// <seealso cref="CommonResult" />
    public class TrackAnalysisStayPointResult : CommonResult
    {
        /// <summary>
        /// 停留次数
        /// </summary>
        public int StayPointNumber { get; set; }

        /// <summary>
        /// 停留记录列表
        /// </summary>
        public List<TrackAnalysisStayPoint> StayPoints { get; set; }
    }

    /// <summary>
    /// 停留点
    /// </summary>
    public abstract class TrackAnalysisStayPoint
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        [JsonConverter(typeof(UnixTicksConverter))]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [JsonConverter(typeof(UnixTicksConverter))]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 停留时长，单位：秒
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 停留点
        /// </summary>
        public LocationPoint StayPoint { get; set; }
    }
}