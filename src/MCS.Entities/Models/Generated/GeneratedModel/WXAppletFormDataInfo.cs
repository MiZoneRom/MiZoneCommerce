
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
        
        		public long Id {get;set;}
        		public long EventId {get;set;}
        		public string EventValue {get;set;}
        		public string FormId {get;set;}
        		public DateTime EventTime {get;set;}
        		public DateTime ExpireTime {get;set;}
        
     }

}

