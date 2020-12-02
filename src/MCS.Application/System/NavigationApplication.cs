using AutoMapper;
using MCS.Core;
using MCS.DTO;
using MCS.Entities;
using MCS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCS.Application
{
    public class NavigationApplication : BaseApplicaion<INavigationService>
    {

        public NavigationApplication()
        {
        }

        public static List<NavigationModel> GetNavigations(string path = "")
        {
            return GetChild(0, path);
        }

        private static List<NavigationModel> GetChild(long parentId, string path = "")
        {
            List<NavigationInfo> navigationInfoList = Service.GetNavigations(parentId).ToList();
            List<NavigationModel> navigationList = new List<NavigationModel>();
            foreach (var item in navigationInfoList)
            {
                NavigationModel nav = Mapper.Map<NavigationInfo, NavigationModel>(item);
                if (!string.IsNullOrEmpty(nav.Path))
                    nav.IsOpen = nav.Path.Equals(path, System.StringComparison.OrdinalIgnoreCase);
                List<NavigationModel> childList = GetChild(nav.Id, path);
                childList.ForEach(a => a.Parent = nav);
                nav.Children = childList;
                if (nav.Children.Count > 0)
                    nav.IsOpen = childList.Where(a => a.IsOpen).Count() > 0;
                navigationList.Add(nav);
            }
            return navigationList;
        }

    }
}
