
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;

namespace MCS.Entities
{
    
     [Table("dbo.Role")]
     public partial class RoleInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// RoleName
        /// </summary>
		
		[Required]
		[Column("RoleName")]
		public string RoleName { get; set; }
        
		/// <summary>
        /// Description
        /// </summary>
		
		[Required]
		[Column("Description")]
		public string Description { get; set; }
        
     }

}

