
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;

namespace MCS.Entities
{
    
     [Table("dbo.MemberIntegralRecord")]
     public partial class MemberIntegralRecordInfo:IModel
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
        /// TypeId
        /// </summary>
		
		[Required]
		[Column("TypeId")]
		public int TypeId { get; set; }
        
		/// <summary>
        /// Integral
        /// </summary>
		
		[Required]
		[Column("Integral")]
		public int Integral { get; set; }
        
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
        
     }

}

