
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "ManagerRolePrivilege")]
     public partial class ManagerRolePrivilegeInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// Privilege
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Privilege")]
		public int Privilege { get; set; }
        
		/// <summary>
        /// RoleId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "RoleId")]
		public long RoleId { get; set; }
        
		/// <summary>
        /// NavId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "NavId")]
		public long NavId { get; set; }
        
     }

}

