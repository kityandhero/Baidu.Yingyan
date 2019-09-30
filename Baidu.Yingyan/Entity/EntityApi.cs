using System.Collections.Generic;
using System.Threading.Tasks;

namespace Baidu.YingYan.Entity
{
    /// <summary>
    /// 终端管理类接口主要实现：entity的创建、更新、删除、查询。例如：添加一辆车、删除一辆车、更新车辆的属性信息（如：车辆所属运营区）等。 根据关键字或地理范围搜索 entity
    /// 实时位置，即上传至鹰眼服务端的最新位置。例如：根据名称搜索车辆，或搜索周边的车辆、矩形或多边形范围内的车辆等。 <a
    /// href="http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/entity">终端管理</a><a
    /// href="http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/entitysearch">实时位置搜索</a>
    /// </summary>
    public class EntityApi
    {
        private readonly YingYanApi _framework;
        private const string Url = "entity/";

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityApi" /> class.
        /// </summary>
        /// <param name="framework">The framework.</param>
        public EntityApi(YingYanApi framework)
        {
            _framework = framework;
        }

        #region Entity 管理

        /// <summary>
        /// 添加一个新的entity，一个entity可以是一个人、一辆车、或者任何运动的物体。
        /// </summary>
        /// <param name="entityName">
        /// entity名称，作为其唯一标识。128字节。同一service服务中entity_name不可重复。一旦创建，entity_name 不可更新。
        /// </param>
        /// <param name="entityDesc">entity 的可读性描述，128字节，</param>
        /// <param name="columns">开发者自定义字段(可选)</param>
        /// <returns></returns>
        public Task<CommonResult> Add(string entityName, string entityDesc = null, Dictionary<string, string> columns = null)
        {
            var args = _framework.GetDefaultArgs(columns);
            args["entity_name"] = entityName;
            args["entity_desc"] = entityDesc;

            return _framework.Post<CommonResult>(Url + "add", args);
        }

        /// <summary>
        /// 更新 entity 的属性信息，如 entity 的描述、entity自定义属性字段的值。
        /// </summary>
        /// <param name="entityName">entity名称，作为其唯一标识。</param>
        /// <param name="entityDesc">entity 可读性描述</param>
        /// <param name="columns">开发者自定义字段(可选)</param>
        /// <returns></returns>
        public Task<CommonResult> Update(string entityName, string entityDesc = null, Dictionary<string, string> columns = null)
        {
            var args = _framework.GetDefaultArgs(columns);
            args["entity_name"] = entityName;
            args["entity_desc"] = entityDesc;
            return _framework.Post<CommonResult>(Url + "update", args);
        }

        /// <summary>
        /// 根据entity_name删除一个entity。
        /// </summary>
        /// <param name="entityName">entity名称，作为其唯一标识。</param>
        /// <returns></returns>
        public Task<CommonResult> Delete(string entityName)
        {
            var args = _framework.GetDefaultArgs();
            args["entity_name"] = entityName;

            return _framework.Post<CommonResult>(Url + "delete", args);
        }

        /// <summary>
        /// 查询entity：根据service_id、entity_name和自定义检索字段，查询本service中所有符合条件的entity信息及其实时位置。
        /// </summary>
        /// <param name="param">查询参数</param>
        /// <returns></returns>
        public Task<EntityListResult> List(EntityListParam param = null)
        {
            return _framework.Get<EntityListResult>(Url + "list", param);
        }

        #endregion Entity 管理

        #region 搜索 Entity 实时位置

        /// <summary>
        /// 根据关键字搜索entity
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<EntityListResult> Search(EntitySearchParam param)
        {
            return _framework.Get<EntityListResult>(Url + "search", param);
        }

        /// <summary>
        /// 矩形范围搜索
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<EntityListResult> Boundsearch(EntityBoundSearchParam param)
        {
            return _framework.Get<EntityListResult>(Url + "boundsearch", param);
        }

        /// <summary>
        /// 周边搜索
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<EntityListResult> Aroundsearch(EntityAroundSearchParam param)
        {
            return _framework.Get<EntityListResult>(Url + "aroundsearch", param);
        }

        /// <summary>
        /// 多边形搜索
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<EntityListResult> Polygonsearch(EntityPolygonSearchParam param)
        {
            return _framework.Get<EntityListResult>(Url + "polygonsearch", param);
        }

        /// <summary>
        /// 行政区搜索
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public Task<EntityDistrictSearchResult> Districtsearch(EntityDistrictSearchParam param)
        {
            return _framework.Get<EntityDistrictSearchResult>(Url + "districtsearch", param);
        }

        #endregion 搜索 Entity 实时位置
    }
}