
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
        /// TypeId
        /// </summary>
		[Column(name: "TypeId", isColumn: true)]
		public int TypeId { get; set; }
        
		/// <summary>
        /// Integral
        /// </summary>
		[Column(name: "Integral", isColumn: true)]
		public int Integral { get; set; }
        
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
        
     }

}

