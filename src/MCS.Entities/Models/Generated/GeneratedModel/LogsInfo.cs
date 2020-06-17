
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.Logs")]
     public partial class LogsInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// PageUrl
        /// </summary>
		
		[Required]
		[Column("PageUrl")]
		public string PageUrl { get; set; }
        
		/// <summary>
        /// Date
        /// </summary>
		
		[Required]
		[Column("Date")]
		public DateTime Date { get; set; }
        
		/// <summary>
        /// UserName
        /// </summary>
		
		[Required]
		[Column("UserName")]
		public string UserName { get; set; }
        
		/// <summary>
        /// IPAddress
        /// </summary>
		
		[Required]
		[Column("IPAddress")]
		public string IPAddress { get; set; }
        
		/// <summary>
        /// Description
        /// </summary>
		
		[Required]
		[Column("Description")]
		public string Description { get; set; }
        
     }

}

