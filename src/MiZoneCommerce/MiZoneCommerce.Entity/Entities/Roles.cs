using System;
using System.Collections.Generic;

namespace MiZoneCommerce.Entity.Entities
{
    /// <summary>
    /// 角色
    /// </summary>
    public partial class Roles
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
