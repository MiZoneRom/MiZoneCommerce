
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
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "Privilege",  isColumn: true)]
		public int Privilege {get;set;}

        
		[Column(name: "RoleId",  isColumn: true)]
		public long RoleId {get;set;}

        
     }

}

