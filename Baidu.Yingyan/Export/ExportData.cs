using Baidu.YingYan.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Baidu.YingYan.Export
{
    /// <summary>
    /// 导出的一行数据
    /// </summary>
    public class ExportData
    {
        /// <summary>
        /// 鹰眼内部使用的id，可以忽略
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// entity名称，其唯一标识
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// entity 可读性描述
        /// </summary>
        public string EntityDesc { get; set; }

        /// <summary>
        /// 最新的轨迹点信息
        /// </summary>
        public ExportDataLocationPoint Loc { get; set; }

        /// <summary>
        /// 该entity最新定位时间
        /// </summary>
        [JsonConverter(typeof(UnixTicksConverter))]
        public DateTime LocTime { get; set; }

        /// <summary>
        /// entity属性修改时间，该时间为服务端时间
        /// </summary>
        [JsonConverter(typeof(UnixTicksConverter))]
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// entity创建时间，该时间为服务端时间
        /// </summary>
        [JsonConverter(typeof(UnixTicksConverter))]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 扩展数据
        /// </summary>
        public ExportDataCustomData CustomData { get; set; }
    }

    /// <summary>
    /// 最新的轨迹点信息
    /// </summary>
    public abstract class ExportDataLocationPoint : LocationPoint
    {
        /// <summary>
        /// 坐标系类型，等效于CoordType2Enums
        /// </summary>
        public CoordType2Enums CoordType { get; set; }
    }

    /// <summary>
    /// 扩展数据
    /// </summary>
    public abstract class ExportDataCustomData
    {
        /// <summary>
        /// 定位精度(m)
        /// </summary>
        public double? Radius { get; set; }

        /// <summary>
        /// 方向,范围为[0,359]，0度为正北方向，顺时针
        /// </summary>
        public int? Direction { get; set; }

        /// <summary>
        /// 速度,(km/h)
        /// </summary>
        public double? Speed { get; set; }

        /// <summary>
        /// 高度,(m)
        /// </summary>
        public double? Height { get; set; }

        /// <summary>
        /// 楼层,若处于百度支持室内定位的区域，则将返回楼层信息，默认 null
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// 距中心点距离，单位：m，仅在周边搜索（entity/aroundsearch）时返回该字段
        /// </summary>
        public double? Distance { get; set; }

        /// <summary>
        /// 对象数据名称
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// 开发者自定义track的属性，只有当开发者为track创建了自定义属性字段，且赋过值，才会返回
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> Columns { get; set; }
    }
}