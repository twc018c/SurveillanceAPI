using Surveillance.Enums;
using System;


namespace Surveillance.Models {

    /// <summary>
    /// �ϥΪ̬���
    /// </summary>
    public class UserLogModel {

        /// <summary>
        /// �y���s��
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// �ɶ�
        /// </summary>
        public DateTime Time { get; set; } = DateTime.MinValue;

        /// <summary>
        /// �ϥΪ̬y���s��
        /// </summary>
        public int UserSeq { get; set; } = 0;

        /// <summary>
        /// ���A
        /// </summary>
        public USER_LOG_STATUS Status { get; set; } = USER_LOG_STATUS.UNKNOW;

        /// <summary>
        /// �Ƶ�
        /// </summary>
        public string Note { get; set; } = "";
    }
}