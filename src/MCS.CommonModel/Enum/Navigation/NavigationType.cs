using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MCS.CommonModel
{
    public enum NavigationType
    {
        /// <summary>
        /// PC端
        /// </summary>
        [Description("PC端")]
        Web = 1,
        /// <summary>
        /// 移动端
        /// </summary>
        [Description("移动端")]
        Mobile = 2,
        /// <summary>
        /// 后台
        /// </summary>
        [Description("后台")]
        Admin = 99
    }
}
