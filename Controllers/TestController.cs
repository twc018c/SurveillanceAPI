using Microsoft.AspNetCore.Mvc;
using Surveillance.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Controllers {

    /// <summary>
    /// 測試
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class TestController : ControllerBase {

        /// <summary>
        /// 建構
        /// </summary>
        public TestController() {
            // NOTHING
        }


        #region "讀取"

        /// <summary>
        /// 測試
        /// </summary>
        [HttpGet]
        public async Task<Dictionary<string, object>> Get() {
            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "測試成功");

            await Task.CompletedTask;

            return Dictionary;
        }

        #endregion

    }
}