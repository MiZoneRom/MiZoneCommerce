
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WeiXinMsgTemplate")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WeiXinMsgTemplateInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public int MessageType {get;set;}
        [Column] public string TemplateNum {get;set;}
        [Column] public string TemplateId {get;set;}
        [Column] public DateTime UpdateDate {get;set;}
        [Column] public bool IsOpen {get;set;}
        [Column] public bool UserInWxApplet {get;set;}
        
     }

}

