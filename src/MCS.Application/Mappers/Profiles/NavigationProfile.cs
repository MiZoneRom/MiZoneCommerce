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
            CreateMap<NavigationInfo, DTO.NavigationModel>();
            CreateMap<DTO.NavigationModel, NavigationInfo>();
        }
    }
}
