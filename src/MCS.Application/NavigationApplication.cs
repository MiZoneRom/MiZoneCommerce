using AutoMapper;
using MCS.Core;
using MCS.DTO;
using MCS.Entities;
using MCS.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.Application
{
    public class NavigationApplication : BaseApplicaion<INavigationService>
    {

        public NavigationApplication()
        {
        }

        IMapper _mapper;
        public NavigationApplication(IMapper mapper) : this()
        {
            _mapper = mapper;
        }

        public static List<Navigation> GetNavigations()
        {
            List<NavigationInfo> navigationInfoList = Service.GetNavigations();

            foreach (var item in navigationInfoList)
            {
                Navigation nav = Mapper.Map<NavigationInfo, Navigation>(item);
                Log.Debug(nav.Name);
            }

            return null;
        }

        private Navigation GetChild()
        {

            return null;
        }

    }
}
