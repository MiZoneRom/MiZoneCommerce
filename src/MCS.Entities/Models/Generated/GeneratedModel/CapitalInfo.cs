
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
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "UserId",  isColumn: true)]
		public long UserId {get;set;}

        
		[Column(name: "Balance",  isColumn: true)]
		public decimal Balance {get;set;}

        
		[Column(name: "FreezeAmount",  isColumn: true)]
		public decimal FreezeAmount {get;set;}

        
		[Column(name: "ChargeAmount",  isColumn: true)]
		public decimal ChargeAmount {get;set;}

        
		[Column(name: "PresentAmount",  isColumn: true)]
		public decimal PresentAmount {get;set;}

        
     }

}

