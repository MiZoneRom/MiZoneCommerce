
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberIntegral")]
     public partial class MemberIntegralInfo
     {
        
        
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "UserId",  isColumn: true)]
		public long UserId {get;set;}

        
		[Column(name: "UserName",  isColumn: true)]
		public string UserName {get;set;}

        
		[Column(name: "HistoryIntegrals",  isColumn: true)]
		public int HistoryIntegrals {get;set;}

        
		[Column(name: "AvailableIntegrals",  isColumn: true)]
		public int AvailableIntegrals {get;set;}

        
     }

}

