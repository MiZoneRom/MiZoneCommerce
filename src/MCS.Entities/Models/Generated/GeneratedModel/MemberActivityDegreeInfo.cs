
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.MemberActivityDegree")]
     public partial class MemberActivityDegreeInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// UserId
        /// </summary>
		
		[Required]
		[Column("UserId")]
		public long UserId { get; set; }
        
		/// <summary>
        /// OneMonth
        /// </summary>
		
		[Required]
		[Column("OneMonth")]
		public bool OneMonth { get; set; }
        
		/// <summary>
        /// ThreeMonth
        /// </summary>
		
		[Required]
		[Column("ThreeMonth")]
		public bool ThreeMonth { get; set; }
        
		/// <summary>
        /// SixMonth
        /// </summary>
		
		[Required]
		[Column("SixMonth")]
		public bool SixMonth { get; set; }
        
		/// <summary>
        /// OneMonthEffectiveTime
        /// </summary>
		
		
		[Column("OneMonthEffectiveTime")]
		public DateTime? OneMonthEffectiveTime { get; set; }
        
		/// <summary>
        /// ThreeMonthEffectiveTime
        /// </summary>
		
		
		[Column("ThreeMonthEffectiveTime")]
		public DateTime? ThreeMonthEffectiveTime { get; set; }
        
		/// <summary>
        /// SixMonthEffectiveTime
        /// </summary>
		
		
		[Column("SixMonthEffectiveTime")]
		public DateTime? SixMonthEffectiveTime { get; set; }
        
     }

}

