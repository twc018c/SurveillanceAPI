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
        /// <param name="_DoorRepository">依賴性注入</param>
        public DoorController(IDoorRepository _DoorRepository) {
            DoorRepository = _DoorRepository;
        }


        #region "讀取"

        /// <summary>
        /// 取得門鎖
        /// </summary>
        /// <param name="_Seq" example="1">流水編號</param>
        [HttpGet("{_Seq}")]
        public async Task<Dictionary<string, object>> Get(int _Seq = 0) {
            // 取得門鎖
            var Model = await DoorRepository.Get(_Seq);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Model);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門鎖成功");

            return Dictionary;
        }


        /// <summary>
        /// 取得門鎖清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("List")]
        [SwaggerRequestExample(typeof(DoorListEntry), typeof(DoorListExample))]
        public async Task<Dictionary<string, object>> GetList(DoorListEntry _Entry) {
            // 取得門鎖清單
            var Temp = await DoorRepository.GetList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.List);
            Dictionary.Add("resultCount", Temp.Count);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門鎖清單成功");
            
            return Dictionary;
        }


        /// <summary>
        /// 取得門鎖拖曳清單
        /// </summary>
        /// <param name="_FloorLevel">樓層層級</param>
        [HttpGet("List/Drag/{_FloorLevel}")]
        public async Task<Dictionary<string, object>> GetDragList(int _FloorLevel = 0) {
            // 取得門鎖拖曳清單
            var Temp = await DoorRepository.GetDragList(_FloorLevel);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp);
            Dictionary.Add("resultCount", Temp.Count);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門鎖拖曳清單成功");

            return Dictionary;
        }


        /// <summary>
        /// 取得門鎖指標
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("Cursor")]
        [SwaggerRequestExample(typeof(DoorCursorEntry), typeof(DoorCursorExample))]
        public async Task<Dictionary<string, object>> GetCursor(DoorCursorEntry _Entry) {
            // 取得門鎖指標
            int Result = await DoorRepository.GetCursor(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Result);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得門鎖指標成功");

            return Dictionary;
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增門鎖
        /// </summary>
        /// <param name="_Model">模型</param>
        [HttpPut]
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
        [HttpPatch]
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


        /// <summary>
        /// 拖曳門鎖
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPatch("Drag")]
        [SwaggerRequestExample(typeof(DoorDragEntry), typeof(DoorDragExample))]
        public async Task<Dictionary<string, object>> Drag(DoorDragEntry _Entry) {
            var ResultCode = API_RESULT_CODE.PARA_ERROR;
            var ResultMessage = "拖曳門鎖失敗";

            // 檢查門鎖編號
            bool IsExist = await DoorRepository.CheckID(_Entry.ID);

            if (IsExist == true) {
                // 拖曳門鎖
                await DoorRepository.Drag(_Entry);

                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "拖曳門鎖成功";
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