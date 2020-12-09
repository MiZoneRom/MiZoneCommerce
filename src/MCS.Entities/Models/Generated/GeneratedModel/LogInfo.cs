
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
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// PageUrl
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "PageUrl")]
		public string PageUrl { get; set; }
        
		/// <summary>
        /// Date
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Date")]
		public DateTime Date { get; set; }
        
		/// <summary>
        /// UserName
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "UserName")]
		public string UserName { get; set; }
        
		/// <summary>
        /// IPAddress
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "IPAddress")]
		public string IPAddress { get; set; }
        
		/// <summary>
        /// Description
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
		public string Description { get; set; }
        
     }

}

