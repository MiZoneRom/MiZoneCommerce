
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.RolePrivilege")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class RolePrivilegeInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public int Privilege {get;set;}
        [Column] public long RoleId {get;set;}
        
     }

}

