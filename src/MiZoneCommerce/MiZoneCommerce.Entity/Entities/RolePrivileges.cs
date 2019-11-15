using MiZoneCommerce.Model;
using System;
using System.Collections.Generic;

namespace MiZoneCommerce.Entity.Entities
{
    public partial class RolePrivileges : BaseModel
    {
        public long Id { get; set; }
        public int Privilege { get; set; }
        public long RoleId { get; set; }
    }
}
