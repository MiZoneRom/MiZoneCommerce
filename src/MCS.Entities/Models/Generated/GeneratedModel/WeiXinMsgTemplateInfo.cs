
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WeiXinMsgTemplate")]
     public partial class WeiXinMsgTemplateInfo
     {
        
        		public long Id {get;set;}
        		public int MessageType {get;set;}
        		public string TemplateNum {get;set;}
        		public string TemplateId {get;set;}
        		public DateTime UpdateDate {get;set;}
        		public bool IsOpen {get;set;}
        		public bool UserInWxApplet {get;set;}
        
     }

}

