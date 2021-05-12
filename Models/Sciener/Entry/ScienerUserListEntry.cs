using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener �Τ���U
    /// </summary>
    public class ScienerUserRegisterEntry {

        /// <summary>
        /// �Τ�W
        /// </summary>
        public string UserName { get; set; } = "";

        /// <summary>
        /// �K�X
        /// </summary>
        public string Password { get; set; } = "";

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }


    /// <summary>
    /// Sciener �Τ�M��
    /// </summary>
    public class ScienerUserListEntry {

        /// <summary>
        /// �}�l�ɶ�
        /// </summary>
        /// <remarks>
        /// 0=�L����
        /// </remarks>
        public long StartDate { get; set; } = 0;

        /// <summary>
        /// �����ɶ�
        /// </summary>
        /// <remarks>
        /// 0=�L����
        /// </remarks>
        public long EndDate { get; set; } = 0;

        /// <summary>
        /// ���X
        /// </summary>
        public int PageNo { get; set; } = 1;

        /// <summary>
        /// �C���ƶq
        /// </summary>
        public int PageSize { get; set; } = 100;

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }
}