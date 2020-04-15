
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.CapitalDetail")]
     public partial class CapitalDetailInfo
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id", key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }
        
		/// <summary>
        /// CapitalId
        /// </summary>
		[Column(name: "CapitalId", isColumn: true)]
		public long CapitalId { get; set; }
        
		/// <summary>
        /// SourceType
        /// </summary>
		[Column(name: "SourceType", isColumn: true)]
		public int SourceType { get; set; }
        
		/// <summary>
        /// Amount
        /// </summary>
		[Column(name: "Amount", isColumn: true)]
		public decimal Amount { get; set; }
        
		/// <summary>
        /// SourceData
        /// </summary>
		[Column(name: "SourceData", isColumn: true)]
		public string SourceData { get; set; }
        
		/// <summary>
        /// CreateDate
        /// </summary>
		[Column(name: "CreateDate", isColumn: true)]
		public DateTime CreateDate { get; set; }
        
		/// <summary>
        /// Remark
        /// </summary>
		[Column(name: "Remark", isColumn: true)]
		public string Remark { get; set; }
        
		/// <summary>
        /// PresentAmount
        /// </summary>
		[Column(name: "PresentAmount", isColumn: true)]
		public decimal PresentAmount { get; set; }
        
     }

}

