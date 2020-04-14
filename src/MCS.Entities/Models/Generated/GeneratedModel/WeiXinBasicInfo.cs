
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WeiXinBasic")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WeiXinBasicInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public string Ticket {get;set;}
        [Column] public DateTime TicketOutTime {get;set;}
        [Column] public string AppId {get;set;}
        [Column] public string AccessToken {get;set;}
        
     }

}

