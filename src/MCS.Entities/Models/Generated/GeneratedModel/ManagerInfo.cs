
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.Manager")]
     public partial class ManagerInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// 角色ID
        /// </summary>
		
		[Required]
		[Column("RoleId")]
		public long RoleId { get; set; }
        
		/// <summary>
        /// 用户名
        /// </summary>
		
		
		[Column("UserName")]
		public string UserName { get; set; }
        
		/// <summary>
        /// 密码
        /// </summary>
		
		
		[Column("Password")]
		public string Password { get; set; }
        
		/// <summary>
        /// 密码加盐
        /// </summary>
		
		
		[Column("PasswordSalt")]
		public string PasswordSalt { get; set; }
        
		/// <summary>
        /// 创建日期
        /// </summary>
		
		
		[Column("CreateDate")]
		public DateTime? CreateDate { get; set; }
        
		/// <summary>
        /// 备注
        /// </summary>
		
		
		[Column("Remark")]
		public string Remark { get; set; }
        
		/// <summary>
        /// 真实名称
        /// </summary>
		
		
		[Column("RealName")]
		public string RealName { get; set; }
        
     }

}

