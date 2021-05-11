using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener �_��
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/key/get
    /// </remarks>
    public class SicenerKeyEntry {

        /// <summary>
        /// �_�ͽs��
        /// </summary>
        public int LockId { get; set; } = 0;

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }


    /// <summary>
    /// Sciener �_�ͲM��
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/key/list
    /// </remarks>
    public class SicenerKeyListEntry {

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
        public int PageSize { get; set; } = 50;

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }
}