
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MessageLog")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MessageLogInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public string TypeId {get;set;}
        [Column] public string MessageContent {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        
     }

}

