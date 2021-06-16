using AutoMapper;
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
    /// 樓層
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    public class FloorController : ControllerBase {

        private readonly IFloorRepository FloorRepository;
        private readonly IMapper Mapper;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_FloorRepository">依賴性注入</param>
        /// <param name="_Mapper">模型映射</param>
        public FloorController(IFloorRepository _FloorRepository, IMapper _Mapper) {
            FloorRepository = _FloorRepository;
            Mapper = _Mapper;
        }


        #region "讀取"

        /// <summary>
        /// 取得樓層
        /// </summary>
        /// <param name="_Seq" example="1">流水編號</param>
        [HttpGet("{_Seq}")]
        public async Task<Dictionary<string, object>> Get(int _Seq = 0) {
            // 取得樓層
            var Model = await FloorRepository.Get(_Seq);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Model);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得樓層成功");

            return Dictionary;
        }


        /// <summary>
        /// 取得樓層圖片
        /// </summary>
        /// <param name="_Seq" example="1">流水編號</param>
        [HttpGet("Image/{_Seq}")]
        public async Task<Dictionary<string, object>> GetImage(int _Seq = 0) {
            var ResultCode = API_RESULT_CODE.UNKNOW;
            var ResultMessage = string.Empty;
            var Image = new ImageModel();

            if (_Seq <= 0) {
                ResultCode = API_RESULT_CODE.PARA_ERROR;
                ResultMessage = "取得樓層圖片失敗，缺少參數";
            } else {
                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "取得樓層圖片成功";

                // 取得樓層圖片
                Image = await FloorRepository.GetImage(_Seq);
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Image);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }


        /// <summary>
        /// 取得樓層清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("List")]
        [SwaggerRequestExample(typeof(FloorListEntry), typeof(FloorListExample))]
        public async Task<Dictionary<string, object>> GetList(FloorListEntry _Entry) {
            // 取得樓層清單
            var Temp = await FloorRepository.GetList(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Temp.List);
            Dictionary.Add("resultCount", Temp.Count);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得樓層清單成功");
            
            return Dictionary;
        }


        /// <summary>
        /// 取得樓層選單
        /// </summary>
        [HttpGet("Menu")]
        public async Task<Dictionary<string, object>> GetMenu() {
            // 取得樓層選單
            var List = await FloorRepository.GetMenu();

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", List);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得樓層選單成功");

            return Dictionary;
        }


        /// <summary>
        /// 取得樓層指標
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPost("Cursor")]
        [SwaggerRequestExample(typeof(FloorCursorEntry), typeof(FloorCursorExample))]
        public async Task<Dictionary<string, object>> GetCursor(FloorCursorEntry _Entry) {
            // 取得樓層指標
            int Result = await FloorRepository.GetCursor(_Entry);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Result);
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "取得樓層指標成功");

            return Dictionary;
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增樓層
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPut]
        public async Task<Dictionary<string, object>> Set([FromForm] FloorModifyEntry _Entry) {
            int Seq = 0;
            var ResultCount = 0;
            var ResultCode = API_RESULT_CODE.PARA_ERROR;
            var ResultMessage = "新增樓層失敗，層級重複";

            // 檢查樓層層級
            bool IsExist = await FloorRepository.CheckLevel(_Entry.Level);

            if (IsExist == false) {
                // 模型映射
                var Model = Mapper.Map<FloorModifyEntry, FloorModel>(_Entry);

                if (_Entry.File != null) {
                    MemoryStream MS = new MemoryStream();
                    await _Entry.File.CopyToAsync(MS);
                    Model.Image = MS.ToArray();
                    Model.ImageType = _Entry.File.ContentType;
                }

                // 新增樓層
                await FloorRepository.Set(Model);

                ResultCount = 1;
                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "新增樓層成功";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("result", Seq);
            Dictionary.Add("resultCount", ResultCount);
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "修改"

        /// <summary>
        /// 修改樓層
        /// </summary>
        /// <param name="_Entry">模型</param>
        [HttpPatch]
        public async Task<Dictionary<string, object>> Update([FromForm] FloorModifyEntry _Entry) {
            var ResultCode = API_RESULT_CODE.PARA_ERROR;
            var ResultMessage = "修改樓層失敗，層級不存在";

            // 檢查樓層層級
            bool IsExist = await FloorRepository.CheckLevel(_Entry.Level);

            if (IsExist == true) {
                // 模型映射
                var Model = Mapper.Map<FloorModifyEntry, FloorModel>(_Entry);

                if (_Entry.File != null) {
                    MemoryStream MS = new MemoryStream();
                    await _Entry.File.CopyToAsync(MS);
                    Model.Image = MS.ToArray();
                    Model.ImageType = _Entry.File.ContentType;
                }

                // 修改樓層
                await FloorRepository.Update(Model);

                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "修改樓層成功";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }


        /// <summary>
        /// 修改樓層圖片
        /// </summary>
        /// <param name="Seq">流水編號</param>
        /// <param name="File">檔案</param>
        [HttpPatch("Image")]
        public async Task<Dictionary<string, object>> UpdateImage([FromForm] int Seq, IFormFile File) {
            var ResultCode = API_RESULT_CODE.UNKNOW;
            var ResultMessage = string.Empty;

            if (Seq <= 0 || File == null) {
                ResultCode = API_RESULT_CODE.PARA_ERROR;
                ResultMessage = "修改樓層圖片，缺少參數或檔案";
            } else {
                MemoryStream MS = new MemoryStream();
                await File.CopyToAsync(MS);
                byte[] Image = MS.ToArray();
                string ImageType = File.ContentType;

                // 修改樓層
                await FloorRepository.Update(new FloorModel() {
                    Seq = Seq,
                    Image = Image,
                    ImageType = ImageType
                });

                ResultCode = API_RESULT_CODE.SUCCESS;
                ResultMessage = "修改樓層圖片成功";
            }

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", ResultCode);
            Dictionary.Add("resultMessage", ResultMessage);

            return Dictionary;
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除樓層
        /// </summary>
        /// <param name="_Seq">流水編號</param>
        [HttpDelete("{_Seq}")]
        public async Task<Dictionary<string, object>> Delete(int _Seq = 0) {
            // 刪除樓層
            await FloorRepository.Delete(_Seq);

            var Dictionary = new Dictionary<string, object>();
            Dictionary.Add("resultCode", API_RESULT_CODE.SUCCESS);
            Dictionary.Add("resultMessage", "刪除樓層成功");

            return Dictionary;
        }

        #endregion

    }
}