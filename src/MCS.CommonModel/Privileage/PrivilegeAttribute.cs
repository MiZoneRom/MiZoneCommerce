using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.CommonModel
{
    /// <summary>  
    /// 后台导航权限
    /// </summary>  
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class PrivilegeAttribute : Attribute
    {

        /// <summary>
        /// 权限名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { set; get; }

        /// <summary>
        /// 权限包含的控制器名
        /// </summary>
        public string Controller { set; get; }

        /// <summary>
        /// 方法名
        /// </summary> 
        public string Action { set; get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GroupName">权限组名</param>
        /// <param name="Name">权限名</param>
        /// <param name="Pid">权限Id</param>
        /// <param name="Url">权限地址</param>
        /// <param name="Controller">权限包含的控制器</param>
        /// <param name="Action">权限包含的action</param>
        public PrivilegeAttribute(string name, string url, string controller, string action = "", AdminCatalogType type = MCS.CommonModel.AdminCatalogType.Default)
        {
            this.Name = name;
            this.Url = url;
            this.Action = action;
            this.Controller = controller;
        }

    }
}
