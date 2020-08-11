using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.CommonModel
{
    /// <summary>  
    /// 导航条目属性
    /// </summary>  
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class AdminNavigationAttribute : Attribute
    {
        /// <summary>
        /// 分组Id
        /// </summary>
        public int NavigationId { get; set; }

        /// <summary>
        /// 分组Id
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { set; get; }

        /// <summary>
        /// 导航名称
        /// </summary>
        public string NavigationName { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string IconCls { get; set; }

        /// <summary>
        /// 是否显示在导航中
        /// </summary>
        public AdminCatalogType AdminCatalogType { get; set; }

        /// <summary>
        /// 链接打开方式，blank,parent,self,top
        /// </summary>
        public string LinkTarget { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Component">模块</param>
        /// <param name="IconCls">图标</param>
        /// <param name="type">是否显示在导航中</param>
        /// <param name="target">目标</param>
        public AdminNavigationAttribute(int navigationId, int groupId, string url, string navigationName, string component, string iconCls = "", AdminCatalogType type = MCS.CommonModel.AdminCatalogType.Default, string target = "")
        {
            this.NavigationId = navigationId;
            this.GroupId = groupId;
            this.Url = url;
            this.NavigationName = navigationName;
            this.Component = component;
            this.IconCls = iconCls;
            this.AdminCatalogType = type;
            this.LinkTarget = target;
        }

    }
}
