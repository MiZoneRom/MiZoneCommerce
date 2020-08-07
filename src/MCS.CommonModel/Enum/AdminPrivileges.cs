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
        //控制台
        [Privilege("控制台", "主页", 1001, "/Console", "category")]
        [AdminNavigation("Console", "el-icon-menu")]
        Console = 1001,

        //系统管理
        [Privilege("系统管理", "网站设置", 2001, "/SiteSettings", "category")]
        [AdminNavigation("manage/SiteSettings", "el-icon-s-tools")]
        SiteSettings = 2001,

        [Privilege("系统管理", "管理员", 2001, "/Manager", "category")]
        [AdminNavigation("manage/SiteSettings", "el-icon-user-solid")]
        Manager = 2002,

        [Privilege("系统管理", "权限组", 2001, "/Privilege", "category")]
        [AdminNavigation("manage/SiteSettings", "el-icon-s-check")]
        Privilege = 2003,

        [Privilege("系统管理", "操作日志", 2001, "/OperationLog", "category")]
        [AdminNavigation("manage/ManageLog", "el-icon-s-claim")]
        OperationLog = 2004,
    }
}
