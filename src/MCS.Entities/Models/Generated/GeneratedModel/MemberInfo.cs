
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
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "UserName",  isColumn: true)]
		public string UserName {get;set;}

        
		[Column(name: "Password",  isColumn: true)]
		public string Password {get;set;}

        
		[Column(name: "PasswordSalt",  isColumn: true)]
		public string PasswordSalt {get;set;}

        
		[Column(name: "Nick",  isColumn: true)]
		public string Nick {get;set;}

        
		[Column(name: "Sex",  isColumn: true)]
		public int Sex {get;set;}

        
		[Column(name: "Email",  isColumn: true)]
		public string Email {get;set;}

        
		[Column(name: "CreateDate",  isColumn: true)]
		public DateTime CreateDate {get;set;}

        
		[Column(name: "TopRegionId",  isColumn: true)]
		public int TopRegionId {get;set;}

        
		[Column(name: "RegionId",  isColumn: true)]
		public int RegionId {get;set;}

        
		[Column(name: "RealName",  isColumn: true)]
		public string RealName {get;set;}

        
		[Column(name: "CellPhone",  isColumn: true)]
		public string CellPhone {get;set;}

        
		[Column(name: "QQ",  isColumn: true)]
		public string QQ {get;set;}

        
		[Column(name: "Address",  isColumn: true)]
		public string Address {get;set;}

        
		[Column(name: "Disabled",  isColumn: true)]
		public bool Disabled {get;set;}

        
		[Column(name: "LastLoginDate",  isColumn: true)]
		public DateTime LastLoginDate {get;set;}

        
		[Column(name: "OrderNumber",  isColumn: true)]
		public int? OrderNumber {get;set;}

        
		[Column(name: "TotalAmount",  isColumn: true)]
		public decimal? TotalAmount {get;set;}

        
		[Column(name: "Expenditure",  isColumn: true)]
		public decimal? Expenditure {get;set;}

        
		[Column(name: "Points",  isColumn: true)]
		public int? Points {get;set;}

        
		[Column(name: "Photo",  isColumn: true)]
		public string Photo {get;set;}

        
		[Column(name: "Remark",  isColumn: true)]
		public string Remark {get;set;}

        
		[Column(name: "PayPwd",  isColumn: true)]
		public string PayPwd {get;set;}

        
		[Column(name: "PayPwdSalt",  isColumn: true)]
		public string PayPwdSalt {get;set;}

        
		[Column(name: "InviteUserId",  isColumn: true)]
		public long? InviteUserId {get;set;}

        
		[Column(name: "BirthDay",  isColumn: true)]
		public DateTime? BirthDay {get;set;}

        
		[Column(name: "NetAmount",  isColumn: true)]
		public decimal? NetAmount {get;set;}

        
		[Column(name: "LastConsumptionTime",  isColumn: true)]
		public DateTime LastConsumptionTime {get;set;}

        
		[Column(name: "Platform",  isColumn: true)]
		public int Platform {get;set;}

        
     }

}

