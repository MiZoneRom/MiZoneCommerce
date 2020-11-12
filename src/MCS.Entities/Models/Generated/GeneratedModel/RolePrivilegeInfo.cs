
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "RolePrivilege")]
     public partial class RolePrivilegeInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity]
		//[Required]
		//[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// Privilege
        /// </summary>
		
		//[Required]
		//[Column("Privilege")]
		public int Privilege { get; set; }
        
		/// <summary>
        /// RoleId
        /// </summary>
		
		//[Required]
		//[Column("RoleId")]
		public long RoleId { get; set; }
        
		/// <summary>
        /// NavId
        /// </summary>
		
		//[Required]
		//[Column("NavId")]
		public long NavId { get; set; }
        
     }

}

