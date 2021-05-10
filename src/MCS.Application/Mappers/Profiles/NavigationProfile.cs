using AutoMapper;
using MCS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.Application.Mappers.Profiles
{
    public class NavigationProfile : Profile
    {
        public NavigationProfile()
        {
            CreateMap<ManagerNavigationInfo, DTO.ManagerNavigationModel>();
            CreateMap<DTO.ManagerNavigationModel, ManagerNavigationInfo>();

            CreateMap<ManagerNavigationActionInfo, DTO.ManagerNavigationActionModel>();
            CreateMap<DTO.ManagerNavigationActionModel, ManagerNavigationActionInfo>();
        }
    }
}
