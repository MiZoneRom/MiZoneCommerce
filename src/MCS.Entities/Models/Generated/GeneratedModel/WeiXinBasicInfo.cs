
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.WeiXinBasic")]
     public partial class WeiXinBasicInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// Ticket
        /// </summary>
		
		
		[Column("Ticket")]
		public string Ticket { get; set; }
        
		/// <summary>
        /// TicketOutTime
        /// </summary>
		
		[Required]
		[Column("TicketOutTime")]
		public DateTime TicketOutTime { get; set; }
        
		/// <summary>
        /// AppId
        /// </summary>
		
		
		[Column("AppId")]
		public string AppId { get; set; }
        
		/// <summary>
        /// AccessToken
        /// </summary>
		
		
		[Column("AccessToken")]
		public string AccessToken { get; set; }
        
     }

}

