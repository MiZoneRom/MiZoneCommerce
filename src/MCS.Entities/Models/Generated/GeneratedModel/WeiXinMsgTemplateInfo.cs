
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
        
        
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "MessageType",  isColumn: true)]
		public int MessageType {get;set;}

        
		[Column(name: "TemplateNum",  isColumn: true)]
		public string TemplateNum {get;set;}

        
		[Column(name: "TemplateId",  isColumn: true)]
		public string TemplateId {get;set;}

        
		[Column(name: "UpdateDate",  isColumn: true)]
		public DateTime UpdateDate {get;set;}

        
		[Column(name: "IsOpen",  isColumn: true)]
		public bool IsOpen {get;set;}

        
		[Column(name: "UserInWxApplet",  isColumn: true)]
		public bool UserInWxApplet {get;set;}

        
     }

}

