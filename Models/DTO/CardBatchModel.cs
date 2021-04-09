using System;


namespace Surveillance.Models {

    /// <summary>
    /// ���d�妸
    /// </summary>
    public class CardBatchModel {

        /// <summary>
        /// �y���s��
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// ���d�s��
        /// </summary>
        public int CardID { get; set; } = 0;

        /// <summary>
        /// �����̽s��
        /// </summary>
        /// <remarks>�~���t��</remarks>
        public string HolderID { get; set; } = "";

        /// <summary>
        /// �����̩m�W
        /// </summary>
        /// <remarks>�~���t��</remarks>
        public string HolderName { get; set; } = "";

        /// <summary>
        /// ���\�ϥζ}�l�ɶ�
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// ���\�ϥε����ɶ�
        /// </summary>
        public DateTime EndTime { get; set; } = DateTime.MinValue;
    }
}