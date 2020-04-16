
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.Capital")]
     public partial class CapitalInfo:IModel
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
        /// Balance
        /// </summary>
		
		[Required]
		[Column("Balance")]
		public decimal Balance { get; set; }
        
		/// <summary>
        /// FreezeAmount
        /// </summary>
		
		[Required]
		[Column("FreezeAmount")]
		public decimal FreezeAmount { get; set; }
        
		/// <summary>
        /// ChargeAmount
        /// </summary>
		
		[Required]
		[Column("ChargeAmount")]
		public decimal ChargeAmount { get; set; }
        
		/// <summary>
        /// PresentAmount
        /// </summary>
		
		[Required]
		[Column("PresentAmount")]
		public decimal PresentAmount { get; set; }
        
     }

}

