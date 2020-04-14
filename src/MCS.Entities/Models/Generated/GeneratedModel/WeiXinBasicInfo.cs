
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WeiXinBasic")]
     public partial class WeiXinBasicInfo
     {
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "Ticket",  isColumn: true)]
		public string Ticket {get;set;}

        
		[Column(name: "TicketOutTime",  isColumn: true)]
		public DateTime TicketOutTime {get;set;}

        
		[Column(name: "AppId",  isColumn: true)]
		public string AppId {get;set;}

        
		[Column(name: "AccessToken",  isColumn: true)]
		public string AccessToken {get;set;}

        
     }

}

