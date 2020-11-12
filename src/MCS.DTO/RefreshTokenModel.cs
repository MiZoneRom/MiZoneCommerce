using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.DTO
{
    public class RefreshTokenModel
    {
        /// <summary>
        /// token
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 刷新token
        /// </summary>
        public string refresh_token { get; set; }
    }
}
