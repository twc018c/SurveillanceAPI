using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Surveillance.Enums;
using Surveillance.Examples;
using Surveillance.Interfaces;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using System.IO;
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
        /// 取得門卡批次
        /// </summary>
        /// <param name="_Seq" example="1">流水編號</param>
        [HttpGet("{_Seq}")]
        public async Task<Dictionary<string, object>> Get(int _Seq = 0) {
            // 取得門卡批次
            var Model = await CardBatchRepository.Get(_Seq);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Model);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門卡批次成功");

            return Dictionary;
        }


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


        /// <summary>
        /// 取得門卡批次指標
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("Cursor")]
        [SwaggerRequestExample(typeof(CardBatchCursorEntry), typeof(CardBatchCursorExample))]
        public async Task<Dictionary<string, object>> GetCursor(CardBatchCursorEntry _Entry) {
            // 取得門卡批次指標
            int Result = await CardBatchRepository.GetCursor(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Result);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門卡批次指標成功");

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
        /// 刪除門卡批次 (依流水編號)
        /// </summary>
        /// <param name="_Seq">流水編號</param>
        [HttpDelete("Card/{_Seq}")]
        public async Task<Dictionary<string, object>> DeleteBySeq(int _Seq = 0) {
            // 刪除門卡批次 (依流水編號)
            await CardBatchRepository.DeleteByCard(_Seq);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "刪除門卡批次(依流水編號)成功");

            return Dictionary;
        }


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


        /// <summary>
        /// 上傳門卡批次
        /// </summary>
        /// <param name="_File">檔案</param>
        [HttpPatch("Import")]
        public async Task<Dictionary<string, object>> Import([FromForm] IFormFile _File) {
            var ResultCode = API_RESULT_CODE.UNKNOW;
            var ResultMessage = string.Empty;

            if (_File == null || _File.FileName.EndsWith(".csv") == false) {
                ResultCode = API_RESULT_CODE.PARA_ERROR;
                ResultMessage = "上傳門卡批次失敗，缺少檔案或檔案格式不符合";
            } else {
                Stream Stream = _File.OpenReadStream();

                // 匯入門卡批次
                await CardBatchRepository.Import(Stream, _File.ContentType);

                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "上傳門卡批次成功";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion
    }
}