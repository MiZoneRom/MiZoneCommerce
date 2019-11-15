using System;
using System.Collections.Generic;

namespace MiZoneCommerce.Entity.Entities
{
    /// <summary>
    /// 管理员
    /// </summary>
    public partial class Managers
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime CreateDate { get; set; }
        public string Remark { get; set; }
        public string RealName { get; set; }
        public string Avatars { get; set; }
    }
}
