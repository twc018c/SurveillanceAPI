using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class DoorCursorExample : IExamplesProvider<DoorCursorEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>DoorCursorEntry</returns>
        public DoorCursorEntry GetExamples() {
            return new DoorCursorEntry() {
                Seq = 1,
                Direction = true
            };
        }
    }
}