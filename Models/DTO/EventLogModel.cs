using Surveillance.Enums;
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
        public EVENT_LOG_STATUS Status { get; set; } = EVENT_LOG_STATUS.UNKNOW;

        /// <summary>
        /// �N�X
        /// </summary>
        public SCIENER_CODE ErrCode { get; set; } = SCIENER_CODE.SUCCESS;

        /// <summary>
        /// �ϥΪ̬y���s��
        /// </summary>
        public int UserSeq { get; set; } = 0;
    }
}