using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Surveillance.Enums;
using Surveillance.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Controllers {

    /// <summary>
    /// 儀錶板
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class DashboardController : ControllerBase {

        private readonly IDashboardService DashboardService;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_DashboardService">服務</param>
        public DashboardController(IDashboardService _DashboardService) {
            DashboardService = _DashboardService;
        }


        #region "讀取"

        /// <summary>
        /// 取得儀錶板首頁
        /// </summary>
        [HttpGet("Home")]
        public async Task<Dictionary<string, object>> GetHome() {
            // 取得儀錶板首頁
            var Temp = await DashboardService.GetHome();

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得儀錶板首頁成功");
            
            return Dictionary;
        }

        #endregion

    }
}