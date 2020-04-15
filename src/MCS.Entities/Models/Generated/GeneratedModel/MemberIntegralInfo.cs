
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
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id", key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }
        
		/// <summary>
        /// UserId
        /// </summary>
		[Column(name: "UserId", isColumn: true)]
		public long UserId { get; set; }
        
		/// <summary>
        /// UserName
        /// </summary>
		[Column(name: "UserName", isColumn: true)]
		public string UserName { get; set; }
        
		/// <summary>
        /// HistoryIntegrals
        /// </summary>
		[Column(name: "HistoryIntegrals", isColumn: true)]
		public int HistoryIntegrals { get; set; }
        
		/// <summary>
        /// AvailableIntegrals
        /// </summary>
		[Column(name: "AvailableIntegrals", isColumn: true)]
		public int AvailableIntegrals { get; set; }
        
     }

}

