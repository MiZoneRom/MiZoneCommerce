
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.Member")]
     public partial class MemberInfo
     {
        
		/// <summary>
        /// 自增长ID
        /// </summary>
		[Column(name: "Id", key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }
        
		/// <summary>
        /// UserName
        /// </summary>
		[Column(name: "UserName", isColumn: true)]
		public string UserName { get; set; }
        
		/// <summary>
        /// Password
        /// </summary>
		[Column(name: "Password", isColumn: true)]
		public string Password { get; set; }
        
		/// <summary>
        /// PasswordSalt
        /// </summary>
		[Column(name: "PasswordSalt", isColumn: true)]
		public string PasswordSalt { get; set; }
        
		/// <summary>
        /// Nick
        /// </summary>
		[Column(name: "Nick", isColumn: true)]
		public string Nick { get; set; }
        
		/// <summary>
        /// Sex
        /// </summary>
		[Column(name: "Sex", isColumn: true)]
		public int Sex { get; set; }
        
		/// <summary>
        /// Email
        /// </summary>
		[Column(name: "Email", isColumn: true)]
		public string Email { get; set; }
        
		/// <summary>
        /// CreateDate
        /// </summary>
		[Column(name: "CreateDate", isColumn: true)]
		public DateTime CreateDate { get; set; }
        
		/// <summary>
        /// TopRegionId
        /// </summary>
		[Column(name: "TopRegionId", isColumn: true)]
		public int TopRegionId { get; set; }
        
		/// <summary>
        /// RegionId
        /// </summary>
		[Column(name: "RegionId", isColumn: true)]
		public int RegionId { get; set; }
        
		/// <summary>
        /// RealName
        /// </summary>
		[Column(name: "RealName", isColumn: true)]
		public string RealName { get; set; }
        
		/// <summary>
        /// CellPhone
        /// </summary>
		[Column(name: "CellPhone", isColumn: true)]
		public string CellPhone { get; set; }
        
		/// <summary>
        /// QQ
        /// </summary>
		[Column(name: "QQ", isColumn: true)]
		public string QQ { get; set; }
        
		/// <summary>
        /// Address
        /// </summary>
		[Column(name: "Address", isColumn: true)]
		public string Address { get; set; }
        
		/// <summary>
        /// Disabled
        /// </summary>
		[Column(name: "Disabled", isColumn: true)]
		public bool Disabled { get; set; }
        
		/// <summary>
        /// LastLoginDate
        /// </summary>
		[Column(name: "LastLoginDate", isColumn: true)]
		public DateTime LastLoginDate { get; set; }
        
		/// <summary>
        /// OrderNumber
        /// </summary>
		[Column(name: "OrderNumber", isColumn: true)]
		public int? OrderNumber { get; set; }
        
		/// <summary>
        /// TotalAmount
        /// </summary>
		[Column(name: "TotalAmount", isColumn: true)]
		public decimal? TotalAmount { get; set; }
        
		/// <summary>
        /// Expenditure
        /// </summary>
		[Column(name: "Expenditure", isColumn: true)]
		public decimal? Expenditure { get; set; }
        
		/// <summary>
        /// Points
        /// </summary>
		[Column(name: "Points", isColumn: true)]
		public int? Points { get; set; }
        
		/// <summary>
        /// Photo
        /// </summary>
		[Column(name: "Photo", isColumn: true)]
		public string Photo { get; set; }
        
		/// <summary>
        /// Remark
        /// </summary>
		[Column(name: "Remark", isColumn: true)]
		public string Remark { get; set; }
        
		/// <summary>
        /// PayPwd
        /// </summary>
		[Column(name: "PayPwd", isColumn: true)]
		public string PayPwd { get; set; }
        
		/// <summary>
        /// PayPwdSalt
        /// </summary>
		[Column(name: "PayPwdSalt", isColumn: true)]
		public string PayPwdSalt { get; set; }
        
		/// <summary>
        /// InviteUserId
        /// </summary>
		[Column(name: "InviteUserId", isColumn: true)]
		public long? InviteUserId { get; set; }
        
		/// <summary>
        /// BirthDay
        /// </summary>
		[Column(name: "BirthDay", isColumn: true)]
		public DateTime? BirthDay { get; set; }
        
		/// <summary>
        /// NetAmount
        /// </summary>
		[Column(name: "NetAmount", isColumn: true)]
		public decimal? NetAmount { get; set; }
        
		/// <summary>
        /// LastConsumptionTime
        /// </summary>
		[Column(name: "LastConsumptionTime", isColumn: true)]
		public DateTime LastConsumptionTime { get; set; }
        
		/// <summary>
        /// Platform
        /// </summary>
		[Column(name: "Platform", isColumn: true)]
		public int Platform { get; set; }
        
     }

}

