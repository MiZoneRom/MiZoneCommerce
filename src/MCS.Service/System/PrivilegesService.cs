using MCS.Core;
using MCS.Entities;
using MCS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kogel.Dapper.Extension.MsSql;

namespace MCS.Service
{
    public class PrivilegesService : ServiceBase, IPrivilegesService
    {

        public void AddPlatformRole(RoleInfo model)
        {

            if (string.IsNullOrEmpty(model.Description))
            {
                model.Description = model.RoleName;
            }

            var ex = Context.QuerySet<RoleInfo>().Where(a => a.RoleName == model.RoleName).ToList();
            if (ex.Count > 0)
            {
                throw new MCSException("已存在相同名称的权限组");
            }
            Context.CommandSet<RoleInfo>().Insert(model);
        }

        public void UpdatePlatformRole(RoleInfo model)
        {
            var updatemodel = Context.QuerySet<RoleInfo>().Where(a => a.Id == model.Id).Get();
            if (updatemodel == null)
                throw new MCSException("找不到该权限组");

            var ex = Context.QuerySet<RoleInfo>().Where(a => a.RoleName == model.RoleName && a.RoleName != updatemodel.RoleName).Count() > 0;
            if (ex)
            {
                throw new MCSException("已存在相同名称的权限组");
            }

            updatemodel.RoleName = model.RoleName;
            updatemodel.Description = model.Description;
            if (string.IsNullOrEmpty(model.Description))
            {
                updatemodel.Description = model.RoleName;
            }

            Context.CommandSet<RolePrivilegeInfo>().Where(a => a.RoleId == model.Id).Delete();
            Context.CommandSet<RolePrivilegeInfo>().Insert(model.RolePrivileges);

        }

        public void DeletePlatformRole(long id)
        {
            var model = Context.CommandSet<RoleInfo>().Where(a => a.Id == id).Delete();
        }

        public RoleInfo GetPlatformRole(long id)
        {
            return Context.QuerySet<RoleInfo>().Where(a => a.Id == id).Get();
        }

        public List<RoleInfo> GetPlatformRoles()
        {
            return Context.QuerySet<RoleInfo>().Where(item => item.Id > 0).ToList();
        }

    }
}
