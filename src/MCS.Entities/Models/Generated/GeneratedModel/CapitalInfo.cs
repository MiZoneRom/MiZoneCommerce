
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.Capital")]
     public partial class CapitalInfo
     {
        
        		public long Id {get;set;}
        		public long UserId {get;set;}
        		public decimal Balance {get;set;}
        		public decimal FreezeAmount {get;set;}
        		public decimal ChargeAmount {get;set;}
        		public decimal PresentAmount {get;set;}
        
     }

}

