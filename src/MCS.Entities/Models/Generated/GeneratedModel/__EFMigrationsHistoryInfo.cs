
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.__EFMigrationsHistory")]
     public partial class __EFMigrationsHistoryInfo:IModel
     {
        
		/// <summary>
        /// MigrationId
        /// </summary>
		[Key]
		[Required]
		[Column("MigrationId")]
		public string MigrationId { get; set; }
        
		/// <summary>
        /// ProductVersion
        /// </summary>
		
		[Required]
		[Column("ProductVersion")]
		public string ProductVersion { get; set; }
        
     }

}

