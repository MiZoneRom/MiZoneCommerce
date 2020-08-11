using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using MCS.CommonModel;
using MCS.Application;
using MCS.Entities;
using MCS.DTO;

namespace MCS.Web.Framework
{
    public class PrivilegeHelper
    {
        private static Privileges adminPrivileges;
        private static Privileges adminPrivilegesDefault;
        private static Privileges adminPrivilegesInternal;
        private static Privileges userPrivileges;

        public static Privileges UserPrivileges
        {
            set
            {
                userPrivileges = value;
            }
            get
            {
                //if (userPrivileges == null)
                {
                    userPrivileges = GetPrivileges<UserPrivilege>();
                }
                return userPrivileges;
            }
        }

        /// <summary>
        /// 平台后台权限
        /// </summary>
        public static Privileges AdminPrivileges
        {
            set
            {
                adminPrivileges = value;
            }
            get
            {
                //if (adminPrivileges == null)
                {
                    adminPrivileges = GetPrivileges<AdminPrivilege>();
                }
                return adminPrivileges;
            }
        }


        /// <summary>
        /// 平台后台导航
        /// </summary>
        public static Privileges AdminPrivilegesDefault
        {
            set
            {
                adminPrivilegesDefault = value;
            }
            get
            {
                //if (adminPrivilegesDefault == null)
                {
                    adminPrivilegesDefault = GetPrivileges<AdminPrivilege>(AdminCatalogType.Default);
                }
                return adminPrivilegesDefault;
            }
        }

        /// <summary>
        /// 平台后台内部导航
        /// </summary>
        public static Privileges AdminPrivilegesInternal
        {
            set
            {
                adminPrivilegesInternal = value;
            }
            get
            {
                //if (adminPrivilegesInternal == null)
                {
                    adminPrivilegesInternal = GetPrivileges<AdminPrivilege>(AdminCatalogType.Internal);
                }
                return adminPrivilegesInternal;
            }
        }

        /// <summary>
        /// 相当于根目录的路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Privileges GetPrivileges<TEnum>()
        {
            SiteSettings sitesetting = SiteSettingApplication.SiteSettings;
            Type type = typeof(TEnum);
            FieldInfo[] fields = type.GetFields();
            if (fields.Length == 1)
            {
                return null;
            }
            Privileges p = new Privileges();
            foreach (var field in fields)
            {
                var privilegeAttributes = field.GetCustomAttributes(typeof(PrivilegeAttribute), true);

                if (privilegeAttributes.Length == 0)
                {
                    continue;
                }

                GroupActionItem group = new GroupActionItem();
                ActionItem item = new ActionItem();
                List<PrivilegeAttribute> privilegeAttributeList = new List<PrivilegeAttribute>();
                List<Controllers> ctrls = new List<Controllers>();

                foreach (var attr in privilegeAttributes)
                {
                    Controllers ctrl = new Controllers();
                    var attribute = attr as PrivilegeAttribute;
                    ctrl.ControllerName = attribute.Controller;
                    ctrl.ActionNames.AddRange(attribute.Action.Split(','));
                    ctrls.Add(ctrl);
                    privilegeAttributeList.Add(attribute);
                }

                //var privilegeAttributeGroupInfo = privilegeAttributeList.FirstOrDefault(a => !string.IsNullOrEmpty(a.GroupName));
                //if (sitesetting != null)
                //{

                //}

                //group.Name = privilegeAttributeGroupInfo.GroupName;

                //item.PrivilegeId = privilegeAttributeGroupInfo.Pid;
                //item.Name = privilegeAttributeGroupInfo.Name;
                //item.Path = privilegeAttributeGroupInfo.Url;
                item.Controllers.AddRange(ctrls);

                //获取导航属性
                var adminNavigations = field.GetCustomAttributes(typeof(AdminNavigationAttribute), true);

                if (adminNavigations.Count() > 0)
                {
                    List<AdminNavigationAttribute> adminNavigationAttributeList = new List<AdminNavigationAttribute>();
                    foreach (var attr in adminNavigations)
                    {
                        var attribute = attr as AdminNavigationAttribute;
                        adminNavigationAttributeList.Add(attribute);
                    }

                    var adminNavigationGroupInfo = adminNavigationAttributeList.FirstOrDefault(a => !string.IsNullOrEmpty(a.Component));

                    item.IconCls = adminNavigationGroupInfo.IconCls;
                    item.Type = adminNavigationGroupInfo.AdminCatalogType;
                    item.LinkTarget = adminNavigationGroupInfo.LinkTarget;
                    item.Component = adminNavigationGroupInfo.Component;

                }

                var currentGroup = p.Privilege.FirstOrDefault(a => a.Name == group.Name);

                if (currentGroup == null)
                {
                    group.Children.Add(item);
                    group.IconCls = item.IconCls;
                    p.Privilege.Add(group);
                }
                else
                {
                    currentGroup.Children.Add(item);
                }
            }

            return p;
        }

        /// <summary>
        /// 相当于根目录的路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Type">导航类别</param>
        /// <returns></returns>
        public static Privileges GetPrivileges<TEnum>(AdminCatalogType Type)
        {
            SiteSettings sitesetting = SiteSettingApplication.SiteSettings;
            Type type = typeof(TEnum);
            FieldInfo[] fields = type.GetFields();

            if (fields.Length == 1)
            {
                return null;
            }

            Privileges p = new Privileges();

            foreach (var field in fields)
            {

                //导航分组
                var adminNavigationsGroupAttributes = field.GetCustomAttributes(typeof(AdminNavigationGroupAttribute), true);

                //如果是分组
                if (adminNavigationsGroupAttributes.Count() > 0)
                {
                    GroupActionItem group = new GroupActionItem();

                    List<AdminNavigationGroupAttribute> adminNavigationsGroupAttributeList = new List<AdminNavigationGroupAttribute>();

                    foreach (var attr in adminNavigationsGroupAttributes)
                    {
                        var attribute = attr as AdminNavigationGroupAttribute;
                        adminNavigationsGroupAttributeList.Add(attribute);
                    }

                    var adminNavigationAttribute = adminNavigationsGroupAttributeList.FirstOrDefault(a => !string.IsNullOrEmpty(a.Name));
                    group.Name = adminNavigationAttribute.GroupName;
                    group.IconCls = adminNavigationAttribute.IconCls;
                    group.Path = "/";
                    group.Component = "Layout";
                    group.GroupId = adminNavigationAttribute.NavigationId;

                    p.Privilege.Add(group);
                }
                else
                {

                    //权限属性
                    var privilegeAttributes = field.GetCustomAttributes(typeof(PrivilegeAttribute), true);
                    //权限列表
                    List<PrivilegeAttribute> privilegeAttributeList = new List<PrivilegeAttribute>();
                    //控制器列表
                    List<Controllers> ctrls = new List<Controllers>();

                    foreach (var attr in privilegeAttributes)
                    {
                        Controllers ctrl = new Controllers();
                        var attribute = attr as PrivilegeAttribute;
                        ctrl.ControllerName = attribute.Controller;
                        ctrl.ActionNames.AddRange(attribute.Action.Split(','));
                        ctrls.Add(ctrl);
                        privilegeAttributeList.Add(attribute);
                    }

                    ActionItem item = new ActionItem();

                    item.Controllers.AddRange(ctrls);

                    //获取导航属性
                    var adminNavigationsAttributes = field.GetCustomAttributes(typeof(AdminNavigationAttribute), true);

                    if (adminNavigationsAttributes.Count() > 0)
                    {

                        List<AdminNavigationAttribute> adminNavigationsAttributeList = new List<AdminNavigationAttribute>();

                        foreach (var attr in adminNavigationsAttributes)
                        {
                            var attribute = attr as AdminNavigationAttribute;
                            adminNavigationsAttributeList.Add(attribute);
                        }

                        var adminNavigationAttribute = adminNavigationsAttributeList.FirstOrDefault(a => !string.IsNullOrEmpty(a.NavigationName));

                        item.IconCls = adminNavigationAttribute.IconCls;
                        item.Type = adminNavigationAttribute.AdminCatalogType;
                        item.LinkTarget = adminNavigationAttribute.LinkTarget;
                        item.Component = adminNavigationAttribute.Component;
                        item.Name = adminNavigationAttribute.NavigationName;
                        item.Path = adminNavigationAttribute.Url;
                        item.PrivilegeId = adminNavigationAttribute.NavigationId;
                        item.GroupId = adminNavigationAttribute.GroupId;
                    }

                    var currentGroup = p.Privilege.FirstOrDefault(a => a.GroupId == item.GroupId);
                    if (currentGroup != null)
                    {
                        currentGroup.Children.Add(item);
                    }

                }

            }
            return p;
        }
    }
}
