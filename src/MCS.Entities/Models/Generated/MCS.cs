

using PetaPoco.NetCore;
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MCS.Entities
{

     public partial class MCS : Database
     {
        /// <summary>
        /// open the connection
        /// </summary>
        /// <returns></returns>
        private static SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection("������Ӵ�");
            conn.Open();
            return conn;
        }

        private static SqlConnection OpenConnection(string name)
        {
            //SqlConnection conn = new SqlConnection(JsonConfig.JsonRead(name));
            //conn.Open();
            //return conn;
			return null;
        }

        public MCS() : base(OpenConnection())
        {
            CommonConstruct();
        }

        public MCS(string connectionStringName) : base(OpenConnection(connectionStringName))
        {
            CommonConstruct();
        }

        partial void CommonConstruct();

        public interface IFactory
        {
            MCS GetInstance();
        }

        public static IFactory Factory { get; set; }
        public static MCS GetInstance()
        {
            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new MCS();
        }

        [ThreadStatic] static MCS _instance;

        public override void OnBeginTransaction()
        {
            if (_instance == null)
                _instance = this;
        }

        public override void OnEndTransaction()
        {
            if (_instance == this)
                _instance = null;
        }


        public class Record<T> where T : new()
        {
            public static MCS repo { get { return MCS.GetInstance(); } }
            public bool IsNew() { return repo.IsNew(this); }
            public object Insert() { return repo.Insert(this); }

            public void Save() { repo.Save(this); }
            public int Update() { return repo.Update(this); }

            public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
            public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
            public static int Update(Sql sql) { return repo.Update<T>(sql); }
            public int Delete() { return repo.Delete(this); }
            public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
            public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
            public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
            public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
            public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
            public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
            public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
            public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
            public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
            public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
            public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
            public static T Single(Sql sql) { return repo.Single<T>(sql); }
            public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
            public static T First(Sql sql) { return repo.First<T>(sql); }
            public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
            public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }

            public static List<T> Fetch(int page, int itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }

            public static List<T> SkipTake(int skip, int take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
            public static List<T> SkipTake(int skip, int take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
            public static Page<T> Page(int page, int itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
            public static Page<T> Page(int page, int itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
            public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
            public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }

        }

    }


    
     [TableName("dbo.Manager")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class ManagerInfo:MCS.Record<ManagerInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long RoleId {get;set;}
        [Column] public string UserName {get;set;}
        [Column] public string Password {get;set;}
        [Column] public string PasswordSalt {get;set;}
        [Column] public DateTime? CreateDate {get;set;}
        [Column] public string Remark {get;set;}
        [Column] public string RealName {get;set;}
        
     }
    
     [TableName("dbo.RolePrivilege")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class RolePrivilegeInfo:MCS.Record<RolePrivilegeInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public int Privilege {get;set;}
        [Column] public long RoleId {get;set;}
        
     }
    
     [TableName("dbo.SiteSetting")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class SiteSettingInfo:MCS.Record<SiteSettingInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public string Key {get;set;}
        [Column] public string Value {get;set;}
        
     }
    
     [TableName("dbo.MemberOpenId")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberOpenIdInfo:MCS.Record<MemberOpenIdInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public string OpenId {get;set;}
        [Column] public string UnionOpenId {get;set;}
        [Column] public string UnionId {get;set;}
        [Column] public string ServiceProvider {get;set;}
        [Column] public int AppIdType {get;set;}
        
     }
    
     [TableName("dbo.MemberContact")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberContactInfo:MCS.Record<MemberContactInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public int UserType {get;set;}
        [Column] public string ServiceProvider {get;set;}
        [Column] public string Contact {get;set;}
        
     }
    
     [TableName("dbo.MemberGroup")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberGroupInfo:MCS.Record<MemberGroupInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public int StatisticsType {get;set;}
        [Column] public int Total {get;set;}
        
     }
    
     [TableName("dbo.OpenId")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class OpenIdInfo:MCS.Record<OpenIdInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public string OpenId {get;set;}
        [Column] public DateTime SubscribeTime {get;set;}
        [Column] public bool IsSubscribe {get;set;}
        
     }
    
     [TableName("dbo.MemberActivityDegree")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberActivityDegreeInfo:MCS.Record<MemberActivityDegreeInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public bool OneMonth {get;set;}
        [Column] public bool ThreeMonth {get;set;}
        [Column] public bool SixMonth {get;set;}
        [Column] public DateTime? OneMonthEffectiveTime {get;set;}
        [Column] public DateTime? ThreeMonthEffectiveTime {get;set;}
        [Column] public DateTime? SixMonthEffectiveTime {get;set;}
        
     }
    
     [TableName("dbo.Member")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberInfo:MCS.Record<MemberInfo>
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
    
     [TableName("dbo.MemberIntegral")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberIntegralInfo:MCS.Record<MemberIntegralInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public string UserName {get;set;}
        [Column] public int HistoryIntegrals {get;set;}
        [Column] public int AvailableIntegrals {get;set;}
        
     }
    
     [TableName("dbo.MemberIntegralRecord")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberIntegralRecordInfo:MCS.Record<MemberIntegralRecordInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public string UserName {get;set;}
        [Column] public int TypeId {get;set;}
        [Column] public int Integral {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        [Column] public string Remark {get;set;}
        
     }
    
     [TableName("dbo.MessageLog")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MessageLogInfo:MCS.Record<MessageLogInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public string TypeId {get;set;}
        [Column] public string MessageContent {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        
     }
    
     [TableName("dbo.SendMessageRecord")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class SendMessageRecordInfo:MCS.Record<SendMessageRecordInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public int MessageType {get;set;}
        [Column] public int ContentType {get;set;}
        [Column] public string SendContent {get;set;}
        [Column] public string ToUserLabel {get;set;}
        [Column] public int SendState {get;set;}
        [Column] public DateTime SendTime {get;set;}
        
     }
    
     [TableName("dbo.WeiXinMsgTemplate")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WeiXinMsgTemplateInfo:MCS.Record<WeiXinMsgTemplateInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public int MessageType {get;set;}
        [Column] public string TemplateNum {get;set;}
        [Column] public string TemplateId {get;set;}
        [Column] public DateTime UpdateDate {get;set;}
        [Column] public bool IsOpen {get;set;}
        [Column] public bool UserInWxApplet {get;set;}
        
     }
    
     [TableName("dbo.WXAppletFormData")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WXAppletFormDataInfo:MCS.Record<WXAppletFormDataInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long EventId {get;set;}
        [Column] public string EventValue {get;set;}
        [Column] public string FormId {get;set;}
        [Column] public DateTime EventTime {get;set;}
        [Column] public DateTime ExpireTime {get;set;}
        
     }
    
     [TableName("dbo.Capital")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class CapitalInfo:MCS.Record<CapitalInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public decimal Balance {get;set;}
        [Column] public decimal FreezeAmount {get;set;}
        [Column] public decimal ChargeAmount {get;set;}
        [Column] public decimal PresentAmount {get;set;}
        
     }
    
     [TableName("dbo.CapitalDetail")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class CapitalDetailInfo:MCS.Record<CapitalDetailInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long CapitalId {get;set;}
        [Column] public int SourceType {get;set;}
        [Column] public decimal Amount {get;set;}
        [Column] public string SourceData {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        [Column] public string Remark {get;set;}
        [Column] public decimal PresentAmount {get;set;}
        
     }
    
     [TableName("dbo.WeiXinBasic")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WeiXinBasicInfo:MCS.Record<WeiXinBasicInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public string Ticket {get;set;}
        [Column] public DateTime TicketOutTime {get;set;}
        [Column] public string AppId {get;set;}
        [Column] public string AccessToken {get;set;}
        
     }
    
     [TableName("dbo.WareHouse")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WareHouseInfo:MCS.Record<WareHouseInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public string Name {get;set;}
        [Column] public DateTime? CreateDate {get;set;}
        
     }
    
     [TableName("dbo.WareHouseGoodsCategory")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WareHouseGoodsCategoryInfo:MCS.Record<WareHouseGoodsCategoryInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public string Name {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        
     }
    
     [TableName("dbo.WareHouseAddress")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WareHouseAddressInfo:MCS.Record<WareHouseAddressInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long WareHouseId {get;set;}
        [Column] public string AddressName {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        
     }
    
     [TableName("dbo.WareHouseGoods")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class WareHouseGoodsInfo:MCS.Record<WareHouseGoodsInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public long WareHouseId {get;set;}
        [Column] public string Name {get;set;}
        [Column] public long CategoryId {get;set;}
        [Column] public int Quantity {get;set;}
        [Column] public string MeasureUnit {get;set;}
        [Column] public long AddressId {get;set;}
        [Column] public long SourceId {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        
     }
    
     [TableName("dbo.WareHouseDemo")]
     [ExplicitColumns]
     public partial class WareHouseDemoInfo:MCS.Record<WareHouseDemoInfo>
     {
        
        [Column] public string No {get;set;}
        [Column] public string ImgUrl {get;set;}
        [Column] public string Name {get;set;}
        [Column] public string CateName {get;set;}
        [Column] public string Spec {get;set;}
        [Column] public string Num {get;set;}
        [Column] public string Address {get;set;}
        [Column] public string Source {get;set;}
        
     }
    
     [TableName("dbo.Role")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class RoleInfo:MCS.Record<RoleInfo>
     {
        
        [Column] public long Id {get;set;}
        [Column] public string RoleName {get;set;}
        [Column] public string Description {get;set;}
        
     }

}

