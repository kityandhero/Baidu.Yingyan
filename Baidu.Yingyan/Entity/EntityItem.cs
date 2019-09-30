using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Baidu.YingYan.Entity
{
    /// <summary>
    /// entity 对象
    /// </summary>
    public abstract class EntityItem
    {
        /// <summary>
        /// entity名称，其唯一标识
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// entity 可读性描述
        /// </summary>
        public string EntityDesc { get; set; }

        /// <summary>
        /// entity属性修改时间，该时间为服务端时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// entity创建时间，该时间为服务端时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最新的轨迹点信息
        /// </summary>
        public EntityLocationPoint LatestLocation { get; set; }

        /// <summary>
        /// 开发者自定义的entity属性信息
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> Columns { get; set; }
    }
}