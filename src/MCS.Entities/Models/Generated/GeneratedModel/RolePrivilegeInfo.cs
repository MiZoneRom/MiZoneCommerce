
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.RolePrivilege")]
     public partial class RolePrivilegeInfo
     {
        
        		public long Id {get;set;}
        		public int Privilege {get;set;}
        		public long RoleId {get;set;}
        
     }

}

