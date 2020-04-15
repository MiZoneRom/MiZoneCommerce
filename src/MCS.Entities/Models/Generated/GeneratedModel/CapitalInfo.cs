
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
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id", key: ColumnKey.Primary, isColumn: true)]
		public long Id { get; set; }
        
		/// <summary>
        /// UserId
        /// </summary>
		[Column(name: "UserId", isColumn: true)]
		public long UserId { get; set; }
        
		/// <summary>
        /// Balance
        /// </summary>
		[Column(name: "Balance", isColumn: true)]
		public decimal Balance { get; set; }
        
		/// <summary>
        /// FreezeAmount
        /// </summary>
		[Column(name: "FreezeAmount", isColumn: true)]
		public decimal FreezeAmount { get; set; }
        
		/// <summary>
        /// ChargeAmount
        /// </summary>
		[Column(name: "ChargeAmount", isColumn: true)]
		public decimal ChargeAmount { get; set; }
        
		/// <summary>
        /// PresentAmount
        /// </summary>
		[Column(name: "PresentAmount", isColumn: true)]
		public decimal PresentAmount { get; set; }
        
     }

}

