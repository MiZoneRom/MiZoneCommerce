
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;

namespace MCS.Entities
{
    
     [Table("dbo.MessageLog")]
     public partial class MessageLogInfo:IModel
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
        /// TypeId
        /// </summary>
		
		
		[Column("TypeId")]
		public string TypeId { get; set; }
        
		/// <summary>
        /// MessageContent
        /// </summary>
		
		
		[Column("MessageContent")]
		public string MessageContent { get; set; }
        
		/// <summary>
        /// CreateDate
        /// </summary>
		
		[Required]
		[Column("CreateDate")]
		public DateTime CreateDate { get; set; }
        
     }

}

