
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberOpenId")]
     public partial class MemberOpenIdInfo
     {
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "UserId",  isColumn: true)]
		public long UserId {get;set;}

        
		[Column(name: "OpenId",  isColumn: true)]
		public string OpenId {get;set;}

        
		[Column(name: "UnionOpenId",  isColumn: true)]
		public string UnionOpenId {get;set;}

        
		[Column(name: "UnionId",  isColumn: true)]
		public string UnionId {get;set;}

        
		[Column(name: "ServiceProvider",  isColumn: true)]
		public string ServiceProvider {get;set;}

        
		[Column(name: "AppIdType",  isColumn: true)]
		public int AppIdType {get;set;}

        
     }

}

