using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Baidu.YingYan;
using Baidu.YingYan.Track;
using NUnit.Framework;

namespace Baidu.YingYan.Tests.Track
{
    [TestFixture()]
    public class TrackApiTests
    {
        private TrackApi api;
        private string entity_name1;
        private string entity_name2;
        private string entity_name3;

        [OneTimeSetUp]
        public void Init()
        {
            var ak = "jmH6fA2QzDWfyPvkKslL741L";
            var service_id = "105686";
            var yingyan = new YingYanApi(ak, service_id);
            api = yingyan.Track;
            entity_name1 = "data1";
            entity_name2 = "data2";
            entity_name3 = "data3";

            //var r1 = yingyan.entity.add(entity_name1).Result;
            //var r2 = yingyan.entity.delete(entity_name3).Result;
            var r3 = yingyan.Entity.Add(entity_name3).Result;
        }

        /// <summary>
        /// 上传数据
        /// </summary>
        [Test()]
        public void uploadData1()
        {
            uploadData(entity_name1, 100000);
        }

        /// <summary>
        /// 上传数据
        /// </summary>
        [Test()]
        public void uploadData2()
        {
            uploadData(entity_name2, 0);
        }

        /// <summary>
        /// 上传数据
        /// </summary>
        [Test()]
        public void uploadData3()
        {
            var points = loadFile(entity_name3, DateTime.Now.AddDays(-1));
            points.ForEach(o => { o.coord_type = CoordType.Baidu; });
            int count = 0;
            int total = points.Count;
            foreach (var p in points.Skip(count))
            {
                var r2 = api.AddPoint(entity_name3, p).Result;
                count++;
                if (count % 100 == 0)
                    Console.WriteLine("count: {0} {1:p}", count, count / 1.0 / total);
            }
        }

        /// <summary>
        /// 获取历史记录
        /// </summary>
        [Test()]
        public void getHistory()
        {
            var r = api.gethistory_simple(entity_name3, DateTime.Now.Date.AddDays(-1), DateTime.Now.Date, true, 1, 5000).Result;
        }

        /// <summary>
        /// 上传数据
        /// </summary>
        [Test()]
        public void batchUploadData2()
        {
            batchUploadData(entity_name2, 90);
        }

        private void uploadData(string entity_name, int skip = 0)
        {
            var points = loadFile(entity_name, DateTime.Now.AddDays(-1));
            int count = skip;
            int total = points.Count;
            foreach (var p in points.Skip(count))
            {
                var r2 = api.AddPoint(entity_name, p).Result;
                count++;
                if (count % 100 == 0)
                    Console.WriteLine("count: {0} {1:p}", count, count / 1.0 / total);
            }
        }

        private List<TrackPoint> loadFile(string entity_name, DateTime? setDate = null)
        {
            var path = Path.GetFullPath(Path.Combine(
              TestContext.CurrentContext.TestDirectory,
              "../../../",
              string.Format("data/{0}.txt", entity_name)));

            var lines = File.ReadAllLines(path);
            var points = lines.Select(o => o.Split(','))
                 .Where(o => o.Length >= 3)
                 .Select(o => new TrackPoint()
                 {
                     coord_type = CoordType.GPS,
                     LocTime = DateTime.Parse(o[0]),
                     Longitude = double.Parse(o[1]),
                     Latitude = double.Parse(o[2])
                 }).ToList();
            if (setDate != null && points.Count > 0)
            {
                var r = (int)(setDate.Value - points[0].LocTime).TotalDays;
                points.ForEach(o => o.LocTime = o.LocTime.AddDays(r));
            }
            return points;
        }

        private void batchUploadData(string entity_name, int batch = 50, int skip = 0)
        {
            if (batch <= 0)
                batch = 50;
            else if (batch > 200)
                batch = 200;
            var points = loadFile(entity_name, DateTime.Now.AddDays(-1));

            int count = skip;
            int total = points.Count;

            foreach (var ps in points.Skip(count).Select((o, i) => new { o, i })
                .GroupBy(o => o.i / batch)
                .Select(o => o.Select(v => v.o).ToArray()))
            {
                var r2 = api.AddPoints(entity_name, ps).Result;
                count += ps.Length;
                if (count % 100 == 0)
                    Console.WriteLine("count: {0} {1:p}", count, count / 1.0 / total);
            }
        }
    }
}