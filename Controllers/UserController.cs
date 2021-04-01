using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Surveillance.Enums;
using Surveillance.Examples;
using Surveillance.Interfaces;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;


namespace Surveillance.Controllers {

    /// <summary>
    /// 使用者
    /// </summary>
    [ApiController]
    //[Authorize]
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
        public async Task<APIModel> Get(string _Account = "") {
            // 取得使用者
            var Temp = await UserRepository.Get(_Account);

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var APIModel = new APIModel() {
                Result = Temp,
                ResultCount = 1,
                ResultCode = API_RESULT_CODE.SUCCESS,
                //ResultMessage = "取得使用者成功",
                ResultMessage = accessToken,
            };

            return APIModel;
        }


        /// <summary>
        /// 取得使用者清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("List")]
        [SwaggerRequestExample(typeof(UserEntry), typeof(UserExample))]
        public async Task<APIModel> GetList(UserEntry _Entry) {
            // 取得使用者清單
            var Temp = await UserRepository.GetList(_Entry);

            var APIModel = new APIModel() {
                Result = Temp.List,
                ResultCount = Temp.Count,
                ResultCode = API_RESULT_CODE.SUCCESS,
                ResultMessage = "取得使用者清單成功",
            };

            return APIModel;
        }

        #endregion




        #region "新增"

        #endregion




        #region "修改"

        #endregion




        #region "刪除"

        #endregion




        #region "其它"

        /// <summary>
        /// 使用者登入
        /// </summary>
        /// <param name="_Entry">模型</param>
        [AllowAnonymous]
        [HttpPost("Login")]
        [SwaggerRequestExample(typeof(UserLoginEntry), typeof(UserLoginExample))]
        public async Task<APIModel> Login(UserLoginEntry _Entry) {
            string Token = string.Empty;
            int ResultCount = 0;
            var ResultCode = API_RESULT_CODE.DB_ERROR;
            var ResultMessage = "使用者登入失敗";

            // 使用者登入
            bool Flag = await UserRepository.Login(_Entry);

            if (Flag == true) {
                // 產生權杖
                Token = this.JWTService.GenerateToken(_Entry.Account);

                ResultCount = 1;
                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "使用者登入成功";
            }

            var APIModel = new APIModel() {
                Result = Token,
                ResultCount = ResultCount,
                ResultCode = ResultCode,
                ResultMessage = ResultMessage,
            };

            return APIModel;
        }

        #endregion
    }
}