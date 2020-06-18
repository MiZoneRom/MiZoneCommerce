
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
    
     [Table("dbo.Managers")]
     public partial class ManagersInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// RoleId
        /// </summary>
		
		[Required]
		[Column("RoleId")]
		public long RoleId { get; set; }
        
		/// <summary>
        /// UserName
        /// </summary>
		
		[Required]
		[Column("UserName")]
		public string UserName { get; set; }
        
		/// <summary>
        /// Password
        /// </summary>
		
		[Required]
		[Column("Password")]
		public string Password { get; set; }
        
		/// <summary>
        /// PasswordSalt
        /// </summary>
		
		[Required]
		[Column("PasswordSalt")]
		public string PasswordSalt { get; set; }
        
		/// <summary>
        /// CreateDate
        /// </summary>
		
		[Required]
		[Column("CreateDate")]
		public DateTime CreateDate { get; set; }
        
		/// <summary>
        /// Remark
        /// </summary>
		
		
		[Column("Remark")]
		public string Remark { get; set; }
        
		/// <summary>
        /// RealName
        /// </summary>
		
		
		[Column("RealName")]
		public string RealName { get; set; }
        
		/// <summary>
        /// Avatars
        /// </summary>
		
		
		[Column("Avatars")]
		public string Avatars { get; set; }
        
     }

}

