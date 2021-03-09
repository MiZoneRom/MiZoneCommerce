
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "Manager")]
     public partial class ManagerInfo:IBaseEntity<ManagerInfo, long>, IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// RoleId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "RoleId")]
		public long RoleId { get; set; }
        
		/// <summary>
        /// UserName
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "UserName")]
		public string UserName { get; set; }
        
		/// <summary>
        /// Password
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Password")]
		public string Password { get; set; }
        
		/// <summary>
        /// PasswordSalt
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "PasswordSalt")]
		public string PasswordSalt { get; set; }
        
		/// <summary>
        /// CreateDate
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "CreateDate")]
		public DateTime? CreateDate { get; set; }
        
		/// <summary>
        /// Remark
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Remark")]
		public string Remark { get; set; }
        
		/// <summary>
        /// RealName
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "RealName")]
		public string RealName { get; set; }
        
		/// <summary>
        /// Avatars
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Avatars")]
		public string Avatars { get; set; }
        
     }

}

