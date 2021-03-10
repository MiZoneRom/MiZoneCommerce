
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "ManagerRolePrivilege")]
     public partial class ManagerRolePrivilegeInfo:IBaseEntity<ManagerRolePrivilegeInfo, long>
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public override long Id { get; set; }
        
		/// <summary>
        /// Privilege
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Privilege")]
		public  long Privilege { get; set; }
        
		/// <summary>
        /// RoleId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "RoleId")]
		public  long RoleId { get; set; }
        
		/// <summary>
        /// NavigationId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "NavigationId")]
		public  long NavigationId { get; set; }
        
		/// <summary>
        /// ActionId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "ActionId")]
		public  long ActionId { get; set; }
        
     }

}

