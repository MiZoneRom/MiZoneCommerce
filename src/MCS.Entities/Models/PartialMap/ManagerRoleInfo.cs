using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MCS.Entities
{
    public partial class ManagerRoleInfo
    {
        [NotMapped]
        public virtual List<ManagerRolePrivilegeInfo> RolePrivileges { get; set; }
    }
}
