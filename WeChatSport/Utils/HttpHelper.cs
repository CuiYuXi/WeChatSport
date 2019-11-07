using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeChatSport.Utils
{
    public abstract class HttpHelper
    {
        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string Post(HttpItem item)
        {
            try
            {
                //准备网络请求  
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(item.Url);
                request.Method = "POST";
                request.Referer = item.Referer;
                request.ContentType = item.ContentType;
                request.UserAgent = item.UserAgent;
                request.Host = item.Host;
                if (item.PostData != null)
                {
                    byte[] data = Encoding.UTF8.GetBytes(item.PostData);
                    request.ContentLength = data.Length;
                    Stream newStream = request.GetRequestStream();
                    // 发送数据
                    newStream.Write(data, 0, data.Length);
                    newStream.Close();
                }
                // 获取返回信息
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();
                return content;
            }
            catch (Exception ex)
            {
                var e = ex;
                throw;
            }

        }
        public class HttpItem
        {
            public string Url { get; set; }
            public string PostData { get; set; }
            public string Cookie { get; set; }
            public string Method { get; set; }
            public string Referer { get; set; }
            public string ContentType { get; set; }
            public string UserAgent { get; set; }
            public string Host { get; set; }
            public string Accept { get; set; }
        }
    }
}
