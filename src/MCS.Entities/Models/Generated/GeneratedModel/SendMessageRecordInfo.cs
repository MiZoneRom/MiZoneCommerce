
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
        
        		public long Id {get;set;}
        		public int MessageType {get;set;}
        		public int ContentType {get;set;}
        		public string SendContent {get;set;}
        		public string ToUserLabel {get;set;}
        		public int SendState {get;set;}
        		public DateTime SendTime {get;set;}
        
     }

}

