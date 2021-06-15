using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// 圖片
    /// </summary>
    public class ImageModel {

        /// <summary>
        /// 內容
        /// </summary>
        [JsonPropertyName("image")]
        public byte[] Image { get; set; } = null;

        /// <summary>
        /// 類型
        /// </summary>
        [JsonPropertyName("imageType")]
        public string ImageType { get; set; } = "";

        /// <summary>
        /// 寬度
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; } = 0;

        /// <summary>
        /// 高度
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; } = 0;
    }
}