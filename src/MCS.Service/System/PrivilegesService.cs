using MCS.Common;
using MCS.Entity;
using MCS.Entity.Entities;
using MCS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.Service
{
    public class PrivilegesService : ServiceBase, IPrivilegesService
    {

        public void AddPlatformRole(ManagersRoles model)
        {

            if (string.IsNullOrEmpty(model.Description))
            {
                model.Description = model.RoleName;
            }

            var ex = Context.ManagersRoles.Any(a => a.RoleName == model.RoleName);
            if (ex)
            {
                throw new MZcmsException("已存在相同名称的权限组");
            }
            Context.ManagersRoles.Add(model);
            Context.SaveChanges();
        }

        public void UpdatePlatformRole(ManagersRoles model)
        {
            var updatemodel = Context.ManagersRoles.FindBy(a => a.Id == model.Id).FirstOrDefault();
            if (updatemodel == null)
                throw new MZcmsException("找不到该权限组");

            var ex = Context.ManagersRoles.Any(a => a.RoleName == model.RoleName && a.RoleName != updatemodel.RoleName);
            if (ex)
            {
                throw new MZcmsException("已存在相同名称的权限组");
            }

            updatemodel.RoleName = model.RoleName;
            updatemodel.Description = model.Description;
            if (string.IsNullOrEmpty(model.Description))
            {
                updatemodel.Description = model.RoleName;
            }
            Context.ManagerPrivileges.RemoveRange(updatemodel.ManagerPrivileges);
            updatemodel.ManagerPrivileges = model.ManagerPrivileges;
            Context.SaveChanges();
        }

        public void DeletePlatformRole(long id)
        {
            var model = Context.ManagersRoles.Where(a => a.Id == id).FirstOrDefault();
            Context.ManagersRoles.Remove(model);
            Context.SaveChanges();
        }
        public ManagersRoles GetPlatformRole(long id)
        {
            return Context.ManagersRoles.Where(a => a.Id == id).FirstOrDefault();
        }

        public IQueryable<ManagersRoles> GetPlatformRoles()
        {
            return Context.ManagersRoles.FindBy(item => item.Id > 0);
        }

    }
}
