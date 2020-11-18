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

        public static List<Navigation> GetNavigations()
        {
            return GetChild(0);
        }

        private static List<Navigation> GetChild(long parentId)
        {
            List<NavigationInfo> navigationInfoList = Service.GetNavigations(parentId).ToList();
            List<Navigation> navigationList = new List<Navigation>();
            foreach (var item in navigationInfoList)
            {
                Navigation nav = Mapper.Map<NavigationInfo, Navigation>(item);
                nav.Children = GetChild(nav.Id);
                navigationList.Add(nav);
            }
            return navigationList;
        }

    }
}
