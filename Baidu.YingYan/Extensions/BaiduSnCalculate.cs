using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Baidu.YingYan.Extensions
{
    /// <summary>
    /// sn计算算法，官方文档中的示例代码很坑 <a
    /// href="http://lbsyun.baidu.com/index.php?title=webapi/appendix">sn计算算法</a>
    /// </summary>
    public static class BaiduSnCalculate
    {
        /// <summary>
        /// 计算md5
        /// </summary>
        /// <param name="str">The password.</param>
        /// <returns></returns>
        private static string Md5(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] hash = md5.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// 计算sn
        /// </summary>
        /// <param name="sk">sk</param>
        /// <param name="absolutePath">Url 中的绝对路径.</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public static string CalculateSn(string sk, string absolutePath, IDictionary<string, string> args)
        {
            var queryString = args.ToUriQuery();
            var str = WebUtility.UrlEncode(absolutePath + "?" + queryString + sk);
            return Md5(str);
        }
    }
}