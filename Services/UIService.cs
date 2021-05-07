using Surveillance.Interfaces;
using Surveillance.Models;
using System.Collections.Generic;
using System.Linq;


namespace Surveillance.Services {

    /// <summary>
    /// UI
    /// </summary>
    public class UIService : IUIService {

        /// <summary>
        /// 建構
        /// </summary>
        public UIService() {
            // NOTHING
        }


        /// <summary>
        /// 樓層
        /// </summary>
        /// <returns>List</returns>
        public List<SelectModel> GetFloor() {
            var Dictionary = new Dictionary<int, string>();
            Dictionary.Add(-2, "B2F");
            Dictionary.Add(-1, "B1F");
            Dictionary.Add(1, "1F");
            Dictionary.Add(2, "2F");
            Dictionary.Add(3, "3F");
            Dictionary.Add(4, "4F");
            Dictionary.Add(5, "5F");

            return Dictionary.Select(x => new SelectModel() {
                                        Value = x.Key,
                                        Label = x.Value,
                                        LabelSub = ""
                                    })
                             .ToList();
        }
    }
}