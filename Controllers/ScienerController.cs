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
            // 取得令牌
            var Temp = await ScienerService.GetToken();

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "");
            
            return Dictionary;
        }

        #endregion

    }
}