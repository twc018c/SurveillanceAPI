using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class DoorExample : IExamplesProvider<DoorEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>DoorEntry</returns>
        public DoorEntry GetExamples() {
            return new DoorEntry() {
                Keyword = "",
                Floor = 0
            };
        }
    }
}