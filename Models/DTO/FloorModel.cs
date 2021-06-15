namespace Surveillance.Models {

    /// <summary>
    /// 樓層
    /// </summary>
    public class FloorModel {

        /// <summary>
        /// 流水編號
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// 層級
        /// </summary>
        public int Level { get; set; } = 0;

        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 圖片
        /// </summary>
        public byte[] Image { get; set; } = null;

        /// <summary>
        /// 圖片類型
        /// </summary>
        /// <remarks>
        /// MIME
        /// </remarks>
        public string ImageType { get; set; } = "";
    }
}