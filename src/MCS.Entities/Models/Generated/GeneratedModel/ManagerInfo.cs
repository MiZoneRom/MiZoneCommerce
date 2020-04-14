
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
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "RoleId",  isColumn: true)]
		public long RoleId {get;set;}

        
		[Column(name: "UserName",  isColumn: true)]
		public string UserName {get;set;}

        
		[Column(name: "Password",  isColumn: true)]
		public string Password {get;set;}

        
		[Column(name: "PasswordSalt",  isColumn: true)]
		public string PasswordSalt {get;set;}

        
		[Column(name: "CreateDate",  isColumn: true)]
		public DateTime? CreateDate {get;set;}

        
		[Column(name: "Remark",  isColumn: true)]
		public string Remark {get;set;}

        
		[Column(name: "RealName",  isColumn: true)]
		public string RealName {get;set;}

        
     }

}

