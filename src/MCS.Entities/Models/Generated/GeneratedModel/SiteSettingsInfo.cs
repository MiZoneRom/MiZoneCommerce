
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "SiteSettings")]
     public partial class SiteSettingsInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity]
		//[Required]
		//[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// Key
        /// </summary>
		
		//[Required]
		//[Column("Key")]
		public string Key { get; set; }
        
		/// <summary>
        /// Value
        /// </summary>
		
		//[Required]
		//[Column("Value")]
		public string Value { get; set; }
        
     }

}

