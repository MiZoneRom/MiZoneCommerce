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
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="model"></param>
        public void AddPlatformRole(ManagerRoleInfo model)
        {

            if (string.IsNullOrEmpty(model.Description))
            {
                model.Description = model.RoleName;
            }

            var ex = Context.QuerySet<ManagerRoleInfo>().Where(a => a.RoleName == model.RoleName).ToList();
            if (ex.Count > 0)
            {
                throw new MCSException("已存在相同名称的权限组");
            }
            Context.CommandSet<ManagerRoleInfo>().Insert(model);
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="model"></param>
        public void UpdatePlatformRole(ManagerRoleInfo model)
        {
            var updatemodel = Context.QuerySet<ManagerRoleInfo>().Where(a => a.Id == model.Id).Get();
            if (updatemodel == null)
                throw new MCSException("找不到该权限组");

            var ex = Context.QuerySet<ManagerRoleInfo>().Where(a => a.RoleName == model.RoleName && a.RoleName != updatemodel.RoleName).Count() > 0;
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

            Context.CommandSet<ManagerRolePrivilegeInfo>().Where(a => a.RoleId == model.Id).Delete();
            Context.CommandSet<ManagerRolePrivilegeInfo>().Insert(model.RolePrivileges);

        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        public void DeletePlatformRole(long id)
        {
            var model = Context.CommandSet<ManagerRoleInfo>().Where(a => a.Id == id).Delete();
        }

        /// <summary>
        /// 获取橘色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ManagerRoleInfo GetPlatformRole(long id)
        {
            return Context.QuerySet<ManagerRoleInfo>().Where(a => a.Id == id).Get();
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public List<ManagerRoleInfo> GetPlatformRoles()
        {
            return Context.QuerySet<ManagerRoleInfo>().Where(item => item.Id > 0).ToList();
        }

    }
}
