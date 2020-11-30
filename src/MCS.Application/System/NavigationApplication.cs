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

        public static List<NavigationModel> GetNavigations()
        {
            return GetChild(0);
        }

        private static List<NavigationModel> GetChild(long parentId)
        {
            List<NavigationInfo> navigationInfoList = Service.GetNavigations(parentId).ToList();
            List<NavigationModel> navigationList = new List<NavigationModel>();
            foreach (var item in navigationInfoList)
            {
                NavigationModel nav = Mapper.Map<NavigationInfo, NavigationModel>(item);
                nav.Children = GetChild(nav.Id);
                navigationList.Add(nav);
            }
            return navigationList;
        }

    }
}
