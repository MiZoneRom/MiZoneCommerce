
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;

namespace MCS.Entities
{
    
     [Table("dbo.Member")]
     public partial class MemberInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
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
        /// Nick
        /// </summary>
		
		
		[Column("Nick")]
		public string Nick { get; set; }
        
		/// <summary>
        /// Sex
        /// </summary>
		
		[Required]
		[Column("Sex")]
		public int Sex { get; set; }
        
		/// <summary>
        /// Email
        /// </summary>
		
		
		[Column("Email")]
		public string Email { get; set; }
        
		/// <summary>
        /// CreateDate
        /// </summary>
		
		[Required]
		[Column("CreateDate")]
		public DateTime CreateDate { get; set; }
        
		/// <summary>
        /// TopRegionId
        /// </summary>
		
		[Required]
		[Column("TopRegionId")]
		public int TopRegionId { get; set; }
        
		/// <summary>
        /// RegionId
        /// </summary>
		
		[Required]
		[Column("RegionId")]
		public int RegionId { get; set; }
        
		/// <summary>
        /// RealName
        /// </summary>
		
		
		[Column("RealName")]
		public string RealName { get; set; }
        
		/// <summary>
        /// CellPhone
        /// </summary>
		
		
		[Column("CellPhone")]
		public string CellPhone { get; set; }
        
		/// <summary>
        /// QQ
        /// </summary>
		
		
		[Column("QQ")]
		public string QQ { get; set; }
        
		/// <summary>
        /// Address
        /// </summary>
		
		
		[Column("Address")]
		public string Address { get; set; }
        
		/// <summary>
        /// Disabled
        /// </summary>
		
		[Required]
		[Column("Disabled")]
		public bool Disabled { get; set; }
        
		/// <summary>
        /// LastLoginDate
        /// </summary>
		
		[Required]
		[Column("LastLoginDate")]
		public DateTime LastLoginDate { get; set; }
        
		/// <summary>
        /// OrderNumber
        /// </summary>
		
		
		[Column("OrderNumber")]
		public int? OrderNumber { get; set; }
        
		/// <summary>
        /// TotalAmount
        /// </summary>
		
		
		[Column("TotalAmount")]
		public decimal? TotalAmount { get; set; }
        
		/// <summary>
        /// Expenditure
        /// </summary>
		
		
		[Column("Expenditure")]
		public decimal? Expenditure { get; set; }
        
		/// <summary>
        /// Points
        /// </summary>
		
		
		[Column("Points")]
		public int? Points { get; set; }
        
		/// <summary>
        /// Photo
        /// </summary>
		
		
		[Column("Photo")]
		public string Photo { get; set; }
        
		/// <summary>
        /// Remark
        /// </summary>
		
		
		[Column("Remark")]
		public string Remark { get; set; }
        
		/// <summary>
        /// PayPwd
        /// </summary>
		
		
		[Column("PayPwd")]
		public string PayPwd { get; set; }
        
		/// <summary>
        /// PayPwdSalt
        /// </summary>
		
		
		[Column("PayPwdSalt")]
		public string PayPwdSalt { get; set; }
        
		/// <summary>
        /// InviteUserId
        /// </summary>
		
		
		[Column("InviteUserId")]
		public long? InviteUserId { get; set; }
        
		/// <summary>
        /// BirthDay
        /// </summary>
		
		
		[Column("BirthDay")]
		public DateTime? BirthDay { get; set; }
        
		/// <summary>
        /// NetAmount
        /// </summary>
		
		
		[Column("NetAmount")]
		public decimal? NetAmount { get; set; }
        
		/// <summary>
        /// LastConsumptionTime
        /// </summary>
		
		[Required]
		[Column("LastConsumptionTime")]
		public DateTime LastConsumptionTime { get; set; }
        
		/// <summary>
        /// Platform
        /// </summary>
		
		[Required]
		[Column("Platform")]
		public int Platform { get; set; }
        
     }

}

