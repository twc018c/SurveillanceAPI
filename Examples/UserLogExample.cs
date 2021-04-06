using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;
using System;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class UserLogExample : IExamplesProvider<UserLogEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>UserLogEntry</returns>
        public UserLogEntry GetExamples() {
            return new UserLogEntry() {
                StartTime = new DateTime(2021, 01, 01),
                EndTime = new DateTime(2021, 12, 31),
                UserSeq = 1
            };
        }
    }
}