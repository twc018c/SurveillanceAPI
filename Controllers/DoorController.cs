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
    /// 門鎖
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class DoorController : ControllerBase {

        private readonly IDoorRepository DoorRepository;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_DoorRepository">倉儲</param>
        public DoorController(IDoorRepository _DoorRepository) {
            DoorRepository = _DoorRepository;
        }


        #region "讀取"

        /// <summary>
        /// 取得門鎖清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("List")]
        [SwaggerRequestExample(typeof(DoorEntry), typeof(DoorExample))]
        public async Task<Dictionary<string, object>> GetList(DoorEntry _Entry) {
            // 取得門鎖清單
            var Temp = await DoorRepository.GetList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.List);
            Dictionary.Add("resultCount", Temp.Count);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門鎖清單成功");
            
            return Dictionary;
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增門鎖
        /// </summary>
        /// <param name="_Model">模型</param>
        [HttpPut()]
        public async Task<Dictionary<string, object>> Set(DoorModel _Model) {
            var ResultCount = 0;
            var ResultCode = API_RESULT_CODE.PARA_ERROR;
            var ResultMessage = "新增門鎖失敗";

            // 檢查門鎖編號
            bool IsExist = await DoorRepository.CheckID(_Model.ID);

            if (IsExist == false) {
                // 新增門鎖
                await DoorRepository.Set(_Model);

                ResultCount = 1;
                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "新增門鎖成功";
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
        /// 修改門鎖
        /// </summary>
        /// <param name="_Model">模型</param>
        [HttpPatch()]
        public async Task<Dictionary<string, object>> Update(DoorModel _Model) {
            var ResultCode = API_RESULT_CODE.PARA_ERROR;
            var ResultMessage = "修改門鎖失敗";

            // 檢查門鎖編號
            bool IsExist = await DoorRepository.CheckID(_Model.ID);

            if (IsExist == true) {
                // 修改門鎖
                await DoorRepository.Update(_Model);

                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "修改門鎖成功";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除門鎖
        /// </summary>
        /// <param name="_ID">門鎖編號</param>
        [HttpDelete("{_ID}")]
        public async Task<Dictionary<string, object>> Delete(int _ID = 0) {
            // 刪除門鎖
            await DoorRepository.Delete(_ID);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "刪除門鎖成功");

            return Dictionary;
        }

        #endregion

    }
}