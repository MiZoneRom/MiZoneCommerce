using Kogel.Dapper.Extension.Core.SetQ;
using Kogel.Dapper.Extension.MsSql;
using MCS.DTO;
using MCS.Entities;
using MCS.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.Service
{
    public class NavigationService : ServiceBase, INavigationService
    {
        public QuerySet<NavigationInfo> GetNavigations(long parentId = 0)
        {
            var navigations = Context.QuerySet<NavigationInfo>().Where(item => item.ParentId == parentId);
            return navigations;
        }

        public List<NavigationInfo> GetNavigations()
        {
            var navigations = Context.QuerySet<NavigationInfo>().Where(item => item.Id > 0).ToList();
            return navigations;
        }

        public NavigationInfo GetNavigation(long id)
        {
            return Context.QuerySet<NavigationInfo>().Where(a => a.Id == id).Get();
        }

        public bool UpdateNavigation(NavigationInfo model)
        {
            return Context.CommandSet<NavigationInfo>().Where(item => item.Id == model.Id).Update(model) > 0;
        }

    }
}
