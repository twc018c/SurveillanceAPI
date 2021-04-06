using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Surveillance.Enums;
using Surveillance.Examples;
using Surveillance.Interfaces;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
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
            var Temp = await UserRepository.Get(_Account);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
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
        [HttpPost("Update")]
        public async Task<Dictionary<string, object>> Update(UserModel _Model) {
            var ResultCode = API_RESULT_CODE.PARA_ERROR;
            var ResultMessage = "修改使用者失敗";

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

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="_Account">帳號</param>
        [HttpDelete("{_Account}")]
        public async Task<Dictionary<string, object>> Delete(string _Account = "") {
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
            string Token = string.Empty;
            var ResultCode = API_RESULT_CODE.DB_ERROR;
            var ResultMessage = "使用者登入失敗";

            // 使用者登入
            bool Flag = await UserRepository.Login(_Entry);

            if (Flag == true) {
                // 產生權杖
                Token = this.JWTService.GenerateToken(_Entry.Account);

                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "使用者登入成功";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Token);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion
    }
}