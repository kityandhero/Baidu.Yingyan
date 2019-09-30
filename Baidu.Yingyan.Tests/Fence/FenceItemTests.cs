using System;
using System.Linq;
using Baidu.YingYan;
using NUnit.Framework;

namespace Baidu.YingYan.Tests.Fence
{
    [TestFixture()]
    public class FenceItemTests
    {
        /// <summary>
        /// 添加和删除实体
        /// </summary>
        [Test()]
        public void FenceItemAsArgsTest()
        {
            var t = new FenceItemAsArgs()
            {
                center = new LocationPoint() { Longitude = 110, Latitude = 40 },
                vertexes = new LocationPoint[] {
                     new LocationPoint() { Longitude = 111, Latitude = 41},
                      new LocationPoint() { Longitude = 112, Latitude = 42 }
                }.ToList(),
                valid_date = DateTime.Now,
            };

            var json = JsonConvert.SerializeObject(t);

            Assert.True(json.Contains("\"110,40\""), "LocationPoint serialize fail.");
            Assert.True(json.Contains("\"111,41;112,42\""), "List<LocationPoint> serialize fail.");

            var t2 = JsonConvert.DeserializeObject<FenceItemAsArgs>(json);

            Assert.True(t2.center.latitude == t.center.latitude, "seserialize fail.");
            Assert.True(t2.vertexes[1].latitude == t.vertexes[1].latitude, "seserialize fail.");
        }
    }
}