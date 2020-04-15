
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;

namespace MCS.Entities
{
    
     [Table("dbo.CapitalDetail")]
     public partial class CapitalDetailInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// CapitalId
        /// </summary>
		
		[Required]
		[Column("CapitalId")]
		public long CapitalId { get; set; }
        
		/// <summary>
        /// SourceType
        /// </summary>
		
		[Required]
		[Column("SourceType")]
		public int SourceType { get; set; }
        
		/// <summary>
        /// Amount
        /// </summary>
		
		[Required]
		[Column("Amount")]
		public decimal Amount { get; set; }
        
		/// <summary>
        /// SourceData
        /// </summary>
		
		
		[Column("SourceData")]
		public string SourceData { get; set; }
        
		/// <summary>
        /// CreateDate
        /// </summary>
		
		[Required]
		[Column("CreateDate")]
		public DateTime CreateDate { get; set; }
        
		/// <summary>
        /// Remark
        /// </summary>
		
		
		[Column("Remark")]
		public string Remark { get; set; }
        
		/// <summary>
        /// PresentAmount
        /// </summary>
		
		[Required]
		[Column("PresentAmount")]
		public decimal PresentAmount { get; set; }
        
     }

}

