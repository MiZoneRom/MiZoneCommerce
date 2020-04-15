
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.Manager")]
     public partial class ManagerInfo
     {
        
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }

        
		/// <summary>
        /// 角色ID
        /// </summary>
		[Column(name: "RoleId",  isColumn: true)]
		public long RoleId { get; set; }

        
		/// <summary>
        /// 用户名
        /// </summary>
		[Column(name: "UserName",  isColumn: true)]
		public string UserName { get; set; }

        
		/// <summary>
        /// 密码
        /// </summary>
		[Column(name: "Password",  isColumn: true)]
		public string Password { get; set; }

        
		/// <summary>
        /// 密码加盐
        /// </summary>
		[Column(name: "PasswordSalt",  isColumn: true)]
		public string PasswordSalt { get; set; }

        
		/// <summary>
        /// 创建日期
        /// </summary>
		[Column(name: "CreateDate",  isColumn: true)]
		public DateTime? CreateDate { get; set; }

        
		/// <summary>
        /// 备注
        /// </summary>
		[Column(name: "Remark",  isColumn: true)]
		public string Remark { get; set; }

        
		/// <summary>
        /// 真实名称
        /// </summary>
		[Column(name: "RealName",  isColumn: true)]
		public string RealName { get; set; }

        
     }

}

