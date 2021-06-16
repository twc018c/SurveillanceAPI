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
    /// 門卡權限
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CardAuthorityController : ControllerBase {

        private readonly ICardAuthorityRepository CardAuthorityRepository;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_CardAuthorityRepository">依賴性注入</param>
        public CardAuthorityController(ICardAuthorityRepository _CardAuthorityRepository) {
            CardAuthorityRepository = _CardAuthorityRepository;
        }


        #region "讀取"

        /// <summary>
        /// 取得門卡權限清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("List")]
        [SwaggerRequestExample(typeof(CardAuthorityListEntry), typeof(CardAuthorityListExample))]
        public async Task<Dictionary<string, object>> GetList(CardAuthorityListEntry _Entry) {
            // 取得門卡權限清單
            var Temp = await CardAuthorityRepository.GetList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.List);
            Dictionary.Add("resultCount", Temp.Count);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門卡權限清單成功");
            
            return Dictionary;
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增門卡權限
        /// </summary>
        /// <param name="_List">清單</param>
        [HttpPut()]
        public async Task<Dictionary<string, object>> Set(List<CardAuthorityModel> _List) {
            var ResultCount = _List.Count;
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "新增門卡權限成功";

            // 新增門卡權限
            await CardAuthorityRepository.Set(_List);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCount", ResultCount);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除門卡權限 (依門卡編號)
        /// </summary>
        /// <param name="_CardID">門卡編號</param>
        [HttpDelete("Card/{_CardID}")]
        public async Task<Dictionary<string, object>> DeleteByCard(int _CardID = 0) {
            // 刪除門卡權限 (依門卡編號)
            await CardAuthorityRepository.DeleteByCard(_CardID);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "刪除門卡權限(依門卡編號)成功");

            return Dictionary;
        }


        /// <summary>
        /// 刪除門卡權限 (依門鎖編號)
        /// </summary>
        /// <param name="_DoorID">門鎖編號</param>
        [HttpDelete("Door/{_DoorID}")]
        public async Task<Dictionary<string, object>> DeleteByDoor(int _DoorID = 0) {
            // 刪除門卡權限 (依門鎖編號)
            await CardAuthorityRepository.DeleteByDoor(_DoorID);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "刪除門卡權限(依門鎖編號)成功");

            return Dictionary;
        }

        #endregion




        #region "其它"

        /// <summary>
        /// 檢查門卡權限
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("Check")]
        [SwaggerRequestExample(typeof(CardAuthorityCheckEntry), typeof(CardAuthorityChechExample))]
        public async Task<Dictionary<string, object>> Check(CardAuthorityCheckEntry _Entry) {
            // 檢查門卡權限
            bool Flag = await CardAuthorityRepository.Check(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Flag);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "檢查門卡權限成功");

            return Dictionary;
        }

        #endregion
    }
}