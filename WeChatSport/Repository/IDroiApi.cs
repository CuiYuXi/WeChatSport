using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatSport.Models;

namespace WeChatSport.Repository
{
    public interface IDroiApi
    {
        ResponseResult SetStep(string accountId, string opid, int jibuNuber);
        ResponseResult GetOpenId(string accountId);
    }
}
