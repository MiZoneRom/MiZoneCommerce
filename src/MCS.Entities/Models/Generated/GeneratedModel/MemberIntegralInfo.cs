
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberIntegral")]
     public partial class MemberIntegralInfo
     {
        
        		public long Id {get;set;}
        		public long UserId {get;set;}
        		public string UserName {get;set;}
        		public int HistoryIntegrals {get;set;}
        		public int AvailableIntegrals {get;set;}
        
     }

}

