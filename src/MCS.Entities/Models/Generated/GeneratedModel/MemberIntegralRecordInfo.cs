
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberIntegralRecord")]
     public partial class MemberIntegralRecordInfo
     {
        
        
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "UserId",  isColumn: true)]
		public long UserId {get;set;}

        
		[Column(name: "UserName",  isColumn: true)]
		public string UserName {get;set;}

        
		[Column(name: "TypeId",  isColumn: true)]
		public int TypeId {get;set;}

        
		[Column(name: "Integral",  isColumn: true)]
		public int Integral {get;set;}

        
		[Column(name: "CreateDate",  isColumn: true)]
		public DateTime CreateDate {get;set;}

        
		[Column(name: "Remark",  isColumn: true)]
		public string Remark {get;set;}

        
     }

}

