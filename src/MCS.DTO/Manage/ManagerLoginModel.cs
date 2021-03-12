using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.DTO
{
    public class ManagerLoginModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public string Expires { get; set; }
        public string RefreshExpires { get; set; }
    }
}
