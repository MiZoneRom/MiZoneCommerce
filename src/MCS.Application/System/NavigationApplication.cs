using AutoMapper;
using MCS.CommonModel;
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

        /// <summary>
        /// 获取导航
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 获取按照层级排序导航
        /// </summary>
        /// <param name="parent_id"></param>
        /// <returns></returns>
        public static List<NavigationModel> GetNavigationModels(long parent_id)
        {
            List<NavigationInfo> navigationInfoList = GetNavigations();
            List<NavigationModel> navigationModelList = Mapper.Map<List<NavigationInfo>, List<NavigationModel>>(navigationInfoList);
            var newList = new List<NavigationModel>();
            GetNavigationChildModels(navigationModelList, newList, parent_id, 0);
            return navigationModelList;
        }

        private static void GetNavigationChildModels(List<NavigationModel> oldData, List<NavigationModel> newData, long parent_id, int class_layer)
        {
            class_layer++;
            List<NavigationModel> dr = oldData.Where(a => a.ParentId == parent_id).OrderBy(a => a.SortId).ToList();
            foreach (var item in dr)
            {
                item.ClassLayer = class_layer;
                newData.Add(item);
                GetNavigationChildModels(oldData, newData, item.Id, class_layer);
            }
        }

        /// <summary>
        /// 获取面包屑导航
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<NavigationBreadCrumbModel> GetBreadCrumb(string path)
        {
            List<NavigationInfo> navigationInfoList = GetNavigations();
            List<NavigationBreadCrumbModel> breadCrumbList = new List<NavigationBreadCrumbModel>();
            NavigationInfo page = navigationInfoList.Where(a => !string.IsNullOrEmpty(a.Path) && a.Path.Equals(path, System.StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (page == null)
                return new List<NavigationBreadCrumbModel>();

            breadCrumbList.Add(new NavigationBreadCrumbModel { Name = page.Name, Path = page.Path });

            NavigationInfo temp = page;
            bool hasParent = true;
            do
            {
                temp = navigationInfoList.Where(a => a.Id == temp.ParentId).FirstOrDefault();
                if (temp != null)
                {
                    breadCrumbList.Insert(0, new NavigationBreadCrumbModel { Name = temp.Name, Path = temp.Path });
                }
                else
                {
                    hasParent = false;
                }
            } while (hasParent);

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

        public static NavigationModel GetNavigation(long id)
        {
            NavigationInfo navInfo = Service.GetNavigation(id);
            return Mapper.Map<NavigationInfo, NavigationModel>(navInfo);
        }

    }
}
