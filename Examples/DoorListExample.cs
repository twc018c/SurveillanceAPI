using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class DoorListExample : IExamplesProvider<DoorListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>DoorEntry</returns>
        public DoorListEntry GetExamples() {
            return new DoorListEntry() {
                Keyword = "",
                Floor = 0
            };
        }
    }
}