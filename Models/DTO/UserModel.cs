using System;


namespace Surveillance.Models {

    /// <summary>
    /// �ϥΪ�
    /// </summary>
    public class UserModel {

        /// <summary>
        /// �y���s��
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// �m�W
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// �b��
        /// </summary>
        public string Account { get; set; } = "";

        /// <summary>
        /// �K�X
        /// </summary>
        public string Password { get; set; } = "";

        /// <summary>
        /// �޲z���X��
        /// </summary>
        public byte IsAdmin { get; set; } = 0;

        /// <summary>
        /// �ҥκX��
        /// </summary>
        public byte IsWork { get; set; } = 0;

        /// <summary>
        /// �̫�ʧ@�ɶ�
        /// </summary>
        public DateTime ActionTime { get; set; } = DateTime.MinValue;
    }
}