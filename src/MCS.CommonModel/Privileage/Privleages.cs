using System.Collections.Generic;
using System.Linq;

namespace MCS.CommonModel
{
    public class Privileges
    {
        public Privileges()
        {
            Privilege = new List<GroupActionItem>();
        }
        public List<GroupActionItem> Privilege { get; set; }
    }

    /// <summary>
    /// 分组
    /// </summary>
    public class GroupActionItem
    {
        public GroupActionItem()
        {
            Children = new List<ActionItem>();
        }

        /// <summary>
        ///路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { set; get; }

        public int GroupId { get; set; }

        /// <summary>
        /// 组件
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string IconCls { get; set; }

        /// <summary>
        /// 子项
        /// </summary>
        public List<ActionItem> Children { get; set; }

    }

    /// <summary>
    /// 路由子项
    /// </summary>
    public class ActionItem
    {
        public ActionItem()
        {
            Controllers = new List<Controllers>();
        }

        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 组件
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string IconCls { get; set; }

        /// <summary>
        /// 跳转
        /// </summary>
        public string Redirect { get; set; }

        /// <summary>
        /// 控制器
        /// </summary>
        public List<Controllers> Controllers { set; get; }

        /// <summary>
        /// 权限Id
        /// </summary>
        public int PrivilegeId { get; set; }

        /// <summary>
        /// 分组Id
        /// </summary>
        public int GroupId { get; set; }

        public MCS.CommonModel.AdminCatalogType Type { get; set; }

        /// <summary>
        /// 链接打开方式，blank,parent,self,top
        /// </summary>
        public string LinkTarget { get; set; }
    }

    /// <summary>
    /// 控制器
    /// </summary>
    public class Controllers
    {
        public Controllers()
        {
            ActionNames = new List<string>();
        }
        public string ControllerName { set; get; }
        public List<string> ActionNames { set; get; }
    }

}
