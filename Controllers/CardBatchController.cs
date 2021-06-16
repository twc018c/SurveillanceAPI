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
    /// 門卡批次
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CardBatchController : ControllerBase {

        private readonly ICardBatchRepository CardBatchRepository;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_CardBatchRepository">依賴性注入</param>
        public CardBatchController(ICardBatchRepository _CardBatchRepository) {
            CardBatchRepository = _CardBatchRepository;
        }


        #region "讀取"

        /// <summary>
        /// 取得門卡批次清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("List")]
        [SwaggerRequestExample(typeof(CardBatchListEntry), typeof(CardBatchListExample))]
        public async Task<Dictionary<string, object>> GetList(CardBatchListEntry _Entry) {
            // 取得門卡批次清單
            var Temp = await CardBatchRepository.GetList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.List);
            Dictionary.Add("resultCount", Temp.Count);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門卡批次清單成功");
            
            return Dictionary;
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增門卡批次
        /// </summary>
        /// <param name="_List">清單</param>
        [HttpPut()]
        public async Task<Dictionary<string, object>> Set(List<CardBatchModel> _List) {
            var ResultCount = _List.Count;
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "新增門卡批次成功";

            // 新增門卡批次
            await CardBatchRepository.Set(_List);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCount", ResultCount);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "修改"

        /// <summary>
        /// 修改門卡批次
        /// </summary>
        /// <param name="_Model">模型</param>
        [HttpPatch()]
        public async Task<Dictionary<string, object>> Update(CardBatchModel _Model) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "修改門卡批次成功";

            // 修改門卡批次
            await CardBatchRepository.Update(_Model);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除門卡批次 (依門卡編號)
        /// </summary>
        /// <param name="_CardID">門卡編號</param>
        [HttpDelete("Card/{_CardID}")]
        public async Task<Dictionary<string, object>> DeleteByCard(int _CardID = 0) {
            // 刪除門卡批次 (依門卡編號)
            await CardBatchRepository.DeleteByCard(_CardID);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "刪除門卡批次(依門卡編號)成功");

            return Dictionary;
        }


        /// <summary>
        /// 刪除門卡批次 (依持有者編號)
        /// </summary>
        /// <param name="_HolderID">持有者編號</param>
        [HttpDelete("Holder/{_HolderID}")]
        public async Task<Dictionary<string, object>> DeleteByDoor(string _HolderID = "") {
            // 刪除門卡批次 (依持有者編號)
            await CardBatchRepository.DeleteByHolder(_HolderID);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "刪除門卡批次(依持有者編號)成功");

            return Dictionary;
        }

        #endregion




        #region "其它"

        /// <summary>
        /// 檢查門卡批次
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("Check")]
        [SwaggerRequestExample(typeof(CardBatchCheckEntry), typeof(CardBatchCheckExample))]
        public async Task<Dictionary<string, object>> Check(CardBatchCheckEntry _Entry) {
            // 檢查門卡批次
            bool Flag = await CardBatchRepository.CheckAvailable(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Flag);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "檢查門卡批次成功");

            return Dictionary;
        }

        #endregion
    }
}