using System.Threading.Tasks;

namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 地理围栏 围栏管理类接口主要负责围栏的创建、更新、删除和查询，支持以下类型的围栏 地理围栏报警类接口主要提供
    /// 1. 查询监控对象在围栏内/外：查询被监控对象在指定围栏内或外，也支持查询被监控对象目前相对于所有围栏的状态
    /// 2. 查询围栏报警信息：支持查询某时间段内单个围栏或该 service 下所有围栏的报警信息
    /// 3. 服务端报警信息推送：鹰眼将报警信息实时推送至开发者的服务端 <a
    ///    href="http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/geofence">围栏管理类</a><a
    ///    href="http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/geofencealarm">地理围栏报警</a>
    /// </summary>
    public class FenceApi
    {
        private readonly YingYanApi _framework;
        private const string Url = "fence/";

        /// <summary>
        /// Initializes a new instance of the <see cref="FenceApi" /> class.
        /// </summary>
        /// <param name="framework">The framework.</param>
        public FenceApi(YingYanApi framework)
        {
            _framework = framework;
        }

        #region 围栏管理类

        /// <summary>
        /// 创建圆形围栏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceCreateFenceResult> CreateCircleFence(FenceCreateCircleFenceParam param)
        {
            return _framework.Post<FenceCreateFenceResult>(Url + "createcirclefence", param);
        }

        /// <summary>
        /// 创建多边形围栏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceCreateFenceResult> CreatePolygonFence(FenceCreatePolygonFenceParam param)
        {
            return _framework.Post<FenceCreateFenceResult>(Url + "createpolygonfence", param);
        }

        /// <summary>
        /// 创建线型围栏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceCreateFenceResult> CreatePolylineFence(FenceCreatePolylineFenceParam param)
        {
            return _framework.Post<FenceCreateFenceResult>(Url + "createpolylinefence", param);
        }

        /// <summary>
        /// 创建行政区划围栏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceCreateDistrictFenceResult> CreateDistrictFence(FenceCreateDistrictFenceParam param)
        {
            return _framework.Post<FenceCreateDistrictFenceResult>(Url + "createdistrictfence", param);
        }

        /// <summary>
        /// 更新圆形围栏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceCreateFenceResult> UpdateCircleFence(FenceCreateCircleFenceParam param)
        {
            return _framework.Post<FenceCreateFenceResult>(Url + "updatecirclefence", param);
        }

        /// <summary>
        /// 更新多边形围栏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceCreateFenceResult> UpdatePolygonFence(FenceCreatePolygonFenceParam param)
        {
            return _framework.Post<FenceCreateFenceResult>(Url + "updatepolygonfence", param);
        }

        /// <summary>
        /// 更新线型围栏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceCreateFenceResult> UpdatePolylineFence(FenceCreatePolylineFenceParam param)
        {
            return _framework.Post<FenceCreateFenceResult>(Url + "updatepolylinefence", param);
        }

        /// <summary>
        /// 更新行政区划围栏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceCreateDistrictFenceResult> UpdateDistrictFence(FenceCreateDistrictFenceParam param)
        {
            return _framework.Post<FenceCreateDistrictFenceResult>(Url + "updatedistrictfence", param);
        }

        /// <summary>
        /// 删除围栏
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceDeleteFenceResult> Delete(FenceDeleteFenceParam param)
        {
            return _framework.Post<FenceDeleteFenceResult>(Url + "delete", param);
        }

        /// <summary>
        /// 查询围栏信息
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceListFenceResult> List(FenceListFenceParam param)
        {
            return _framework.Post<FenceListFenceResult>(Url + "list", param);
        }

        #endregion 围栏管理类

        #region 管理围栏监控对象

        /// <summary>
        /// 增加围栏需监控的entity
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<CommonResult> AddMonitoredPerson(FenceMonitoredPersonEditParam param)
        {
            return _framework.Post<CommonResult>(Url + "addmonitoredperson", param);
        }

        /// <summary>
        /// 删除围栏可去除监控的entity
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<CommonResult> DeleteMonitoredPerson(FenceMonitoredPersonEditParam param)
        {
            return _framework.Post<CommonResult>(Url + "deletemonitoredperson", param);
        }

        /// <summary>
        /// 查询围栏监控的所有entity
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceMonitoredPersonQueryResult> ListMonitoredPerson(FenceMonitoredPersonQueryParam param)
        {
            return _framework.Get<FenceMonitoredPersonQueryResult>(Url + "listmonitoredperson", param);
        }

        #endregion 管理围栏监控对象

        #region 地理围栏报警

        /// <summary>
        /// 查询监控对象在围栏内或外
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceQueryStatusResult> QueryStatus(FenceQueryStatusParam param)
        {
            return _framework.Get<FenceQueryStatusResult>(Url + "querystatus", param);
        }

        /// <summary>
        /// 查询某监控对象的历史报警信息
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceAlarmHistoryQueryResult> HistoryAlarm(FenceHistoryAlarmParam param)
        {
            return _framework.Get<FenceAlarmHistoryQueryResult>(Url + "historyalarm", param);
        }

        /// <summary>
        /// 批量查询某 service 下时间段以内的所有报警信息，用于服务端报警同步
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<FenceBatchHistoryAlarmResult> BatchHistoryAlarm(FenceBatchHistoryAlarmParam param)
        {
            return _framework.Get<FenceBatchHistoryAlarmResult>(Url + "batchhistoryalarm", param);
        }

        #endregion 地理围栏报警
    }
}