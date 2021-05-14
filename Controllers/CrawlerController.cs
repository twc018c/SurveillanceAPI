using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Surveillance.Enums;
using Surveillance.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Controllers {

    /// <summary>
    /// 爬蟲
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CrawlerController : ControllerBase {

        private readonly ICrawlerService CrawlerService;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_CrawlerService">依賴性注入</param>
        public CrawlerController(ICrawlerService _CrawlerService) {
            CrawlerService = _CrawlerService;
        }


        /// <summary>
        /// 執行門鎖清單爬蟲
        /// </summary>
        [HttpPost("ExecuteLockList")]
        public async Task<Dictionary<string, object>> ExecuteLockList() {
            // 執行門鎖清單爬蟲
            var Temp = await CrawlerService.ExecuteLockList();

            string Message = $"執行門鎖清單爬蟲成功，新增{Temp.CountAdd}筆，刪除{Temp.CountDelete}筆，更新{Temp.CountUpdate}筆";

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", Message);

            return Dictionary;
        }
    }
}