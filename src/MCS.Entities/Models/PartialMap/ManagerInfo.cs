using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.Entities
{
    public partial class ManagerInfo
    {
        [ForeignKey("Id", "RoleId")]
        public ManagerRoleInfo ManagerRole { get; set; }

        [ForeignKey("RoleId", "RoleId")]
        public List<ManagerRolePrivilegeInfo> ManagerRolePrivilege { get; set; }
    }
}
