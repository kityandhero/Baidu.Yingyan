﻿using System.Collections.Generic;

namespace Baidu.YingYan.Entity
{
    /// <summary>
    /// 关键字搜索参数
    /// </summary>
    public abstract class EntitySearchParam : EntityListWithOrderParam
    {
        /// <summary>
        /// 搜索关键字,默认为空，检索全部数据支持 entity_name + entity_desc 的联合模糊检索
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public override Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            args = base.FillArgs(args);

            if (string.IsNullOrWhiteSpace(Query) == false)
                args["query"] = Query;
            return args;
        }
    }
}