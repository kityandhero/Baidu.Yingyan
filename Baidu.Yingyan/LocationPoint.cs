﻿using Baidu.YingYan.Converters;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Baidu.YingYan
{
    /// <summary>
    /// 坐标点
    /// </summary>
    public class LocationPoint
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [Required]
        public double Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [Required]
        public double Longitude { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"lat={Latitude}, lng={Longitude}";
        }
    }

    /// <summary>
    /// 包含时间的经纬度
    /// </summary>
    /// <seealso cref="LocationPoint" />
    public class LocationPointWithTime : LocationPoint
    {
        /// <summary>
        /// 定位时的设备时间
        /// </summary>
        [JsonConverter(typeof(UnixTicksConverter))]
        public DateTime LocTime { get; set; }
    }

    /// <summary>
    /// 包含时间和地址的经纬度
    /// </summary>
    /// <seealso cref="LocationPointWithTime" />
    public abstract class LocationPointWithAddress : LocationPointWithTime
    {
        /// <summary>
        /// 点地址
        /// </summary>
        public string Address { get; set; }
    }
}