using AutoMapper;
using MCS.CommonModel;
using MCS.Core;
using MCS.DTO;
using MCS.DTO.System;
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

        public static List<NavigationInfo> GetNavigations()
        {
            List<NavigationInfo> navigationInfoList = Core.Cache.Get<List<NavigationInfo>>(CacheKeyCollection.Navigations);
            if (navigationInfoList == null)
            {
                navigationInfoList = Service.GetNavigations().ToList();
                Core.Cache.Insert(CacheKeyCollection.Navigations, navigationInfoList);
            }
            return navigationInfoList;
        }

        public static List<NavigationBreadCrumbModel> GetPageName(string path)
        {
            List<NavigationInfo> navigationInfoList = GetNavigations();
            List<NavigationBreadCrumbModel> breadCrumbList = new List<NavigationBreadCrumbModel>();
            NavigationInfo page = navigationInfoList.Where(a => !string.IsNullOrEmpty(a.Path) && a.Path.Equals(path, System.StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (page == null)
                return null;

            breadCrumbList.Add(new NavigationBreadCrumbModel { Name = page.Name, Path = page.Path });

            bool noParent = false;
            do
            {

            } while (noParent);

            return breadCrumbList;

        }

        public static List<NavigationModel> GetNavigationTreeList(string path = "")
        {
            return GetTreeChild(0, path);
        }

        private static List<NavigationModel> GetTreeChild(long parentId, string path = "")
        {
            List<NavigationInfo> navigationInfoList = Service.GetNavigations(parentId).ToList();
            List<NavigationModel> navigationList = new List<NavigationModel>();
            foreach (var item in navigationInfoList)
            {
                NavigationModel nav = Mapper.Map<NavigationInfo, NavigationModel>(item);
                if (!string.IsNullOrEmpty(nav.Path))
                    nav.IsOpen = nav.Path.Equals(path, System.StringComparison.OrdinalIgnoreCase);
                List<NavigationModel> childList = GetTreeChild(nav.Id, path);
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
