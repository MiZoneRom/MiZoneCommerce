
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.WXAppletFormData")]
     public partial class WXAppletFormDataInfo
     {
        
        
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "EventId",  isColumn: true)]
		public long EventId {get;set;}

        
		[Column(name: "EventValue",  isColumn: true)]
		public string EventValue {get;set;}

        
		[Column(name: "FormId",  isColumn: true)]
		public string FormId {get;set;}

        
		[Column(name: "EventTime",  isColumn: true)]
		public DateTime EventTime {get;set;}

        
		[Column(name: "ExpireTime",  isColumn: true)]
		public DateTime ExpireTime {get;set;}

        
     }

}

