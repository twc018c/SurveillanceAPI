using Surveillance.Library;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class SicenerKeyListExample : IExamplesProvider<SicenerKeyListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>SicenerKeyListEntry</returns>
        public SicenerKeyListEntry GetExamples() {
            return new SicenerKeyListEntry() {
                LockAlias = "",
                PageNo = 1,
                PageSize = 20,
                Date = Tool.GetDateLong()
            };
        }
    }
}