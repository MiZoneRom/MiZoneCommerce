
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberIntegralRecord")]
     public partial class MemberIntegralRecordInfo
     {
        
        		public long Id {get;set;}
        		public long UserId {get;set;}
        		public string UserName {get;set;}
        		public int TypeId {get;set;}
        		public int Integral {get;set;}
        		public DateTime CreateDate {get;set;}
        		public string Remark {get;set;}
        
     }

}

