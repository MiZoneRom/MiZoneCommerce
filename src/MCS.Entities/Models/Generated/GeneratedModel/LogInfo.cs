
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "Log")]
     public partial class LogInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity]
		//[Required]
		//[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// PageUrl
        /// </summary>
		
		//[Required]
		//[Column("PageUrl")]
		public string PageUrl { get; set; }
        
		/// <summary>
        /// Date
        /// </summary>
		
		//[Required]
		//[Column("Date")]
		public DateTime Date { get; set; }
        
		/// <summary>
        /// UserName
        /// </summary>
		
		//[Required]
		//[Column("UserName")]
		public string UserName { get; set; }
        
		/// <summary>
        /// IPAddress
        /// </summary>
		
		//[Required]
		//[Column("IPAddress")]
		public string IPAddress { get; set; }
        
		/// <summary>
        /// Description
        /// </summary>
		
		//[Required]
		//[Column("Description")]
		public string Description { get; set; }
        
     }

}

