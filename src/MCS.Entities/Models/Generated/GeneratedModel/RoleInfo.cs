
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "Role")]
     public partial class RoleInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity]
		//[Required]
		//[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// RoleName
        /// </summary>
		
		//[Required]
		//[Column("RoleName")]
		public string RoleName { get; set; }
        
		/// <summary>
        /// Description
        /// </summary>
		
		//[Required]
		//[Column("Description")]
		public string Description { get; set; }
        
     }

}

