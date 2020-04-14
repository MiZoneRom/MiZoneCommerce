
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.Role")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class RoleInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public string RoleName {get;set;}
        [Column] public string Description {get;set;}
        
     }

}

