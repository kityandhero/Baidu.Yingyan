using System.Collections.Generic;

namespace Baidu.YingYan
{
    /// <summary>
    /// 请求参数
    /// </summary>
    public interface IYingYanParam
    {
        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">原有参数</param>
        /// <returns>填充后的参数</returns>
        Dictionary<string, string> FillArgs(Dictionary<string, string> args);
    }

    /// <summary>
    /// 请求参数
    /// </summary>
    /// <seealso cref="IYingYanParam" />
    public class DictionaryYingYanParam : IYingYanParam
    {
        /// <summary>
        /// 值列表
        /// </summary>
        public Dictionary<string, string> values { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryYingYanParam" /> class.
        /// </summary>
        public DictionaryYingYanParam()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryYingYanParam" /> class.
        /// </summary>
        /// <param name="values">The values.</param>
        public DictionaryYingYanParam(Dictionary<string, string> values)
        {
            this.values = values;
        }

        /// <summary>
        /// 填充参数
        /// </summary>
        /// <param name="args">原有参数</param>
        /// <returns>填充后的参数</returns>
        public Dictionary<string, string> FillArgs(Dictionary<string, string> args)
        {
            if (args == null)
                args = new Dictionary<string, string>();
            if (values?.Count > 0)
            {
                foreach (var v in values)
                    args[v.Key] = v.Value;
            }
            return args;
        }

        /// <summary>
        /// 隐式转换
        /// </summary>
        /// <param name="item">对象</param>

        public static implicit operator DictionaryYingYanParam(Dictionary<string, string> item)
        {
            return new DictionaryYingYanParam(item);
        }
    }
}