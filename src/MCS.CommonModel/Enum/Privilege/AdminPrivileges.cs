﻿using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.CommonModel
{
    public enum AdminPrivilege
    {
        /// <summary>
        /// 控制台
        /// </summary>
        [NavigationGroup(1000, "Dashboard", "控制台")]
        [NavigationIcon("", "el-icon-menu")]
        Dashboard = 1000,

        /// <summary>
        /// 主页
        /// </summary>
        [Privilege("Console", "/Console", "Home")]
        [Navigation(1001, 1000, "/Console", "主页", "Console")]
        [NavigationIcon("", "el-icon-menu")]
        Console = 1001,

        /// <summary>
        /// 系统设置
        /// </summary>
        [NavigationGroup(3000, "SiteSetting", "系统设置")]
        [NavigationIcon("", "el-icon-menu")]
        OrderSetting = 3000,

        [Privilege("SiteSettings", "/SiteSettings", "category")]
        [Navigation(3001, 3000, "/SiteSettings", "支付设置", "manage/SiteSettings")]
        [NavigationIcon("", "el-icon-s-tools")]
        PaymentSettings = 3001,




        /// <summary>
        /// 系统设置
        /// </summary>
        [NavigationGroup(2000, "SiteSetting", "系统设置")]
        [NavigationIcon("", "el-icon-menu")]
        SiteSetting = 2000,

        /// <summary>
        /// 网站设置
        /// </summary>
        [Privilege("SiteSettings", "/SiteSettings", "category")]
        [Navigation(2001, 2000, "/SiteSettings", "网站设置", "manage/SiteSettings")]
        [NavigationIcon("", "el-icon-s-tools")]
        SiteSettings = 2001,

        [Privilege("Manager", "/Manager", "category")]
        [Navigation(2002, 2000, "/Manager", "管理员", "manage/SiteSettings")]
        [NavigationIcon("", "el-icon-user-solid")]
        Manager = 2002,

        [Privilege("Privilege", "/Privilege", "category")]
        [Navigation(2003, 2000, "/Privilege", "权限组", "manage/SiteSettings")]
        [NavigationIcon("", "el-icon-s-check")]
        Privilege = 2003,

        [Privilege("OperationLog", "/OperationLog", "category")]
        [Navigation(2004, 2000, "/OperationLog", "操作日志", "manage/ManageLog")]
        [NavigationIcon("", "el-icon-s-claim")]
        OperationLog = 2004,

        [Privilege("OperationLog", "/OperationLog", "category")]
        [Navigation(2005, 2000, "/OperationLog", "消息设置", "manage/ManageLog")]
        [NavigationIcon("", "el-icon-s-claim")]
        MessageSettings = 2005,
    }
}