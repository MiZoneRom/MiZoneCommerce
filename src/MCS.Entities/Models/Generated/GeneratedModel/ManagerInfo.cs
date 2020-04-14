
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.Manager")]
     public partial class ManagerInfo
     {
        
        		public long Id {get;set;}
        		public long RoleId {get;set;}
        		public string UserName {get;set;}
        		public string Password {get;set;}
        		public string PasswordSalt {get;set;}
        		public DateTime? CreateDate {get;set;}
        		public string Remark {get;set;}
        		public string RealName {get;set;}
        
     }

}
