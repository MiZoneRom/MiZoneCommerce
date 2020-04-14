
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.SendMessageRecord")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class SendMessageRecordInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public int MessageType {get;set;}
        [Column] public int ContentType {get;set;}
        [Column] public string SendContent {get;set;}
        [Column] public string ToUserLabel {get;set;}
        [Column] public int SendState {get;set;}
        [Column] public DateTime SendTime {get;set;}
        
     }

}

