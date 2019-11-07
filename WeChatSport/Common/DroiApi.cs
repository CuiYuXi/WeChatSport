using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeChatSport.Models;
using WeChatSport.Repository;
using WeChatSport.Utils;

namespace WeChatSport.Common
{
    public class DroiApi : IDroiApi
    {
        public ResponseResult SetStep(string accountId, string opid, int jibuNuber)
        {
            string timeStamp = GetTimeStamp();
            string salt = "8061FD";
            string sing = Md5Hash(accountId + salt + jibuNuber + salt + timeStamp + salt + opid);

            HttpHelper.HttpItem httpItem = new HttpHelper.HttpItem()
            {
                Url = "http://weixin.droi.com/health/phone/index.php/SendWechat/stepSubmit",
                ContentType = "application/x-www-form-urlencoded; charset=UTF-8",
                Accept = "*/*",
                Referer = "http://weixin.droi.com",
                Host = "weixin.droi.com",
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                PostData = $"accountId={accountId}&jibuNuber={jibuNuber}&timeStamp={timeStamp}&sign={sing}",
            };
            string PostContent = HttpHelper.Post(httpItem);
            return JsonConvert.DeserializeObject<ResponseResult>(PostContent);
        }

        public ResponseResult GetOpenId(string accountId)
        {
            if (!string.IsNullOrEmpty(accountId))
            {
                string timeStamp = GetTimeStamp();
                string salt = "8061FD";
                string sing = Md5Hash(accountId + salt + timeStamp);
                HttpHelper.HttpItem httpItem = new HttpHelper.HttpItem()
                {
                    Url = "http://weixin.droi.com/health/phone/index.php/SendWechat/getWxOpenid",
                    ContentType = "application/x-www-form-urlencoded; charset=UTF-8",
                    Accept = "*/*",
                    Referer= "http://weixin.droi.com",
                    Host= "weixin.droi.com",
                    UserAgent= "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    PostData = $"accountId={accountId}&timeStamp={timeStamp}&sign={sing}",
                };
                string PostContent = HttpHelper.Post(httpItem);
                return JsonConvert.DeserializeObject<ResponseResult>(PostContent);
            }
            return null;
        }

        private string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        private string Md5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder Str = new StringBuilder();
            foreach (var item in data)
            {
                Str.Append(item.ToString("x2"));
            }
            return Str.ToString();
        }
    }
}
