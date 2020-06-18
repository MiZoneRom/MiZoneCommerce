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
                var attributes = field.GetCustomAttributes(typeof(PrivilegeAttribute), true);
                if (attributes.Length == 0)
                {
                    continue;

                }
                GroupActionItem group = new GroupActionItem();
                ActionItem item = new ActionItem();
                List<string> actions = new List<string>();
                List<PrivilegeAttribute> attrs = new List<PrivilegeAttribute>();
                List<Controllers> ctrls = new List<Controllers>();

                foreach (var attr in attributes)
                {
                    Controllers ctrl = new Controllers();
                    var attribute = attr as PrivilegeAttribute;
                    ctrl.ControllerName = attribute.Controller;
                    ctrl.ActionNames.AddRange(attribute.Action.Split(','));
                    ctrls.Add(ctrl);
                    attrs.Add(attribute);
                }
                var groupInfo = attrs.FirstOrDefault(a => !string.IsNullOrEmpty(a.GroupName));
                if (sitesetting != null)
                {

                }

                group.Name = groupInfo.GroupName;
                item.PrivilegeId = groupInfo.Pid;
                item.Name = groupInfo.Name;
                item.Path = groupInfo.Url;
                item.Type = groupInfo.AdminCatalogType;
                item.Component = groupInfo.Component;

                item.Controllers.AddRange(ctrls);
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

                var attributes = field.GetCustomAttributes(typeof(PrivilegeAttribute), true);
                if (attributes.Length == 0)
                {
                    continue;
                }

                ActionItem item = new ActionItem();
                List<string> actions = new List<string>();
                List<PrivilegeAttribute> attrs = new List<PrivilegeAttribute>();
                List<Controllers> ctrls = new List<Controllers>();
                string linkTarget = string.Empty;

                foreach (var attr in attributes)
                {
                    Controllers ctrl = new Controllers();
                    var attribute = attr as PrivilegeAttribute;
                    if (!attribute.AdminCatalogType.Equals(Type))
                    {
                        continue;
                    }
                    ctrl.ControllerName = attribute.Controller;
                    ctrl.ActionNames.AddRange(attribute.Action.Split(','));
                    ctrls.Add(ctrl);
                    attrs.Add(attribute);
                    linkTarget = attribute.LinkTarget;
                }

                if (attrs.Count.Equals(0))
                {
                    continue;
                }

                var groupInfo = attrs.FirstOrDefault(a => !string.IsNullOrEmpty(a.GroupName));

                if (sitesetting != null)
                {

                }

                GroupActionItem group = new GroupActionItem();
                group.Name = groupInfo.GroupName;
                group.Path = "/";
                group.Component = "Layout";
                group.IconCls = "el-icon-edit";

                item.PrivilegeId = groupInfo.Pid;
                item.Name = groupInfo.Name;
                item.Path = groupInfo.Url;
                item.Type = groupInfo.AdminCatalogType;
                item.LinkTarget = linkTarget;
                item.Component = groupInfo.Component;
                item.Controllers.AddRange(ctrls);

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
