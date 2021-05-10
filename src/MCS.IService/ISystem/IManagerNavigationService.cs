using Kogel.Dapper.Extension.Core.SetQ;
using MCS.DTO;
using MCS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.IServices
{
    public interface IManagerNavigationService : IService
    {
        /// <summary>
        /// 通过Id集合获取导航
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        QuerySet<ManagerNavigationInfo> GetNavigationsByIds(long[] ids);
        QuerySet<ManagerNavigationInfo> GetNavigations(long parentId = 0);
        QuerySet<ManagerNavigationInfo> GetNavigations(long[] navIds, long parentId = 0);
        List<ManagerNavigationInfo> GetNavigations();
        ManagerNavigationInfo GetNavigation(long id);
        bool UpdateNavigation(ManagerNavigationInfo model, List<ManagerNavigationActionInfo> actions = null);
        List<ManagerNavigationActionInfo> GetNavigationActions(long id);
    }
}
