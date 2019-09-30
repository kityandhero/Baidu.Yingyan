using System;

namespace Baidu.YingYan.Extensions
{
    /// <summary>
    /// 日期扩展
    /// </summary>
    public static class DateTimeExtension
    {
        private static readonly DateTime Reference = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Unix 时间戳转换（秒）
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static ulong ToUtcTicks(this DateTime dt)
        {
            return (ulong)(dt.ToUniversalTime() - Reference).TotalSeconds;
        }

        /// <summary>
        /// Unix 时间戳转换（秒）
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        /// <returns></returns>
        public static DateTime FromUtcTicks(this ulong ticks)
        {
            return Reference.AddSeconds(ticks).ToLocalTime();
        }

        /// <summary>
        /// Unix 时间戳转换（秒）
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        /// <returns></returns>
        public static DateTime FromUtcTicks(this long ticks)
        {
            return Reference.AddSeconds(ticks).ToLocalTime();
        }

        /// <summary>
        /// Unix 时间戳转换（毫秒）
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static ulong ToUtcTicks_ms(this DateTime dt)
        {
            return (ulong)(dt.ToUniversalTime() - Reference).TotalSeconds;
        }

        /// <summary>
        /// Unix 时间戳转换（毫秒）
        /// </summary>
        /// <param name="ticksMs">The ticks ms.</param>
        /// <returns></returns>
        public static DateTime FromUtcTicks_ms(this ulong ticksMs)
        {
            return Reference.AddMilliseconds(ticksMs).ToLocalTime();
        }

        /// <summary>
        /// FUnix 时间戳转换（毫秒）
        /// </summary>
        /// <param name="ticksMs">The ticks ms.</param>
        /// <returns></returns>
        public static DateTime FromUtcTicks_ms(this long ticksMs)
        {
            return Reference.AddMilliseconds(ticksMs).ToLocalTime();
        }
    }
}