
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.Roles")]
     public partial class RolesInfo:IModel
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

