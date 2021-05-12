using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener �_�ͤ��e
    /// </summary>
    public class ScienerKeyDetailEntry {

        /// <summary>
        /// �_�ͽs��
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }


    /// <summary>
    /// Sciener �_�ͲM��
    /// </summary>
    public class ScienerKeyListEntry {

        /// <summary>
        /// ��O�W
        /// </summary>
        /// <remarks>
        /// ���
        /// </remarks>
        public string LockAlias { get; set; } = "";

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