using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MCS.Entities
{
    public partial class RolesInfo
    {
        [NotMapped]
        public virtual List<RolePrivilegesInfo> RolePrivileges { get; set; }
    }
}
