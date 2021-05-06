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
    /// 門卡
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CardController : ControllerBase {

        private readonly ICardRepository CardRepository;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_CardRepository">倉儲</param>
        public CardController(ICardRepository _CardRepository) {
            CardRepository = _CardRepository;
        }


        #region "讀取"

        /// <summary>
        /// 取得門卡
        /// </summary>
        /// <param name="_Seq" example="1">流水編號</param>
        [HttpGet("{_Seq}")]
        public async Task<Dictionary<string, object>> Get(int _Seq = 0) {
            // 取得門卡
            var Model = await CardRepository.Get(_Seq);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Model);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門卡成功");

            return Dictionary;
        }


        /// <summary>
        /// 取得門卡清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("List")]
        [SwaggerRequestExample(typeof(CardEntry), typeof(CardExample))]
        public async Task<Dictionary<string, object>> GetList(CardEntry _Entry) {
            // 取得門卡清單
            var Temp = await CardRepository.GetList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.List);
            Dictionary.Add("resultCount", Temp.Count);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門卡清單成功");
            
            return Dictionary;
        }


        /// <summary>
        /// 取得門卡指標
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("Cursor")]
        [SwaggerRequestExample(typeof(CardCursorEntry), typeof(CardCursorExample))]
        public async Task<Dictionary<string, object>> GetCursor(CardCursorEntry _Entry) {
            // 取得門卡指標
            int Result = await CardRepository.GetCursor(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Result);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門卡指標成功");

            return Dictionary;
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增門卡
        /// </summary>
        /// <param name="_Model">模型</param>
        [HttpPut]
        public async Task<Dictionary<string, object>> Set(CardModel _Model) {
            var ResultCount = 0;
            var ResultCode = API_RESULT_CODE.PARA_ERROR;
            var ResultMessage = "新增門卡失敗";

            // 檢查門卡編號
            bool IsExist = await CardRepository.CheckID(_Model.ID);

            if (IsExist == false) {
                // 新增門卡
                await CardRepository.Set(_Model);

                ResultCount = 1;
                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "新增門卡成功";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCount", ResultCount);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "修改"

        /// <summary>
        /// 修改門卡
        /// </summary>
        /// <param name="_Model">模型</param>
        [HttpPatch]
        public async Task<Dictionary<string, object>> Update(CardModel _Model) {
            var ResultCode = API_RESULT_CODE.PARA_ERROR;
            var ResultMessage = "修改門卡失敗";

            // 檢查門卡編號
            bool IsExist = await CardRepository.CheckID(_Model.ID);

            if (IsExist == true) {
                // 修改門卡
                await CardRepository.Update(_Model);

                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "修改門卡成功";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除門卡
        /// </summary>
        /// <param name="_ID">門卡編號</param>
        [HttpDelete("{_ID}")]
        public async Task<Dictionary<string, object>> Delete(int _ID = 0) {
            // 刪除門卡
            await CardRepository.Delete(_ID);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "刪除門卡成功");

            return Dictionary;
        }

        #endregion

    }
}