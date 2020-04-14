
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MessageLog")]
     public partial class MessageLogInfo
     {
        
        		public long Id {get;set;}
        		public long UserId {get;set;}
        		public string TypeId {get;set;}
        		public string MessageContent {get;set;}
        		public DateTime CreateDate {get;set;}
        
     }

}

