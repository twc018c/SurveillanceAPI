using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class CardAuthorityChechExample : IExamplesProvider<CardAuthorityCheckEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>CardAuthorityCheckEntry</returns>
        public CardAuthorityCheckEntry GetExamples() {
            return new CardAuthorityCheckEntry() {
                DoorID = 0,
                CardID = 0
            };
        }
    }
}