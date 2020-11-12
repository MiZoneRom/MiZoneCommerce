﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MCS.CommonModel
{
    /// <summary>  
    ///导航分组属性
    /// </summary>  
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class NavigationGroupAttribute : Attribute
    {
        /// <summary>
        /// 分组Id
        /// </summary>
        public int NavigationId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Component">模块</param>
        /// <param name="IconCls">图标</param>
        /// <param name="type">是否显示在导航中</param>
        /// <param name="target">目标</param>
        public NavigationGroupAttribute(int navigationId, string name, string groupName)
        {
            this.NavigationId = navigationId;
            this.Name = name;
            this.GroupName = groupName;
        }

    }
}