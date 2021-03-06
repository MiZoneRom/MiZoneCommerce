﻿using Kogel.Dapper.Extension.Core.SetQ;
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

        /// <summary>
        /// 获取导航列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 获取导航列表
        /// </summary>
        /// <returns></returns>
        public List<ManagerNavigationInfo> GetNavigations()
        {
            var navigations = Context.QuerySet<ManagerNavigationInfo>().Where(item => item.Id > 0).ToList();
            return navigations;
        }

        /// <summary>
        /// 获取导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ManagerNavigationInfo GetNavigation(long id)
        {
            return Context.QuerySet<ManagerNavigationInfo>().Where(a => a.Id == id).Get();
        }

        /// <summary>
        /// 更新导航
        /// </summary>
        /// <param name="model"></param>
        /// <param name="actions"></param>
        /// <returns></returns>
        public bool UpdateNavigation(ManagerNavigationInfo model, List<ManagerNavigationActionInfo> actions = null)
        {
            if (model.Id > 0)
            {
                Context.CommandSet<ManagerNavigationInfo>().Where(item => item.Id == model.Id).Update(model);
                Context.CommandSet<ManagerNavigationActionInfo>().Where(item => item.NavigationId == model.Id).Delete();
            }
            else
            {
                model.Id = Context.CommandSet<ManagerNavigationInfo>().Insert(model);
            }

            //操作赋值
            if (actions != null && actions.Count() > 0)
            {
                foreach (var item in actions)
                {
                    item.NavigationId = model.Id;
                }
                Context.CommandSet<ManagerNavigationActionInfo>().Insert(actions);
            }

            return true;
        }

        /// <summary>
        /// 获取导航子权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ManagerNavigationActionInfo> GetNavigationActions(long id)
        {
            return Context.QuerySet<ManagerNavigationActionInfo>().Where(a => a.NavigationId == id).ToList();
        }

        /// <summary>
        /// 获取操作类型
        /// </summary>
        /// <returns></returns>
        public List<ManagerActionInfo> GetActions()
        {
            return Context.QuerySet<ManagerActionInfo>().Where(a => a.Id > 0).ToList();
        }

    }
}
