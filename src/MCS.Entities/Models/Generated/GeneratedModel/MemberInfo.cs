
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.Member")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public string UserName {get;set;}
        [Column] public string Password {get;set;}
        [Column] public string PasswordSalt {get;set;}
        [Column] public string Nick {get;set;}
        [Column] public int Sex {get;set;}
        [Column] public string Email {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        [Column] public int TopRegionId {get;set;}
        [Column] public int RegionId {get;set;}
        [Column] public string RealName {get;set;}
        [Column] public string CellPhone {get;set;}
        [Column] public string QQ {get;set;}
        [Column] public string Address {get;set;}
        [Column] public bool Disabled {get;set;}
        [Column] public DateTime LastLoginDate {get;set;}
        [Column] public int? OrderNumber {get;set;}
        [Column] public decimal? TotalAmount {get;set;}
        [Column] public decimal? Expenditure {get;set;}
        [Column] public int? Points {get;set;}
        [Column] public string Photo {get;set;}
        [Column] public string Remark {get;set;}
        [Column] public string PayPwd {get;set;}
        [Column] public string PayPwdSalt {get;set;}
        [Column] public long? InviteUserId {get;set;}
        [Column] public DateTime? BirthDay {get;set;}
        [Column] public decimal? NetAmount {get;set;}
        [Column] public DateTime LastConsumptionTime {get;set;}
        [Column] public int Platform {get;set;}
        
     }

}

