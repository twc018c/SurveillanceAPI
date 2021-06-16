using Surveillance.Models;
using System.Collections.Generic;


namespace Surveillance.Interfaces {

    /// <summary>
    /// UI
    /// </summary>
    public interface IUIService {
        List<SelectModel> GetPower();
    }
}