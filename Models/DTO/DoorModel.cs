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
        public string ID { get; set; } = "";

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
        public int Status { get; set; } = 0;

        /// <summary>
        /// �q���q�q
        /// </summary>
        public int Battery { get; set; } = 0;

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