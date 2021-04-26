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
    /// 使用者
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class UserController : ControllerBase {

        private readonly IJWTService JWTService;
        private readonly IUserRepository UserRepository;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_JWTService">JWT</param>
        /// <param name="_UserRepository">倉儲</param>
        public UserController(IJWTService _JWTService, IUserRepository _UserRepository) {
            JWTService = _JWTService;
            UserRepository = _UserRepository;
        }


        #region "讀取"

        /// <summary>
        /// 取得使用者
        /// </summary>
        /// <param name="_Account" example="fish">帳號</param>
        [HttpGet("{_Account}")]
        public async Task<Dictionary<string, object>> Get(string _Account = "") {
            // 取得使用者
            var Model = await UserRepository.Get(_Account);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Model);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得使用者成功");

            return Dictionary;
        }


        /// <summary>
        /// 取得使用者清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("List")]
        [SwaggerRequestExample(typeof(UserEntry), typeof(UserExample))]
        public async Task<Dictionary<string, object>> GetList(UserEntry _Entry) {
            // 取得使用者清單
            var Temp = await UserRepository.GetList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.List);
            Dictionary.Add("resultCount", Temp.Count);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得使用者清單成功");
            
            return Dictionary;
        }


        /// <summary>
        /// 取得使用者選單
        /// </summary>
        [HttpGet("Menu")]
        public async Task<Dictionary<string, object>> GetMenu() {
            // 取得使用者選單
            var List = await UserRepository.GetMenu();

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", List);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得使用者選單成功");

            return Dictionary;
        }


        /// <summary>
        /// 取得使用者指標
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("Cursor")]
        [SwaggerRequestExample(typeof(UserCursorEntry), typeof(UserCursorExample))]
        public async Task<Dictionary<string, object>> GetCursor(UserCursorEntry _Entry) {
            // 取得使用者指標
            string Result = await UserRepository.GetCursor(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Result);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得使用者指標成功");

            return Dictionary;
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="_Model">模型</param>
        [HttpPut("Set")]
        public async Task<Dictionary<string, object>> Set(UserModel _Model) {
            var ResultCount = 0;
            var ResultCode = API_RESULT_CODE.PARA_ERROR;
            var ResultMessage = "新增使用者失敗";

            // TODO - 權限認證

            // 檢查使用者帳號
            bool IsExist = await UserRepository.CheckAccount(_Model.Account);

            if (IsExist == false) {
                // 新增使用者
                await UserRepository.Set(_Model);

                ResultCount = 1;
                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "新增使用者成功";
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
        /// 修改使用者
        /// </summary>
        /// <param name="_Model">模型</param>
        [HttpPatch("Update")]
        public async Task<Dictionary<string, object>> Update(UserModel _Model) {
            var ResultCode = API_RESULT_CODE.PARA_ERROR;
            var ResultMessage = "修改使用者失敗";

            // TODO - 權限認證

            // 檢查使用者帳號
            bool IsExist = await UserRepository.CheckAccount(_Model.Account);

            if (IsExist == true) {
                // 修改使用者
                await UserRepository.Update(_Model);

                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "修改使用者成功";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }


        /// <summary>
        /// 修改使用者密碼
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPatch("Update/Password")]
        public async Task<Dictionary<string, object>> UpdatePassword(UserPasswordEntry _Entry) {
            var ResultCode = API_RESULT_CODE.PARA_ERROR;
            var ResultMessage = "修改使用者密碼失敗";

            // 檢查使用者帳號
            bool IsExist = await UserRepository.CheckAccount(_Entry.Account);

            if (IsExist == true) {
                // 修改使用者密碼
                await UserRepository.UpdatePassword(_Entry);

                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "修改使用者密碼成功";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="_Account">帳號</param>
        [HttpDelete("{_Account}")]
        public async Task<Dictionary<string, object>> Delete(string _Account = "") {
            // TODO - 權限認證

            // 刪除使用者
            await UserRepository.Delete(_Account);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "刪除使用者成功");

            return Dictionary;
        }

        #endregion




        #region "其它"

        /// <summary>
        /// 使用者登入
        /// </summary>
        /// <param name="_Entry">模型</param>
        [AllowAnonymous]
        [HttpPost("Login")]
        [SwaggerRequestExample(typeof(UserLoginEntry), typeof(UserLoginExample))]
        public async Task<Dictionary<string, object>> Login(UserLoginEntry _Entry) {
            UserModel Model = null;
            string Token = string.Empty;
            
            var ResultCode = API_RESULT_CODE.DB_ERROR;
            var ResultMessage = "使用者登入失敗";

            // 使用者登入
            var Tuple = await UserRepository.Login(_Entry);

            if (Tuple.Flag == true) {
                // 使用者模型
                Model = Tuple.Model;

                // 產生權杖
                Token = JWTService.GenerateToken(_Entry.Account);

                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "使用者登入成功";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("model", Model);
            Dictionary.Add("token", Token);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion
    }
}