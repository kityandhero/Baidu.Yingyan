using System.Threading.Tasks;

namespace Baidu.YingYan.Analysis
{
    /// <summary>
    /// 鹰眼轨迹分析类接口提供停留点分析和驾驶行为分析功能： <a
    /// href="http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/analysis">轨迹分析</a>
    /// </summary>
    public class AnalysisApi
    {
        private readonly YingYanApi _framework;
        private const string Url = "analysis/";

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalysisApi" /> class.
        /// </summary>
        /// <param name="framework">The framework.</param>
        public AnalysisApi(YingYanApi framework)
        {
            _framework = framework;
        }

        /// <summary>
        /// 停留点分析
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<TrackAnalysisStayPointResult> StayPoint(TrackAnalysisStayPointParam param)
        {
            return _framework.Get<TrackAnalysisStayPointResult>(Url + "staypoint", param);
        }

        /// <summary>
        /// 驾驶行为分析
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<TrackAnalysisDrivingBehaviorResult> DrivingBehaviour(TrackAnalysisDrivingBehaviorParam param)
        {
            return _framework.Get<TrackAnalysisDrivingBehaviorResult>(Url + "drivingbehaviour", param);
        }
    }
}