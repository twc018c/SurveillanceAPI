using Surveillance.Enums;
using System;


namespace Surveillance.Models {

    /// <summary>
    /// ����
    /// </summary>
    public class DoorModel {

        /// <summary>
        /// �y���s��
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// ����s��
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// ����W��
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// �Ӽh
        /// </summary>
        public int Floor { get; set; } = 0;

        /// <summary>
        /// �Ƶ�
        /// </summary>
        public string Note { get; set; } = "";

        /// <summary>
        /// ���A
        /// </summary>
        public SCIENER_LOCK_STATE Status { get; set; } = SCIENER_LOCK_STATE.UNKNOW;

        /// <summary>
        /// �q�q
        /// </summary>
        public int Battery { get; set; } = 0;

        /// <summary>
        /// �q�q��s�ɶ�
        /// </summary>
        public DateTime BatteryTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// ���ݶ}��X��
        /// </summary>
        public int IsRemote { get; set; } = 0;

        /// <summary>
        /// �̫�ʧ@�ɶ�
        /// </summary>
        public DateTime ActionTime { get; set; } = DateTime.MinValue;
    }
}