using Surveillance.Library;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class SicenerLockRecordListExample : IExamplesProvider<SicenerLockRecordListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>SicenerLockRecordListEntry</returns>
        public SicenerLockRecordListEntry GetExamples() {
            return new SicenerLockRecordListEntry() {
                LockID = 2746218,
                StartDate = 0,
                EndDate = 0,
                PageNo = 1,
                PageSize = 20,
                Date = Tool.GetDateLong()
            };
        }
    }
}