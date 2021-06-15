using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// �Ϥ�
    /// </summary>
    public class ImageModel {

        /// <summary>
        /// ���e
        /// </summary>
        [JsonPropertyName("image")]
        public byte[] Image { get; set; } = null;

        /// <summary>
        /// ����
        /// </summary>
        [JsonPropertyName("imageType")]
        public string ImageType { get; set; } = "";

        /// <summary>
        /// �e��
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; } = 0;

        /// <summary>
        /// ����
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; } = 0;
    }
}