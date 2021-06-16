using Microsoft.AspNetCore.Http;


namespace Surveillance.Models {

    /// <summary>
    /// 樓層清單
    /// </summary>
    public class FloorListEntry : Entry {

        /// <summary>
        /// 關鍵字
        /// </summary>
        public string Keyword { get; set; } = "";

        /// <summary>
        /// 層級
        /// </summary>
        public int Level { get; set; } = 0;

        /// <summary>
        /// 圖片旗標
        /// </summary>
        public bool FlagImage { get; set; } = false;
    }


    /// <summary>
    /// 樓層異動 (新增/修改)
    /// </summary>
    public class FloorModifyEntry : FloorModel {

        /// <summary>
        /// 檔案
        /// </summary>
        public IFormFile File { get; set; } = null;
    }


    /// <summary>
    /// 樓層指標
    /// </summary>
    public class FloorCursorEntry {

        /// <summary>
        /// 流水編號
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// 方向
        /// </summary>
        /// <remarks>true=往下、false=往上</remarks>
        public bool Direction { get; set; } = true;
    }
}