
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;

namespace MCS.Entities
{
    
     [Table("dbo.SendMessageRecord")]
     public partial class SendMessageRecordInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// MessageType
        /// </summary>
		
		[Required]
		[Column("MessageType")]
		public int MessageType { get; set; }
        
		/// <summary>
        /// ContentType
        /// </summary>
		
		[Required]
		[Column("ContentType")]
		public int ContentType { get; set; }
        
		/// <summary>
        /// SendContent
        /// </summary>
		
		[Required]
		[Column("SendContent")]
		public string SendContent { get; set; }
        
		/// <summary>
        /// ToUserLabel
        /// </summary>
		
		
		[Column("ToUserLabel")]
		public string ToUserLabel { get; set; }
        
		/// <summary>
        /// SendState
        /// </summary>
		
		[Required]
		[Column("SendState")]
		public int SendState { get; set; }
        
		/// <summary>
        /// SendTime
        /// </summary>
		
		[Required]
		[Column("SendTime")]
		public DateTime SendTime { get; set; }
        
     }

}

