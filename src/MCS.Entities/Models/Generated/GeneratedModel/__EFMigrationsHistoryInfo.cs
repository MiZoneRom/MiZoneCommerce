
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "__EFMigrationsHistory")]
     public partial class __EFMigrationsHistoryInfo:IModel
     {
        
		/// <summary>
        /// MigrationId
        /// </summary>
		[Identity]
        [System.ComponentModel.DataAnnotations.Display(Name = "MigrationId")]
		public string MigrationId { get; set; }
        
		/// <summary>
        /// ProductVersion
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "ProductVersion")]
		public string ProductVersion { get; set; }
        
     }

}

