using System;


namespace Surveillance.ViewModels {

    /// <summary>
    /// �����O����
    /// </summary>
    public class DashboardHomeViewModel {

        /// <summary>
        /// ���d�ƶq
        /// </summary>
        public int CountCard { get; set; } = 0;

        /// <summary>
        /// ����
        /// </summary>
        public int CountDoor { get; set; } = 0;

        /// <summary>
        /// �ϥΪ�
        /// </summary>
        public int CountUser { get; set; } = 0;
    }
}