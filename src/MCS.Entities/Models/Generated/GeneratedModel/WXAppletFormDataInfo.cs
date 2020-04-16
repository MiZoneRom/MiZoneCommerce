
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.WXAppletFormData")]
     public partial class WXAppletFormDataInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// EventId
        /// </summary>
		
		[Required]
		[Column("EventId")]
		public long EventId { get; set; }
        
		/// <summary>
        /// EventValue
        /// </summary>
		
		
		[Column("EventValue")]
		public string EventValue { get; set; }
        
		/// <summary>
        /// FormId
        /// </summary>
		
		
		[Column("FormId")]
		public string FormId { get; set; }
        
		/// <summary>
        /// EventTime
        /// </summary>
		
		[Required]
		[Column("EventTime")]
		public DateTime EventTime { get; set; }
        
		/// <summary>
        /// ExpireTime
        /// </summary>
		
		[Required]
		[Column("ExpireTime")]
		public DateTime ExpireTime { get; set; }
        
     }

}

