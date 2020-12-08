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
        QuerySet<NavigationInfo> GetNavigations(long parentId = 0);
        List<NavigationInfo> GetNavigations();
        NavigationInfo GetNavigation(long id);
    }
}
