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
    /// UI
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class UIController : ControllerBase {

        private readonly IUIService UIService;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_UIService">注入服務</param>
        public UIController(IUIService _UIService) {
            UIService = _UIService;
        }


        /// <summary>
        /// 取得電量
        /// </summary>
        [HttpGet("Power")]
        public async Task<Dictionary<string, object>> GetPower() {
            // 取得電量
            var List = UIService.GetPower();

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", List);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得電量成功");

            return Dictionary;
        }
    }
}