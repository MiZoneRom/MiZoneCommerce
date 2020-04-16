
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.RolePrivilege")]
     public partial class RolePrivilegeInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// Privilege
        /// </summary>
		
		[Required]
		[Column("Privilege")]
		public int Privilege { get; set; }
        
		/// <summary>
        /// RoleId
        /// </summary>
		
		[Required]
		[Column("RoleId")]
		public long RoleId { get; set; }
        
     }

}

