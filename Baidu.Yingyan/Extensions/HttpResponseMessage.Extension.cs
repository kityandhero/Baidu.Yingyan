﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Baidu.Yingyan
{
    public static class HttpResponseMessageExtension
    {
        public static async Task<T> JsonReadAsAsync<T>(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}