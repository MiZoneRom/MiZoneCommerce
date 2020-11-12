using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.CommonModel
{
    /// <summary>  
    /// 导航图标
    /// </summary>  
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class NavigationIconAttribute : Attribute
    {
        public string Icon { get; set; }
        public string ApiIcon { get; set; }

        public NavigationIconAttribute(string icon = "", string apiIcon = "")
        {
            this.Icon = icon;
            this.ApiIcon = apiIcon;
        }

    }
}
