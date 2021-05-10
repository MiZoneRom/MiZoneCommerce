using Kogel.Dapper.Extension.Core.SetQ;
using Kogel.Dapper.Extension.MsSql;
using MCS.DTO;
using MCS.Entities;
using MCS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCS.Service
{
    public class ManagerNavigationService : ServiceBase, IManagerNavigationService
    {
        /// <summary>
        /// 通过Id集合获取导航
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public QuerySet<ManagerNavigationInfo> GetNavigationsByIds(long[] ids)
        {
            var navigations = Context.QuerySet<ManagerNavigationInfo>().Where(item => ids.Contains(item.Id));
            return navigations;
        }

        public QuerySet<ManagerNavigationInfo> GetNavigations(long parentId = 0)
        {
            var navigations = Context.QuerySet<ManagerNavigationInfo>().Where(item => item.ParentId == parentId);
            return navigations;
        }

        public QuerySet<ManagerNavigationInfo> GetNavigations(long[] navIds, long parentId = 0)
        {
            var navigations = Context.QuerySet<ManagerNavigationInfo>().Where(item => navIds.Contains(item.Id) && item.ParentId == parentId);
            return navigations;
        }

        public List<ManagerNavigationInfo> GetNavigations()
        {
            var navigations = Context.QuerySet<ManagerNavigationInfo>().Where(item => item.Id > 0).ToList();
            return navigations;
        }

        public ManagerNavigationInfo GetNavigation(long id)
        {
            return Context.QuerySet<ManagerNavigationInfo>().Where(a => a.Id == id).Get();
        }

        public bool UpdateNavigation(ManagerNavigationInfo model)
        {
            return Context.CommandSet<ManagerNavigationInfo>().Where(item => item.Id == model.Id).Update(model) > 0;
        }

        public List<ManagerNavigationActionInfo> GetNavigationActions(long id)
        {
            return Context.QuerySet<ManagerNavigationActionInfo>().Where(a => a.NavigationId == id).ToList();
        }

    }
}
