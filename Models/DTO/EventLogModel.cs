using System;


namespace Surveillance.Models {

    /// <summary>
    /// �ƥ����
    /// </summary>
    public class EventLogModel {

        /// <summary>
        /// �y���s��
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// �ɶ�
        /// </summary>
        public DateTime Time { get; set; } = DateTime.MinValue;

        /// <summary>
        /// ����s��
        /// </summary>
        public string DoorID { get; set; } = "";

        /// <summary>
        /// ���d�s��
        /// </summary>
        public string CardID { get; set; } = "";

        /// <summary>
        /// ���A
        /// </summary>
        public int Status { get; set; } = 0;

        /// <summary>
        /// �ϥΪ̬y���s��
        /// </summary>
        public int UserSeq { get; set; } = 0;
    }
}