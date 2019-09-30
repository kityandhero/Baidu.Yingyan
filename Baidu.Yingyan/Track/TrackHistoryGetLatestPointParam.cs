using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Baidu.YingYan.Track
{
    /// <summary>
    /// 实时纠偏参数
    /// </summary>
    public class TrackHistoryGetLatestPointParam : IYingYanParam
    {
        /// <summary>
        /// entity唯一标识
        /// </summary>
        [Required]
        public string EntityName { get; set; }

        /// <summary>
        /// 纠偏选项
        /// </summary>
        public TrackHistoryProcessOption ProcessOption { get; set; }

        /// <summary>
        /// 返回的坐标类型
        /// </summary>
        public CoordTypeEnums CoordTypeOutput { get; set; } = CoordTypeEnums.bd09Ll;

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public virtual Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            if (args == null)
            {
                args = new Dictionary<string, string>();
            }

            args["entity_name"] = EntityName;

            var op = ProcessOption?.ToString();

            if (string.IsNullOrWhiteSpace(op) == false)
                args["process_option"] = op;

            args["coord_type_output"] = CoordTypeOutput.ToString();
            return args;
        }
    }
}