using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class UserCursorExample : IExamplesProvider<UserCursorEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>UserCursorEntry</returns>
        public UserCursorEntry GetExamples() {
            return new UserCursorEntry() {
                Account = "fish",
                Direction = true
            };
        }
    }
}