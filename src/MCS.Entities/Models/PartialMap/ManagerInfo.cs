using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.Entities
{
    public partial class ManagerInfo
    {
        [Display(IsField = false)]
        public virtual List<AdminPrivilege> AdminPrivileges { get; set; }
    }
}
