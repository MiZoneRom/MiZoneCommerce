
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
        
        		public long Id {get;set;}
        		public string Ticket {get;set;}
        		public DateTime TicketOutTime {get;set;}
        		public string AppId {get;set;}
        		public string AccessToken {get;set;}
        
     }

}

