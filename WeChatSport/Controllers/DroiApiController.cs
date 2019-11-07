using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeChatSport.Models;
using WeChatSport.Repository;

namespace WeChatSport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroiApiController : ControllerBase
    {
        private IDroiApi _droiApi;

        public DroiApiController(IDroiApi droiApi)
        {
            _droiApi = droiApi;
        }

        [HttpGet("{accountId}/{jibuNuber}")]
        public ActionResult Get(string accountId,int jibuNuber)
        {
            ResponseResult optResult=new ResponseResult ();
            try
            {
                if (!string.IsNullOrEmpty(accountId)&&jibuNuber>0)
                {
                    ResponseResult GetOpenId = _droiApi.GetOpenId(accountId);
                    if (GetOpenId.code == 0)
                    {
                        return Content(JsonConvert.SerializeObject(_droiApi.SetStep(accountId, GetOpenId.openid,jibuNuber)));
                    }
                    else
                    {
                        return Content(JsonConvert.SerializeObject(GetOpenId));
                    }
                }
                else
                {
                    optResult.code = 0;
                    optResult.messsage = "参数错误";
                }
            }
            catch (Exception e)
            {
                optResult.code = 0;
                optResult.messsage = e.Message;
            }

            return Content(JsonConvert.SerializeObject(optResult));
        }
    }
}