using MCS.CommonModel;
using MCS.Core;
using MCS.DTO.QueryModel;
using MCS.Entities;
using MCS.IServices;
using System.Collections.Generic;

namespace MCS.Application
{
    public class ManagerApplication : BaseApplicaion<IManagerService>
    {

        /// <summary>
        /// 根据查询条件分页获取平台管理员信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static QueryPageModel<Entities.ManagerInfo> GetPlatformManagers(ManagerQuery query)
        {
            return Service.GetPlatformManagers(query);
        }

        /// <summary>
        /// 根据角色ID获取平台角色下的管理员
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public static List<Entities.ManagerInfo> GetPlatformManagerByRoleId(long roleId)
        {
            return Service.GetPlatformManagerByRoleId(roleId);
        }

        /// <summary>
        /// 获取当前登录的平台管理员
        /// </summary>
        /// <returns></returns>
        public static Entities.ManagerInfo GetPlatformManager(long userId)
        {
            return Service.GetPlatformManager(userId);
        }

        /// <summary>
        /// 添加一个平台管理员
        /// </summary>
        /// <param name="model"></param>
        public static void AddPlatformManager(Entities.ManagerInfo model)
        {
            Service.AddPlatformManager(model);
        }

        /// <summary>
        /// 修改平台管理员密码和角色
        /// </summary>
        /// <param name="model"></param>
        public static void ChangePlatformManagerPassword(long id, string password, long roleId)
        {
            Service.ChangePlatformManagerPassword(id, password, roleId);
        }

        /// <summary>
        /// 删除平台管理员
        /// </summary>
        /// <param name="id"></param>
        public static void DeletePlatformManager(long id)
        {
            Service.DeletePlatformManager(id);
        }

        /// <summary>
        /// 批量删除平台管理员
        /// </summary>
        /// <param name="ids"></param>
        public static void BatchDeletePlatformManager(long[] ids)
        {
            Service.BatchDeletePlatformManager(ids);
        }

        /// <summary>
        /// 是否存在相同的用户名
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool CheckUserNameExist(string userName, bool isPlatFormManager = false)
        {
            return Service.CheckUserNameExist(userName, isPlatFormManager);
        }


        /// <summary>
        /// 获取查询的管理员列表
        /// </summary>
        /// <param name="keyWords">关键字</param>
        /// <returns></returns>
        public static List<ManagerInfo> GetManagers(string keyWords)
        {
            return Service.GetManagers(keyWords);
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码（明文）</param>
        /// <param name="isPlatFormManager">是否为平台管理员</param>
        /// <returns></returns>
        public static ManagerInfo Login(string username, string password)
        {
            return Service.Login(username, password);
        }

    }
}
