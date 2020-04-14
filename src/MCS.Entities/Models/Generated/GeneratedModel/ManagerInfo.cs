
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.Manager")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class ManagerInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long RoleId {get;set;}
        [Column] public string UserName {get;set;}
        [Column] public string Password {get;set;}
        [Column] public string PasswordSalt {get;set;}
        [Column] public DateTime? CreateDate {get;set;}
        [Column] public string Remark {get;set;}
        [Column] public string RealName {get;set;}
        
     }

}

