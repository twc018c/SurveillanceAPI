using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Surveillance.Enums;
using Surveillance.Examples;
using Surveillance.Interfaces;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Controllers {

    /// <summary>
    /// Sciener
    /// </summary>
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ScienerController : ControllerBase {

        private readonly IScienerService ScienerService;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_ScienerService">服務</param>
        public ScienerController(IScienerService _ScienerService) {
            ScienerService = _ScienerService;
        }


        #region "令牌"

        /// <summary>
        /// 取得令牌
        /// </summary>
        [HttpGet("Token")]
        public async Task<Dictionary<string, object>> GetToken() {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "取得令牌成功";

            // 取得令牌
            var Temp = await ScienerService.GetToken();

            if (string.IsNullOrEmpty(Temp.AccessToken) || Temp.UID == 0) {
                ResultCode = API_RESULT_CODE.UNKNOW;
                ResultMessage = "取得令牌錯誤";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);
            
            return Dictionary;
        }

        #endregion

    }
}