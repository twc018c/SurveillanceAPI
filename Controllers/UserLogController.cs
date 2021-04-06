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
    public class UserLogController : ControllerBase {

        private readonly IUserLogRepository UserLogRepository;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_UserLogRepository">倉儲</param>
        public UserLogController(IUserLogRepository _UserLogRepository) {
            UserLogRepository = _UserLogRepository;
        }


        #region "讀取"

        /// <summary>
        /// 取得使用者紀錄清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("List")]
        [SwaggerRequestExample(typeof(UserLogEntry), typeof(UserLogExample))]
        public async Task<Dictionary<string, object>> GetList(UserLogEntry _Entry) {
            // 取得使用者紀錄清單
            var Temp = await UserLogRepository.GetList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.List);
            Dictionary.Add("resultCount", Temp.Count);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得使用者紀錄清單成功");
            
            return Dictionary;
        }

        #endregion

    }
}