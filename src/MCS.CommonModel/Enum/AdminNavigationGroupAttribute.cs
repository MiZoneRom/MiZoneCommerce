using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.CommonModel
{
    /// <summary>  
    ///描述枚举的属性  
    /// </summary>  
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class AdminNavigationGroupAttribute : Attribute
    {

        /// <summary>
        /// 图标
        /// </summary>
        public string IconCls { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        public string Component { get; set; }

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
        public AdminNavigationGroupAttribute(string component, string iconCls = "", AdminCatalogType type = MCS.CommonModel.AdminCatalogType.Default, string target = "")
        {
            this.Component = component;
            this.IconCls = iconCls;
            this.AdminCatalogType = type;
            this.LinkTarget = target;
        }

    }
}
