
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
        
        		public long Id {get;set;}
        		public string RoleName {get;set;}
        		public string Description {get;set;}
        
     }

}

