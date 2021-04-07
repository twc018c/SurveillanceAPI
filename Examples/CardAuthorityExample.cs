using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class CardAuthorityExample : IExamplesProvider<CardAuthorityEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>CardAuthorityEntry</returns>
        public CardAuthorityEntry GetExamples() {
            return new CardAuthorityEntry() {
                Keyword = ""
            };
        }
    }
}