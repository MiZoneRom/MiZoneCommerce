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
    public class ManagerNavigationApplication : BaseApplicaion<IManagerNavigationService>
    {

        public ManagerNavigationApplication()
        {
        }

        /// <summary>
        /// 获取所有导航
        /// </summary>
        /// <returns></returns>
        public static List<ManagerNavigationInfo> GetNavigations()
        {
            List<ManagerNavigationInfo> navigationInfoList = Core.Cache.Get<List<ManagerNavigationInfo>>(CacheKeyCollection.Navigations);
            if (navigationInfoList == null)
            {
                navigationInfoList = Service.GetNavigations().ToList();
                Core.Cache.Insert(CacheKeyCollection.Navigations, navigationInfoList);
            }
            return navigationInfoList;
        }

        /// <summary>
        /// 根据角色获取导航列表
        /// </summary>
        /// <param name="parent_id"></param>
        /// <returns></returns>
        public static List<ManagerNavigationModel> GetNavigationByRoleId(long roleId)
        {
            long[] navIds = ServiceProvider.Instance<IManagerService>.Create.GetRoleNavigationIds(roleId);
            List<ManagerNavigationInfo> navigationInfoList = GetNavigations().Where(a => navIds.Contains(a.Id)).ToList();
            List<ManagerNavigationModel> navigationModelList = Mapper.Map<List<ManagerNavigationInfo>, List<ManagerNavigationModel>>(navigationInfoList);
            var newList = new List<ManagerNavigationModel>();
            GetNavigationChildModels(navigationModelList, newList, 0, 0);
            return navigationModelList;
        }

        /// <summary>
        /// 获取按照层级排序导航
        /// </summary>
        /// <param name="parent_id"></param>
        /// <returns></returns>
        public static List<ManagerNavigationModel> GetNavigationModels()
        {
            List<ManagerNavigationInfo> navigationInfoList = GetNavigations();
            List<ManagerNavigationModel> navigationModelList = Mapper.Map<List<ManagerNavigationInfo>, List<ManagerNavigationModel>>(navigationInfoList);
            var newList = new List<ManagerNavigationModel>();
            GetNavigationChildModels(navigationModelList, newList, 0, 0);
            return navigationModelList;
        }

        /// <summary>
        /// 获取子项导航
        /// </summary>
        /// <param name="oldData"></param>
        /// <param name="newData"></param>
        /// <param name="parent_id"></param>
        /// <param name="class_layer"></param>
        private static void GetNavigationChildModels(List<ManagerNavigationModel> oldData, List<ManagerNavigationModel> newData, long parent_id, int class_layer)
        {
            class_layer++;
            List<ManagerNavigationModel> dr = oldData.Where(a => a.ParentId == parent_id).OrderBy(a => a.SortId).ToList();
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
        public static List<ManagerNavigationBreadCrumbModel> GetBreadCrumb(string path)
        {
            List<ManagerNavigationInfo> navigationInfoList = GetNavigations();
            List<ManagerNavigationBreadCrumbModel> breadCrumbList = new List<ManagerNavigationBreadCrumbModel>();
            ManagerNavigationInfo page = navigationInfoList.Where(a => !string.IsNullOrEmpty(a.Path) && a.Path.Equals(path, System.StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (page == null)
                return new List<ManagerNavigationBreadCrumbModel>();

            breadCrumbList.Add(new ManagerNavigationBreadCrumbModel { Name = page.Name, Path = page.Path });

            ManagerNavigationInfo temp = page;
            bool hasParent = true;
            do
            {
                temp = navigationInfoList.Where(a => a.Id == temp.ParentId).FirstOrDefault();
                if (temp != null)
                {
                    breadCrumbList.Insert(0, new ManagerNavigationBreadCrumbModel { Name = temp.Name, Path = temp.Path });
                }
                else
                {
                    hasParent = false;
                }
            } while (hasParent);

            return breadCrumbList;

        }

        public static List<ManagerNavigationModel> GetNavigationTreeList(long roleId, string path = "")
        {
            long[] navIds = ServiceProvider.Instance<IManagerService>.Create.GetRoleNavigationIds(roleId);
            return GetTreeChild(0, navIds, path);
        }

        private static List<ManagerNavigationModel> GetTreeChild(long parentId, long[] navIds, string path = "")
        {
            List<ManagerNavigationInfo> navigationInfoList = Service.GetNavigations(navIds, parentId).ToList();
            List<ManagerNavigationModel> navigationList = new List<ManagerNavigationModel>();
            foreach (var item in navigationInfoList)
            {
                ManagerNavigationModel nav = Mapper.Map<ManagerNavigationInfo, ManagerNavigationModel>(item);
                if (!string.IsNullOrEmpty(nav.Path))
                    nav.IsOpen = nav.Path.Equals(path, System.StringComparison.OrdinalIgnoreCase);
                List<ManagerNavigationModel> childList = GetTreeChild(nav.Id, navIds, path);
                childList.ForEach(a => a.Parent = nav);
                nav.Children = childList;
                if (nav.Children.Count > 0)
                    nav.IsOpen = childList.Where(a => a.IsOpen).Count() > 0;
                navigationList.Add(nav);
            }
            return navigationList;
        }

        public static ManagerNavigationModel GetNavigation(long id)
        {
            ManagerNavigationInfo navInfo = Service.GetNavigation(id);
            ManagerNavigationModel model = Mapper.Map<ManagerNavigationInfo, ManagerNavigationModel>(navInfo);
            model.Actions = Mapper.Map<List<ManagerNavigationActionInfo>, List<ManagerNavigationActionModel>>(Service.GetNavigationActions(id));
            return model;
        }

        public static bool UpdateNavigation(ManagerNavigationModel model)
        {
            ManagerNavigationInfo modelInfo = Mapper.Map<ManagerNavigationModel, ManagerNavigationInfo>(model);
            List<ManagerNavigationActionInfo> modelActions = Mapper.Map<List<ManagerNavigationActionModel>, List<ManagerNavigationActionInfo>>(model.Actions);
            return Service.UpdateNavigation(modelInfo, modelActions);
        }

    }
}
