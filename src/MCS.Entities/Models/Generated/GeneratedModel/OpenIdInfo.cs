
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.OpenId")]
     public partial class OpenIdInfo
     {
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "OpenId",  isColumn: true)]
		public string OpenId {get;set;}

        
		[Column(name: "SubscribeTime",  isColumn: true)]
		public DateTime SubscribeTime {get;set;}

        
		[Column(name: "IsSubscribe",  isColumn: true)]
		public bool IsSubscribe {get;set;}

        
     }

}

