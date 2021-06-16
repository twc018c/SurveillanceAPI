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
        /// 取得電量
        /// </summary>
        /// <returns>List</returns>
        public List<SelectModel> GetPower() {
            var Dictionary = new Dictionary<int, string>();
            Dictionary.Add(0, "0");
            Dictionary.Add(10, "10");
            Dictionary.Add(20, "20");
            Dictionary.Add(30, "30");
            Dictionary.Add(40, "40");
            Dictionary.Add(50, "50");
            Dictionary.Add(60, "60");
            Dictionary.Add(70, "70");
            Dictionary.Add(80, "80");
            Dictionary.Add(90, "90");
            Dictionary.Add(100, "100");

            return Dictionary.Select(x => new SelectModel() {
                                        Value = x.Key,
                                        Label = x.Value,
                                        LabelSub = ""
                                    })
                             .ToList();
        }
    }
}