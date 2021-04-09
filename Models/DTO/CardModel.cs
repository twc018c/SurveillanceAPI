using System;


namespace Surveillance.Models {

    /// <summary>
    /// ���d
    /// </summary>
    public class CardModel {

        /// <summary>
        /// �y���s��
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// ���d�s��
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// �Ƶ�
        /// </summary>
        public string Note { get; set; } = "";

        /// <summary>
        /// �ҥκX��
        /// </summary>
        public int IsWork { get; set; } = 0;

        /// <summary>
        /// �̫�ʧ@�ɶ�
        /// </summary>
        public DateTime ActionTime { get; set; } = DateTime.MinValue;
    }
}