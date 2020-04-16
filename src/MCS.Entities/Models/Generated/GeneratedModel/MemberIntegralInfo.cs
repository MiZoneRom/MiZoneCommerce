
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.MemberIntegral")]
     public partial class MemberIntegralInfo:IModel
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
        /// UserName
        /// </summary>
		
		[Required]
		[Column("UserName")]
		public string UserName { get; set; }
        
		/// <summary>
        /// HistoryIntegrals
        /// </summary>
		
		[Required]
		[Column("HistoryIntegrals")]
		public int HistoryIntegrals { get; set; }
        
		/// <summary>
        /// AvailableIntegrals
        /// </summary>
		
		[Required]
		[Column("AvailableIntegrals")]
		public int AvailableIntegrals { get; set; }
        
     }

}

