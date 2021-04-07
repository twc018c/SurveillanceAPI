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
    /// 使用者紀錄
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class EventLogController : ControllerBase {

        private readonly IEventLogRepository EventLogRepository;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_EventLogRepository">倉儲</param>
        public EventLogController(IEventLogRepository _EventLogRepository) {
            EventLogRepository = _EventLogRepository;
        }


        #region "讀取"

        /// <summary>
        /// 取得事件紀錄清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("List")]
        [SwaggerRequestExample(typeof(EventLogEntry), typeof(EventLogExample))]
        public async Task<Dictionary<string, object>> GetList(EventLogEntry _Entry) {
            // 取得事件紀錄清單
            var Temp = await EventLogRepository.GetList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.List);
            Dictionary.Add("resultCount", Temp.Count);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得事件紀錄清單成功");
            
            return Dictionary;
        }

        #endregion

    }
}