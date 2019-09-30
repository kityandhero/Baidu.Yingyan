namespace Baidu.YingYan.Analysis
{
    /// <summary>
    /// 驾驶行为分析结果
    /// </summary>
    /// <seealso><cref>Baidu.YingYan.Analysis.TrackAnalysisStayPointParam</cref></seealso>
    public class TrackAnalysisDrivingBehaviorResult : CommonResult
    {
        /// <summary>
        /// 行程里程
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// 行程耗时
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 平均时速
        /// </summary>
        public double AverageSpeed { get; set; }

        /// <summary>
        /// 最高时速
        /// </summary>
        public double MaxSpeed { get; set; }

        /// <summary>
        /// 超速次数
        /// </summary>
        public int SpeedingNum { get; set; }

        /// <summary>
        /// 急加速次数
        /// </summary>
        public int HarshAccelerationNum { get; set; }

        /// <summary>
        /// 急刹车次数
        /// </summary>
        public int HarshBreakingNum { get; set; }

        /// <summary>
        /// 急转弯次数
        /// </summary>
        public int HarshSteeringNum { get; set; }

        /// <summary>
        /// 起点信息
        /// </summary>
        public LocationPointWithAddress StartPoint { get; set; }

        /// <summary>
        /// 终点信息
        /// </summary>
        public LocationPointWithAddress EndPoint { get; set; }

        /// <summary>
        /// 超速记录集合
        /// </summary>
        public TrackAnalysisDrivingBehaviorSpeedingPoint[][] speeding { get; set; }

        /// <summary>
        /// 急加速
        /// </summary>
        public TrackAnalysisDrivingBehaviorHarshAccelerationPoint[] HarshAcceleration { get; set; }

        /// <summary>
        /// 急停
        /// </summary>
        public TrackAnalysisDrivingBehaviorHarshAccelerationPoint[] HarshBreaking { get; set; }

        /// <summary>
        /// 急转弯记录
        /// </summary>
        public TrackAnalysisDrivingBehaviorHarshSteeringPoint[] HarshSteering { get; set; }
    }

    /// <summary>
    /// 超速记录点
    /// </summary>
    /// <seealso cref="LocationPointWithTime" />
    public abstract class TrackAnalysisDrivingBehaviorSpeedingPoint : LocationPointWithTime
    {
        /// <summary>
        /// 实际行驶时速
        /// </summary>
        public double ActualSpeed { get; set; }

        /// <summary>
        /// 所在道路限定最高时速
        /// </summary>
        public double LimitSpeed { get; set; }
    }

    /// <summary>
    /// 急转弯记录点
    /// </summary>
    /// <seealso cref="LocationPointWithTime" />
    public abstract class TrackAnalysisDrivingBehaviorHarshSteeringPoint : LocationPointWithTime
    {
        /// <summary>
        /// 向心加速度,单位：m/s^2
        /// </summary>
        public double CentripetalAcceleration { get; set; }

        /// <summary>
        /// 转向类型 取值范围：unknown（方向未知）,left（左转）,right（右转）
        /// </summary>
        public string TurnType { get; set; }

        /// <summary>
        /// 转向时速,单位：km/h
        /// </summary>
        public double Speed { get; set; }
    }

    /// <summary>
    /// 急加速记录点
    /// </summary>
    /// <seealso cref="LocationPointWithTime" />
    public class TrackAnalysisDrivingBehaviorHarshAccelerationPoint : LocationPointWithTime
    {
        /// <summary>
        /// 实际加速度，单位：m/s^2
        /// </summary>
        public double Acceleration { get; set; }

        /// <summary>
        /// 加速前时速，单位：km/h
        /// </summary>
        public double InitialSpeed { get; set; }

        /// <summary>
        /// 加速后时速，单位：km/h
        /// </summary>
        public double EndSpeed { get; set; }
    }
}