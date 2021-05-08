using Surveillance.Library;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class SicenerLockListExample : IExamplesProvider<SicenerLockListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>SicenerLockListEntry</returns>
        public SicenerLockListEntry GetExamples() {
            return new SicenerLockListEntry() {
                LockAlias = "",
                Type = 1,
                PageNo = 1,
                PageSize = 20,
                Date = Tool.GetDateLong()
            };
        }
    }
}