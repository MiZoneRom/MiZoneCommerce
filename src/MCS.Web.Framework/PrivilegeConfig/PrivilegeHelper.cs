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

                var privilegeAttributeGroupInfo = privilegeAttributeList.FirstOrDefault(a => !string.IsNullOrEmpty(a.GroupName));
                if (sitesetting != null)
                {

                }

                group.Name = privilegeAttributeGroupInfo.GroupName;

                item.PrivilegeId = privilegeAttributeGroupInfo.Pid;
                item.Name = privilegeAttributeGroupInfo.Name;
                item.Path = privilegeAttributeGroupInfo.Url;
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
                //权限属性
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

                if (privilegeAttributeList.Count.Equals(0))
                {
                    continue;
                }

                var privilegeAttributeGroupInfo = privilegeAttributeList.FirstOrDefault(a => !string.IsNullOrEmpty(a.GroupName));

                group.Name = privilegeAttributeGroupInfo.GroupName;
                group.Path = "/";
                group.Component = "Layout";

                item.PrivilegeId = privilegeAttributeGroupInfo.Pid;
                item.Name = privilegeAttributeGroupInfo.Name;
                item.Path = privilegeAttributeGroupInfo.Url;
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
                    p.Privilege.Add(group);
                }
                else
                {
                    currentGroup.Children.Add(item);
                }

            }
            return p;
        }
    }
}
