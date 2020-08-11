using MCS.CommonModel;
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
        [AdminNavigationGroup("Dashboard", "控制台", "el-icon-menu")]
        Dashboard = 1000,

        /// <summary>
        /// 主页
        /// </summary>
        [Privilege("Console", "/Console", "category")]
        [AdminNavigation(1000, "主页", "Console", "el-icon-menu")]
        Console = 1001,

        /// <summary>
        /// 系统设置
        /// </summary>
        [AdminNavigationGroup("Dashboard", "控制台", "el-icon-menu")]
        SiteSetting = 2000,

        /// <summary>
        /// 网站设置
        /// </summary>
        [Privilege("SiteSettings", "/SiteSettings", "category")]
        [AdminNavigation(2000, "网站设置", "manage/SiteSettings", "el-icon-s-tools")]
        SiteSettings = 2001,

        [Privilege("Manager", "/Manager", "category")]
        [AdminNavigation(2000, "管理员", "manage/SiteSettings", "el-icon-user-solid")]
        Manager = 2002,

        [Privilege("Privilege", "/Privilege", "category")]
        [AdminNavigation(2000, "权限组", "manage/SiteSettings", "el-icon-s-check")]
        Privilege = 2003,

        [Privilege("OperationLog", "/OperationLog", "category")]
        [AdminNavigation(2000, "操作日志", "manage/ManageLog", "el-icon-s-claim")]
        OperationLog = 2004,
    }
}
