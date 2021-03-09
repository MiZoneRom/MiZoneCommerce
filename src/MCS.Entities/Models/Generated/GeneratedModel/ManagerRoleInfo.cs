
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "ManagerRole")]
     public partial class ManagerRoleInfo:IBaseEntity<ManagerInfo, long>, IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// RoleName
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "RoleName")]
		public string RoleName { get; set; }
        
		/// <summary>
        /// Description
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
		public string Description { get; set; }
        
     }

}

