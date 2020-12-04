using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.Core
{
    public class JsonErrorResponse
    {
        public bool Success { get; set; }
        /// <summary>
        /// 生产环境的消息 
        /// /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 开发环境的消息 
        /// /// </summary>
        public string devMsg { get; set; }
    }
}
