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
        /// <param name="_UIService">JWT</param>
        public UIController(IUIService _UIService) {
            UIService = _UIService;
        }


        /// <summary>
        /// 樓層
        /// </summary>
        [HttpGet]
        public async Task<Dictionary<string, object>> GetFloor() {
            // 樓層
            var List = UIService.GetFloor();

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", List);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得樓層成功");

            return Dictionary;
        }
    }
}