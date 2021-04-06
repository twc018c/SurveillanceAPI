using AutoMapper;
using Surveillance.Models;
using Surveillance.ViewModels;


namespace Surveillance.Schafold {

    /// <summary>
    /// AutoMapper
    /// </summary>
    public class AutoMapperProfile : Profile {

        /// <summary>
        /// 建構
        /// </summary>
        public AutoMapperProfile() {
            // 門鎖
            CreateMap<DoorModel, DoorViewModel>();
        }
    }
}