using MCS.CommonModel;
using MCS.DTO.QueryModel;
using MCS.Entities;
using MCS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kogel.Dapper.Extension.MsSql;
using MCS.Core.Helper;
using MCS.Core;

namespace MCS.Service
{
    public class ManagerService : ServiceBase, IManagerService
    {
        public QueryPageModel<ManagersInfo> GetPlatformManagers(ManagerQuery query)
        {
            var users = Context.QuerySet<ManagersInfo>().Where(item => item.Id > 0).PageList(query.PageNo, query.PageSize);
            QueryPageModel<ManagersInfo> pageModel = new QueryPageModel<ManagersInfo>()
            {
                Models = users.Items,
                Total = users.Total
            };
            return pageModel;
        }

        public List<ManagersInfo> GetPlatformManagerByRoleId(long roleId)
        {
            return Context.QuerySet<ManagersInfo>().Where(item => item.RoleId == roleId).ToList();
        }

        public ManagersInfo GetPlatformManager(long userId)
        {
            ManagersInfo manager = null;
            string CACHE_MANAGER_KEY = CacheKeyCollection.Manager(userId);

            if (CacheHelper.Exists(CACHE_MANAGER_KEY))
            {
                manager = CacheHelper.Get<ManagersInfo>(CACHE_MANAGER_KEY);
            }
            else
            {
                manager = Context.QuerySet<ManagersInfo>().Where(item => item.Id == userId).Get();
                if (manager == null)
                    return null;
                if (manager.RoleId == 0)
                {
                    List<AdminPrivilege> AdminPrivileges = new List<AdminPrivilege>();
                    AdminPrivileges.Add((AdminPrivilege)0);
                    manager.RealName = "系统管理员";
                    manager.AdminPrivileges = AdminPrivileges;
                }
                else
                {
                    var model = Context.QuerySet<ManagersInfo>().Where(p => p.Id == manager.RoleId).Get();
                    if (model != null)
                    {
                        List<AdminPrivilege> AdminPrivileges = new List<AdminPrivilege>();
                        (from a in Context.QuerySet<RolePrivilegesInfo>() where a.RoleId == model.RoleId select a).ToList().ForEach(a => AdminPrivileges.Add((AdminPrivilege)a.Privilege));
                        manager.RealName = model.RealName;
                        manager.AdminPrivileges = AdminPrivileges;
                    }
                }
                CacheHelper.Insert(CACHE_MANAGER_KEY, manager);
            }
            return manager;
        }

        public void AddPlatformManager(ManagersInfo model)
        {
            if (model.RoleId == 0)
                throw new MCSException("权限组选择不正确!");
            if (CheckUserNameExist(model.UserName, true))
            {
                throw new MCSException("该用户名已存在！");
            }
            model.PasswordSalt = Guid.NewGuid().ToString();
            model.CreateDate = DateTime.Now;
            var pwd = SecureHelper.MD5(model.Password);
            model.Password = SecureHelper.MD5(pwd + model.PasswordSalt);
            Context.CommandSet<ManagersInfo>().Insert(model);
        }

        public void ChangePlatformManagerPassword(long id, string password, long roleId)
        {
            var model = Context.QuerySet<ManagersInfo>().Where(item => item.Id == id).Get();
            if (model == null)
                throw new MCSException("该管理员不存在，或者已被删除!");

            if (roleId != 0 && model.RoleId != 0)
                model.RoleId = roleId;

            if (!string.IsNullOrWhiteSpace(password))
            {
                var pwd = SecureHelper.MD5(password);
                model.Password = SecureHelper.MD5(pwd + model.PasswordSalt);
            }

            Context.CommandSet<ManagersInfo>().Where(item => item.Id == id).Update(model);

            string CACHE_MANAGER_KEY = CacheKeyCollection.Manager(id);
            CacheHelper.Remove(CACHE_MANAGER_KEY);
        }

        public void DeletePlatformManager(long id)
        {
            var model = Context.CommandSet<ManagersInfo>().Where(item => item.Id == id && item.RoleId != 0).Delete();
            string CACHE_MANAGER_KEY = CacheKeyCollection.Manager(id);
            CacheHelper.Remove(CACHE_MANAGER_KEY);
        }

        public void BatchDeletePlatformManager(long[] ids)
        {
            var model = Context.CommandSet<ManagersInfo>().Where(item => item.RoleId != 0 && ids.Contains(item.Id)).Delete();
            foreach (var id in ids)
            {
                string CACHE_MANAGER_KEY = CacheKeyCollection.Manager(id);
                CacheHelper.Remove(CACHE_MANAGER_KEY);
            }
        }

        public List<ManagersInfo> GetManagers(string keyWords)
        {
            List<ManagersInfo> managers = Context.QuerySet<ManagersInfo>().Where(item =>
                         (keyWords == null || keyWords == "" || item.UserName.Contains(keyWords))).ToList();
            return managers;
        }

        public ManagersInfo Login(string username, string password)
        {
            ManagersInfo manager = Context.QuerySet<ManagersInfo>().Where(item => item.UserName == username).Get();
            if (manager != null)
            {
                string encryptedWithSaltPassword = GetPasswrodWithTwiceEncode(password, manager.PasswordSalt);
                if (encryptedWithSaltPassword.ToLower() != manager.Password)//比较密码是否一致
                    manager = null;//不一致，则置空，表示未找到指定的管理员
                else//一致，则表示登录成功，更新登录时间
                {

                }
            }
            return manager;
        }

        string GetPasswrodWithTwiceEncode(string password, string salt)
        {
            string encryptedPassword = SecureHelper.MD5(password);//一次MD5加密
            string encryptedWithSaltPassword = SecureHelper.MD5(encryptedPassword + salt);//一次结果加盐后二次加密
            return encryptedWithSaltPassword;
        }

        public bool CheckUserNameExist(string username, bool isPlatFormManager = false)
        {
            if (isPlatFormManager)
            {
                return Context.QuerySet<ManagersInfo>().Where(item => item.UserName.ToLower() == username.ToLower()).Count() > 0;
            }
            return Context.QuerySet<MembersInfo>().Where(item => item.UserName.ToLower() == username.ToLower()).Count() > 0;
        }

        public void AddRefeshToken(string token, string refeshToken, long userId, double minutes = 1)
        {
            Context.CommandSet<ManagerTokenInfo>().Insert(new ManagerTokenInfo() { UserId = userId, Token = token, RefreshToken = refeshToken, Expires = DateTime.Now.AddMinutes(minutes) });
        }

        public ManagerTokenInfo GetToken(long userId)
        {
            return Context.QuerySet<ManagerTokenInfo>().Where(a => a.UserId == userId).OrderByDescing(a => a.Id).Get();
        }

        public ManagerTokenInfo GetTokenByRefreshToken(string refreshToken)
        {
            return Context.QuerySet<ManagerTokenInfo>().Where(a => a.RefreshToken == refreshToken && a.Expires > DateTime.Now).OrderByDescing(a => a.Id).Get();
        }

        public bool UpdateManagerToken(ManagerTokenInfo model)
        {
            return Context.CommandSet<ManagerTokenInfo>().Where(item => item.Id == model.Id).Update(model) > 0;
        }

        public void RemoveToken(long userId)
        {
            int result = Context.CommandSet<ManagerTokenInfo>().Where(a => a.UserId == userId).Delete();
        }

    }
}
