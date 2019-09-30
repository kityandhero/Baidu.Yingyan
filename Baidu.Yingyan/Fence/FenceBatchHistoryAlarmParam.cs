using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Baidu.YingYan.Extensions;

namespace Baidu.YingYan.Fence
{
    /// <summary>
    /// 批量查询所有围栏报警信息
    /// </summary>
    /// <seealso cref="Baidu.YingYan.Fence.FenceQueryStatusParam" />
    public abstract class FenceBatchHistoryAlarmParam : IYingYanParam
    {
        /// <summary>
        /// 开始时间,查询的时间是服务端接收到报警的时间，即报警信息的 create_time。
        /// 例如，轨迹点实际触发围栏时间为13:00，但若由于各种原因，轨迹点上传至服务端进行围栏计算的时间为14:00，则该报警的 create_time为14:00。
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间 结束时间需大于开始时间，但不可超过1小时。即每次请求，最多只能同步1个小时时长的报警信息。
        /// </summary>
        [Required]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 返回坐标类型
        /// </summary>
        public CoordTypeEnums CoordTypeOutput { get; set; } = CoordTypeEnums.bd09Ll;

        /// <summary>
        /// 可选，默认值为1。page_index与page_size一起计算从第几条结果返回，代表返回第几页。
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 可选，默认值为100。最大值1000。page_size与page_index一起计算从第几条结果返回，代表返回结果中每页有几条记录。
        /// </summary>
        public int PageSize { get; set; } = 500;

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">原有参数</param>
        /// <returns>填充后的参数</returns>
        public virtual Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            if (args == null)
                args = new Dictionary<string, string>();

            args["start_time"] = StartTime.ToUtcTicks().ToString();
            args["end_time"] = EndTime.ToUtcTicks().ToString();
            args["coord_type_output"] = CoordTypeOutput.ToString();
            args["page_index"] = PageIndex.ToString();
            args["page_size"] = PageSize.ToString();
            return args;
        }
    }
}