using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Haceau.Google.Translate
{
    /// <summary>
    /// 网络
    /// </summary>
    internal class Web
    {
        /// <summary>
        /// 网址
        /// </summary>
        private string url;

        /// <summary>
        /// 网址
        /// </summary>
        public string Url
        {
            get => url;
            set
            {
                if (value.Substring(0, 7) != "http://" && value.Substring(0, 8) != "https://")
                    url = "https://" + value;
                else
                    url = value;
            }
        }

        public HttpClient Client
        {
            get;
            set;
        }

        /// <summary>
        /// 使用网址进行初始化
        /// </summary>
        /// <param name="url">网址</param>
        public Web(string url, HttpClient client)
        {
            Url = url;
            Client = client;
        }

        /// <summary>
        /// 发送GET请求
        /// </summary>
        /// <returns>请求结果</returns>
        public string SendGetRequest()
        {
            if (Url == null)
                throw new Exception("属性Url不能为空。");
            HttpResponseMessage response = Client.GetAsync(Url).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
