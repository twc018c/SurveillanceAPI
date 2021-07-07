using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class DoorDragExample : IExamplesProvider<DoorDragEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>DoorDragEntry</returns>
        public DoorDragEntry GetExamples() {
            return new DoorDragEntry() {
                ID = 2746218,
                PositionX = 50,
                PositionY = 50
            };
        }
    }
}