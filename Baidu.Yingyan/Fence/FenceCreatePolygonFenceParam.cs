﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 创建多边形围栏
    /// </summary>
    public class FenceCreatePolygonFenceParam : FenceBaseData
    {
        /// <summary>
        /// 围栏类型
        /// </summary>
        public override FenceShapeEnums Shape => FenceShapeEnums.polygon;

        /// <summary>
        /// 多边形围栏形状点, 经纬度顺序为：纬度,经度； 顶点顺序可按顺时针或逆时针排列； 顶点个数在3-100个之间
        /// </summary>
        [Required]
        public LocationPoint[] Vertexes { get; set; }

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">原有参数</param>
        /// <returns>填充后的参数</returns>
        public override Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            args = base.FillArgs(args);
            if (Vertexes?.Any() == true)
            {
                var vs = string.Join(";", Vertexes.Select(o => $"{o?.Latitude},{o?.Longitude}"));
                args["vertexes"] = vs;
            }
            return args;
        }
    }
}