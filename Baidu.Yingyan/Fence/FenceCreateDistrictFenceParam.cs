﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 创建行政区划围栏
    /// </summary>
    public class FenceCreateDistrictFenceParam : FenceBaseData
    {
        /// <summary>
        /// 围栏类型
        /// </summary>
        public override FenceShapeEnums Shape => FenceShapeEnums.district;

        /// <summary>
        /// 行政区划关键字 支持中国国家、省、市、区/县名称。请尽量输入完整的行政区层级和名称，保证名称的唯一性。 若输入的行政区名称匹配多个行政区，围栏将创建失败。 示例： 中国 北京市
        /// 湖南省长沙市 湖南省长沙市雨花区
        /// </summary>
        [Required]
        public string Keyword { get; set; }

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">原有参数</param>
        /// <returns>填充后的参数</returns>
        public override Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            args = base.FillArgs(args);
            args["keyword"] = Keyword;
            return args;
        }
    }
}