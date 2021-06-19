using Microsoft.AspNetCore.Http;


namespace Surveillance.Models {

    /// <summary>
    /// 樓層異動 (新增/修改)
    /// </summary>
    public class FloorModifyEntry : FloorModel {

        /// <summary>
        /// 檔案
        /// </summary>
        public IFormFile File { get; set; } = null;
    }
}