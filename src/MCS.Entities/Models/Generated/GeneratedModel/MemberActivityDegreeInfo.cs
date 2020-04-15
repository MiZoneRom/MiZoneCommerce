
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberActivityDegree")]
     public partial class MemberActivityDegreeInfo
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
        /// OneMonth
        /// </summary>
		[Column(name: "OneMonth", isColumn: true)]
		public bool OneMonth { get; set; }
        
		/// <summary>
        /// ThreeMonth
        /// </summary>
		[Column(name: "ThreeMonth", isColumn: true)]
		public bool ThreeMonth { get; set; }
        
		/// <summary>
        /// SixMonth
        /// </summary>
		[Column(name: "SixMonth", isColumn: true)]
		public bool SixMonth { get; set; }
        
		/// <summary>
        /// OneMonthEffectiveTime
        /// </summary>
		[Column(name: "OneMonthEffectiveTime", isColumn: true)]
		public DateTime? OneMonthEffectiveTime { get; set; }
        
		/// <summary>
        /// ThreeMonthEffectiveTime
        /// </summary>
		[Column(name: "ThreeMonthEffectiveTime", isColumn: true)]
		public DateTime? ThreeMonthEffectiveTime { get; set; }
        
		/// <summary>
        /// SixMonthEffectiveTime
        /// </summary>
		[Column(name: "SixMonthEffectiveTime", isColumn: true)]
		public DateTime? SixMonthEffectiveTime { get; set; }
        
     }

}

