
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;

namespace MCS.Entities
{
    
     [Table("dbo.SiteSetting")]
     public partial class SiteSettingInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// Key
        /// </summary>
		
		[Required]
		[Column("Key")]
		public string Key { get; set; }
        
		/// <summary>
        /// Value
        /// </summary>
		
		[Required]
		[Column("Value")]
		public string Value { get; set; }
        
     }

}

