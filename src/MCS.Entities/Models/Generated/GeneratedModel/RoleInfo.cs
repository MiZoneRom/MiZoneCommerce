
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.Role")]
     public partial class RoleInfo
     {
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "RoleName",  isColumn: true)]
		public string RoleName {get;set;}

        
		[Column(name: "Description",  isColumn: true)]
		public string Description {get;set;}

        
     }

}

