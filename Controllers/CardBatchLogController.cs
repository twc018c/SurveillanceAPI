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
    /// 門鎖批次紀錄
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CardBatchLogController : ControllerBase {

        private readonly ICardBatchLogRepository CardBatchLogRepository;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_CardBatchLogRepository">依賴性注入</param>
        public CardBatchLogController(ICardBatchLogRepository _CardBatchLogRepository) {
            CardBatchLogRepository = _CardBatchLogRepository;
        }


        #region "讀取"

        /// <summary>
        /// 取得門鎖批次紀錄清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("List")]
        [SwaggerRequestExample(typeof(CardBatchLogListEntry), typeof(CardBatchLogListExample))]
        public async Task<Dictionary<string, object>> GetList(CardBatchLogListEntry _Entry) {
            // 取得門鎖批次紀錄清單
            var Temp = await CardBatchLogRepository.GetList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.List);
            Dictionary.Add("resultCount", Temp.Count);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門鎖批次紀錄清單成功");
            
            return Dictionary;
        }

        #endregion

    }
}