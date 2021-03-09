using Kogel.Dapper.Extension.Core.SetQ;
using MCS.DTO;
using MCS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.IServices
{
    public interface INavigationService : IService
    {
        /// <summary>
        /// 通过Id集合获取导航
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        QuerySet<NavigationInfo> GetNavigationsByIds(long[] ids);
        QuerySet<NavigationInfo> GetNavigations(long parentId = 0);
        List<NavigationInfo> GetNavigations();
        NavigationInfo GetNavigation(long id);
        bool UpdateNavigation(NavigationInfo model);
    }
}
