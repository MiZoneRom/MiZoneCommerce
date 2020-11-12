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
            return GetPrivileges<TEnum>(null);
        }

        /// <summary>
        /// 相当于根目录的路径
        /// </summary>
        /// <param name="catalogType">导航类别</param>
        /// <returns></returns>
        public static Privileges GetPrivileges<TEnum>(AdminCatalogType? catalogType)
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
                var adminNavigationsGroupAttributes = field.GetCustomAttributes(typeof(NavigationGroupAttribute), true).Select(a => a as NavigationGroupAttribute).FirstOrDefault(a => !string.IsNullOrEmpty(a.Name));

                //导航图标
                var adminNavigationsIconAttributes = field.GetCustomAttributes(typeof(NavigationIconAttribute), true).Select(a => a as NavigationIconAttribute).FirstOrDefault(a => !string.IsNullOrEmpty(a.Icon) || !string.IsNullOrEmpty(a.ApiIcon));

                //如果是分组
                if (adminNavigationsGroupAttributes != null)
                {
                    GroupActionItem group = new GroupActionItem();

                    //List<NavigationGroupAttribute> adminNavigationsGroupAttributeList = new List<NavigationGroupAttribute>();
                    //foreach (var attr in adminNavigationsGroupAttributes)
                    //{
                    //    var attribute = attr as NavigationGroupAttribute;
                    //    adminNavigationsGroupAttributeList.Add(attribute);
                    //}

                    //List<NavigationIconAttribute> adminNavigationsIconAttributeList = new List<NavigationIconAttribute>();
                    //foreach (var attr in adminNavigationsIconAttributes)
                    //{
                    //    var attribute = attr as NavigationIconAttribute;
                    //    adminNavigationsIconAttributeList.Add(attribute);
                    //}

                    //var adminNavigationGroupAttribute = adminNavigationsGroupAttributeList.FirstOrDefault(a => !string.IsNullOrEmpty(a.Name));
                    //var adminNavigationIconAttribute = adminNavigationsIconAttributeList.FirstOrDefault(a => !string.IsNullOrEmpty(a.Icon) || !string.IsNullOrEmpty(a.ApiIcon));

                    group.Name = adminNavigationsGroupAttributes.GroupName;
                    group.Icon = adminNavigationsIconAttributes.Icon;
                    group.IconCls = adminNavigationsIconAttributes.ApiIcon;
                    group.Path = "/";
                    group.Component = "Layout";
                    group.GroupId = adminNavigationsGroupAttributes.NavigationId;

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
                    var adminNavigationsItemAttributes = field.GetCustomAttributes(typeof(NavigationAttribute), true).Select(a => a as NavigationAttribute).FirstOrDefault(a => !string.IsNullOrEmpty(a.NavigationName));
                    //获取导航属性
                    var adminNavigationsItemIconAttributes = field.GetCustomAttributes(typeof(NavigationIconAttribute), true).Select(a => a as NavigationIconAttribute).FirstOrDefault(a => !string.IsNullOrEmpty(a.Icon) || !string.IsNullOrEmpty(a.ApiIcon));

                    if (adminNavigationsItemAttributes != null)
                    {

                        //List<NavigationAttribute> adminNavigationsAttributeList = new List<NavigationAttribute>();

                        //foreach (var attr in adminNavigationsAttributes)
                        //{
                        //    var attribute = attr as NavigationAttribute;
                        //    adminNavigationsAttributeList.Add(attribute);
                        //}

                        //var adminNavigationAttribute = adminNavigationsAttributeList.FirstOrDefault(a => !string.IsNullOrEmpty(a.NavigationName));

                        //如果有导航筛选
                        if (catalogType.HasValue && !adminNavigationsItemAttributes.AdminCatalogType.Equals(catalogType))
                        {
                            continue;
                        }

                        item.Icon = adminNavigationsItemIconAttributes.Icon;
                        item.IconCls = adminNavigationsItemIconAttributes.ApiIcon;
                        item.Type = adminNavigationsItemAttributes.AdminCatalogType;
                        item.LinkTarget = adminNavigationsItemAttributes.LinkTarget;
                        item.Component = adminNavigationsItemAttributes.Component;
                        item.Name = adminNavigationsItemAttributes.NavigationName;
                        item.Path = adminNavigationsItemAttributes.Url;
                        item.PrivilegeId = adminNavigationsItemAttributes.NavigationId;
                        item.GroupId = adminNavigationsItemAttributes.GroupId;
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
