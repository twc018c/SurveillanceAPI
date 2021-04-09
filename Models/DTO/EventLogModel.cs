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
        public int DoorID { get; set; } = 0;

        /// <summary>
        /// ���d�s��
        /// </summary>
        public int CardID { get; set; } = 0;

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