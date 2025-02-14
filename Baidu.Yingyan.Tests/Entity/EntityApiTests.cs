﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Baidu.YingYan;
using Baidu.YingYan.Entity;
using NUnit.Framework;

namespace Baidu.YingYan.Tests.Entity
{
    [TestFixture()]
    public class EntityApiTests
    {
        private EntityApi api;
        private string entity_name;
        private string column_key;

        [OneTimeSetUp]
        public void Init()
        {
            var ak = "jmH6fA2QzDWfyPvkKslL741L";
            var service_id = "105686";
            api = new YingYanApi(ak, service_id).Entity;
            entity_name = BitConverter.ToString(Guid.NewGuid().ToByteArray()).Replace("-", "");
            column_key = BitConverter.ToString(Guid.NewGuid().ToByteArray()).Replace("-", "");
        }

        /// <summary>
        /// 添加和删除实体
        /// </summary>
        [Test()]
        public void addAndDeleteTest()
        {
            var t = api.Add(entity_name).Result;
            Assert.AreEqual(t.Status, 0, "add entity fail.");
            Thread.Sleep(1000);
            t = api.Add(entity_name).Result;
            Assert.AreNotEqual(t.Status, 0, "add duplicate entity fail.");

            t = api.Delete(entity_name).Result;
            Assert.AreEqual(t.Status, 0, "delete entity fail.");
        }

        /// <summary>
        /// 添加和删除列
        /// </summary>
        [Test()]
        public void addAndDeleteColumn()
        {
            var t = api.add_column(column_key, "测试列", true).Result;
            Assert.AreEqual(t.status, 0, "add column fail.");
            Thread.Sleep(1000);
            t = api.add_column(column_key, "测试列", true).Result;
            Assert.AreNotEqual(t.status, 0, "add duplicate column fail.");

            var cols = api.list_column().Result;
            Assert.True(cols.columns.Any(o => o.column_key == column_key), "list error");

            t = api.delete_column(column_key).Result;
            Assert.AreEqual(t.status, 0, "delete column fail.");
            cols = api.list_column().Result;
            Assert.False(cols.columns.Any(o => o.column_key == column_key), "list error");
        }

        [Test()]
        public void deleteAllColumns()
        {
            var cols = api.list_column().Result;
            if (cols.columns != null && cols.columns.Length > 0)
            {
                foreach (var c in cols.columns)
                {
                    var r = api.delete_column(c.column_key).Result;
                }
            }
        }

        /// <summary>
        /// 添加和删除实体
        /// </summary>
        [Test()]
        public void fullTest()
        {
            //添加实体
            var t = api.Add(entity_name).Result;
            Assert.AreEqual(t.Status, 0, "add entity fail.");
            Thread.Sleep(1000);

            //重复添加
            t = api.Add(entity_name).Result;
            Assert.AreNotEqual(t.Status, 0, "add duplicate entity fail.");

            //列表
            var list = api.List().Result;
            Assert.True(list.Entities.Any(o => o.EntityName == entity_name), "list entity error");

            //列表
            var list2 = api.list_simple().Result;
            Assert.True(list2.entities.Contains(entity_name), "simple list entity error");

            //添加列
            t = api.add_column(column_key, "测试列").Result;
            Assert.AreEqual(t.Status, 0, "add column fail.");
            Thread.Sleep(1000);

            //重复添加列
            t = api.add_column(column_key, "测试列").Result;
            Assert.AreNotEqual(t.Status, 0, "add duplicate column fail.");

            //列出列
            var cols = api.list_column().Result;
            Assert.True(cols.columns.Any(o => o.column_key == column_key), "list error");

            //更新实体
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add(column_key, column_key);
            t = api.Update(entity_name, dic).Result;
            Assert.AreEqual(t.Status, 0, "update entity fail.");
            Thread.Sleep(1000);

            //列出实体
            list = api.List().Result;
            Assert.True(list.Entities.Any(o => o.EntityName == entity_name), "list entity error");
            Assert.True(list.Entities.Any(o => o.EntityName == entity_name && o.Columns[column_key].ToString() == column_key), "list entity column value error");

            //删除列
            t = api.delete_column(column_key).Result;
            Assert.AreEqual(t.Status, 0, "delete column fail.");

            //删除实体
            t = api.Delete(entity_name).Result;
            Assert.AreEqual(t.Status, 0, "delete entity fail.");
        }
    }
}