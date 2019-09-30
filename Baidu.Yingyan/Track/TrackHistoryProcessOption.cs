using System.Collections.Generic;

namespace Baidu.YingYan.Track
{
    /// <summary>
    /// 纠偏选项
    /// </summary>
    public class TrackHistoryProcessOption
    {
        /// <summary>
        /// 去噪，默认为1
        /// </summary>
        public bool? NeedDenoise { get; set; }

        /// <summary>
        /// 绑路，之前未开通绑路的service，默认值为0；之前已开通绑路的service，默认值为1
        /// </summary>
        public bool? NeedMapmatch { get; set; }

        /// <summary>
        /// 抽稀,默认值为0
        /// </summary>
        public bool? NeedVacuate { get; set; }

        /// <summary>
        ///   定位精度过滤，用于过滤掉定位精度较差的轨迹点，默认为0
        /// </summary>
        public int? RadiusThreshold { get; set; }

        /// <summary>
        /// 交通方式
        /// </summary>
        public TrackHistoryTransportModeEnums? TransportMode { get; set; }

        /// <summary>
        /// 获取选项值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetOption(string name, bool value)
        {
            var t = value == true ? 1 : 0;
            return $"{name}={t}";
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var options = new List<string>();
            if (NeedDenoise != null)
                options.Add(GetOption(nameof(NeedDenoise), NeedDenoise.Value));
            if (RadiusThreshold > 0)
                options.Add($"{nameof(RadiusThreshold)}={RadiusThreshold}");
            if (NeedVacuate != null)
                options.Add(GetOption(nameof(NeedVacuate), NeedVacuate.Value));
            if (NeedMapmatch != null)
                options.Add(GetOption(nameof(NeedMapmatch), NeedMapmatch.Value));
            if (TransportMode != null)
                options.Add($"{nameof(TransportMode)}={(int)TransportMode}");
            return string.Join(",", options);
        }
    }

    /// <summary>
    /// 交通方式
    /// </summary>
    public enum TrackHistoryTransportModeEnums
    {
        /// <summary>
        /// 驾车(默认)
        /// </summary>
        driving = 1,

        /// <summary>
        ///  骑行
        /// </summary>
        riding = 2,

        /// <summary>
        /// 步行
        /// </summary>
        walking = 3,
    }
}