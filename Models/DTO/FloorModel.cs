namespace Surveillance.Models {

    /// <summary>
    /// �Ӽh
    /// </summary>
    public class FloorModel {

        /// <summary>
        /// �y���s��
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// �h��
        /// </summary>
        public int Level { get; set; } = 0;

        /// <summary>
        /// �W��
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// �Ϥ�
        /// </summary>
        public byte[] Image { get; set; } = null;

        /// <summary>
        /// �Ϥ�����
        /// </summary>
        /// <remarks>
        /// MIME
        /// </remarks>
        public string ImageType { get; set; } = "";
    }
}