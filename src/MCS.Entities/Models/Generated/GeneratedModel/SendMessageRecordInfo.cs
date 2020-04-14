
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.SendMessageRecord")]
     public partial class SendMessageRecordInfo
     {
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "MessageType",  isColumn: true)]
		public int MessageType {get;set;}

        
		[Column(name: "ContentType",  isColumn: true)]
		public int ContentType {get;set;}

        
		[Column(name: "SendContent",  isColumn: true)]
		public string SendContent {get;set;}

        
		[Column(name: "ToUserLabel",  isColumn: true)]
		public string ToUserLabel {get;set;}

        
		[Column(name: "SendState",  isColumn: true)]
		public int SendState {get;set;}

        
		[Column(name: "SendTime",  isColumn: true)]
		public DateTime SendTime {get;set;}

        
     }

}

