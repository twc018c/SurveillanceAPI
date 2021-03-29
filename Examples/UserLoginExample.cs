using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class UserLoginExample : IExamplesProvider<UserLoginEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>UserLoginEntry</returns>
        public UserLoginEntry GetExamples() {
            return new UserLoginEntry() {
                Account = "fish",
                Password = "fish"
            };
        }
    }
}