
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.WeiXinMsgTemplate")]
     public partial class WeiXinMsgTemplateInfo:IModel
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
        /// TemplateNum
        /// </summary>
		
		
		[Column("TemplateNum")]
		public string TemplateNum { get; set; }
        
		/// <summary>
        /// TemplateId
        /// </summary>
		
		
		[Column("TemplateId")]
		public string TemplateId { get; set; }
        
		/// <summary>
        /// UpdateDate
        /// </summary>
		
		[Required]
		[Column("UpdateDate")]
		public DateTime UpdateDate { get; set; }
        
		/// <summary>
        /// IsOpen
        /// </summary>
		
		[Required]
		[Column("IsOpen")]
		public bool IsOpen { get; set; }
        
		/// <summary>
        /// UserInWxApplet
        /// </summary>
		
		[Required]
		[Column("UserInWxApplet")]
		public bool UserInWxApplet { get; set; }
        
     }

}

