using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChatSport.Models
{
    public class ResponseResult
    {
        public int code { get; set; }
        public int errcode { get; set; }
        public string msg { get; set; }
        public string messsage { get; set; }
        public string openid { get; set; }
    }
}
