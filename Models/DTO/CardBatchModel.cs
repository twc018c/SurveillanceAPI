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
        public string CardID { get; set; } = "";

        /// <summary>
        /// �����̦W��
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// �}�l�ɶ�
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// �ɶ��ɶ�
        /// </summary>
        public DateTime EndTime { get; set; } = DateTime.MinValue;
    }
}