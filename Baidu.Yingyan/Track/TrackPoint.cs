using Baidu.YingYan.Entity;
using System.ComponentModel.DataAnnotations;
using Baidu.YingYan.Extensions;

namespace Baidu.YingYan.Track
{
    /// <summary>
    /// 轨迹点
    /// </summary>
    /// <seealso><cref>Baidu.YingYan.Entity.EntityLocationPoint</cref></seealso>
    public class TrackPoint : EntityLocationPoint
    {
        /// <summary>
        /// entity唯一标识
        /// </summary>
        [Required]
        public string EntityName { get; set; }

        /// <summary>
        /// 坐标类型
        /// </summary>
        [Required]
        public CoordTypeEnums CoordTypeInput { get; set; } = CoordTypeEnums.bd09Ll;

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{EntityName},{Longitude},{Latitude},{LocTime.ToUtcTicks()},{CoordTypeInput}";
        }
    }
}