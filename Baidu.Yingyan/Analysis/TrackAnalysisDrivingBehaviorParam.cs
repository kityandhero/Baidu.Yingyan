using System.Collections.Generic;

namespace Baidu.YingYan.Analysis
{
    /// <summary>
    /// 驾驶行为分析
    /// </summary>
    /// <seealso><cref>Baidu.YingYan.Analysis.TrackAnalysisStayPointParam</cref></seealso>
    public abstract class TrackAnalysisDrivingBehaviorParam : TrackAnalysisStayPointParam
    {
        /// <summary>
        /// 固定限速值 0：根据百度地图道路限速数据计算超速点 其他数值：以设置的数值为阈值，轨迹点速度超过该值则认为是超速；
        /// </summary>
        public double? SpeedingThreshold { get; set; }

        /// <summary>
        /// 急加速的加速度阈值 默认值：1.67，单位：m^2/s，仅支持正数
        /// </summary>
        public double? HarshAccelerationThreshold { get; set; }

        /// <summary>
        /// 急减速的加速度阈值 默认值：-1.67，单位：m^2/s，仅支持负数
        /// </summary>
        public double? HarshBreakingThreshold { get; set; }

        /// <summary>
        /// 急转弯的向心加速度阈值 默认值：5，单位：m^2/s，仅支持正数
        /// </summary>
        public double? HarshSteeringThreshold { get; set; }

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public override Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            args = base.FillArgs(args);
            if (SpeedingThreshold > 0)
                args["speeding_threshold"] = SpeedingThreshold.ToString();
            if (HarshAccelerationThreshold > 0)
                args["harsh_acceleration_threshold"] = HarshAccelerationThreshold.ToString();
            if (HarshBreakingThreshold < 0)
                args["harsh_breaking_threshold"] = HarshBreakingThreshold.ToString();
            if (HarshSteeringThreshold > 0)
                args["harsh_steering_threshold"] = HarshSteeringThreshold.ToString();
            return args;
        }
    }
}