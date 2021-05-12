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
    /// Sciener
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ScienerController : ControllerBase {

        private readonly IScienerService ScienerService;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_ScienerService">依賴性注入</param>
        public ScienerController(IScienerService _ScienerService) {
            ScienerService = _ScienerService;
        }


        #region "令牌"

        /// <summary>
        /// 取得令牌
        /// </summary>
        [HttpGet("Token")]
        public async Task<Dictionary<string, object>> GetToken() {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "取得令牌成功";

            // 取得令牌
            var Temp = await ScienerService.GetToken();

            if (string.IsNullOrEmpty(Temp.AccessToken) || Temp.UID == 0) {
                ResultCode = API_RESULT_CODE.UNKNOW;
                ResultMessage = "取得令牌錯誤";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);
            
            return Dictionary;
        }

        #endregion




        #region "用戶"

        /// <summary>
        /// 用戶註冊
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("User/Register")]
        [SwaggerRequestExample(typeof(ScienerUserRegisterEntry), typeof(SicenerUserRegisterExample))]
        public async Task<Dictionary<string, object>> RegisterUser(ScienerUserRegisterEntry _Entry) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "用戶註冊成功";

            // 用戶註冊
            var Temp = await ScienerService.RegisterUser(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }


        /// <summary>
        /// 取得用戶清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("User/List")]
        [SwaggerRequestExample(typeof(ScienerUserListEntry), typeof(SicenerUserExample))]
        public async Task<Dictionary<string, object>> GetUserList(ScienerUserListEntry _Entry) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "取得用戶清單成功";

            // 取得用戶清單
            var Temp = await ScienerService.GetUserList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "鎖"

        /// <summary>
        /// 取得鎖時間
        /// </summary>
        /// <param name="_LockID" example="2746218">鎖編號</param>
        [HttpPost("Lock/Date/{_LockID}")]
        public async Task<Dictionary<string, object>> GetLockDate(int _LockID) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "取得鎖時間成功";

            // 取得鎖時間
            var Temp = await ScienerService.GetLockDate(_LockID);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.Date);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }


        /// <summary>
        /// 取得鎖電量
        /// </summary>
        /// <param name="_LockID" example="2746218">鎖編號</param>
        [HttpPost("Lock/ElectricQuantity/{_LockID}")]
        public async Task<Dictionary<string, object>> GetLockElectricQuantity(int _LockID) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "取得鎖電量成功";

            // 取得鎖電量
            var Temp = await ScienerService.GetLockElectricQuantity(_LockID);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.ElectricQuantity);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }


        /// <summary>
        /// 取得鎖狀態
        /// </summary>
        /// <param name="_LockID" example="2746218">鎖編號</param>
        [HttpPost("Lock/State/{_LockID}")]
        public async Task<Dictionary<string, object>> GetLockState(int _LockID) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "取得鎖狀態成功";

            // 取得鎖狀態
            var Temp = await ScienerService.GetLockState(_LockID);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.State);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }


        /// <summary>
        /// 開鎖
        /// </summary>
        /// <param name="_LockID" example="2746218">鎖編號</param>
        [HttpPost("Lock/Open/{_LockID}")]
        public async Task<Dictionary<string, object>> LockOpen(int _LockID) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "開鎖成功";

            // 開鎖
            var Temp = await ScienerService.LockOpen(_LockID);

            if (Temp.Errcode != SCIENER_CODE.SUCCESS) {
                ResultCode = API_RESULT_CODE.UNKNOW;
                ResultMessage = $"{Temp.Errcode} {Temp.Errmsg} {Temp.Description}";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }


        /// <summary>
        /// 閉鎖
        /// </summary>
        /// <param name="_LockID" example="2746218">鎖編號</param>
        [HttpPost("Lock/Close/{_LockID}")]
        public async Task<Dictionary<string, object>> LockClose(int _LockID) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "閉鎖成功";

            // 閉鎖
            var Temp = await ScienerService.LockClose(_LockID);

            if (Temp.Errcode != SCIENER_CODE.SUCCESS) {
                ResultCode = API_RESULT_CODE.UNKNOW;
                ResultMessage = $"{Temp.Errcode} {Temp.Errmsg} {Temp.Description}";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }


        /// <summary>
        /// 取得鎖內容
        /// </summary>
        /// <param name="_LockID" example="2746218">鎖編號</param>
        [HttpPost("Lock/Detail/{_LockID}")]
        public async Task<Dictionary<string, object>> GetLockDetail(int _LockID) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "取得鎖內容成功";

            // 取得鎖內容
            var Temp = await ScienerService.GetLockDetail(_LockID);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }


        /// <summary>
        /// 取得鎖清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("Lock/List")]
        [SwaggerRequestExample(typeof(ScienerLockListEntry), typeof(SicenerLockListExample))]
        public async Task<Dictionary<string, object>> GetLockList(ScienerLockListEntry _Entry) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "取得鎖清單成功";

            // 取得鎖清單
            var Temp = await ScienerService.GetLockList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "鎖紀錄"

        /// <summary>
        /// 取得鎖紀錄
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("LockRecord/List")]
        [SwaggerRequestExample(typeof(ScienerLockRecordListEntry), typeof(SicenerLockRecordListExample))]
        public async Task<Dictionary<string, object>> GetLockRecordList(ScienerLockRecordListEntry _Entry) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "取得鎖紀錄成功";

            // 取得鎖紀錄
            var Temp = await ScienerService.GetLockRecordList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "鑰匙"

        /// <summary>
        /// 取得鑰匙內容
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("Key/Detail")]
        [SwaggerRequestExample(typeof(ScienerKeyDetailEntry), typeof(SicenerKeyDetailExample))]
        public async Task<Dictionary<string, object>> GetKeyDetail(ScienerKeyDetailEntry _Entry) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "取得鑰匙內容成功";

            // 取得鑰匙內容
            var Temp = await ScienerService.GetKeyDetail(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }


        /// <summary>
        /// 取得鑰匙清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("Key/List")]
        [SwaggerRequestExample(typeof(ScienerKeyListEntry), typeof(SicenerKeyListExample))]
        public async Task<Dictionary<string, object>> GetKeyList(ScienerKeyListEntry _Entry) {
            var ResultCode = API_RESULT_CODE.SUCCESS;
            var ResultMessage = "取得鑰匙清單成功";

            // 取得鑰匙清單
            var Temp = await ScienerService.GetKeyList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion

    }
}