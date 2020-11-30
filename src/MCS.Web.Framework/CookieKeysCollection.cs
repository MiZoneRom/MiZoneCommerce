
namespace MCS.Web.Framework
{
    /// <summary>
    /// Cookie集合
    /// </summary>
    public class CookieKeysCollection
    {
        /// <summary>
        /// 平台管理员登录标识
        /// </summary>
        public const string PLATFORM_MANAGER = "MCS-Manager";

        /// <summary>
        /// 会员登录标识
        /// </summary>
        public const string MCS_USER = "MCS-User";

        /// <summary>
        /// 会员登录标识
        /// </summary>
        public const string MCS_ACTIVELOGOUT = "d783ea20966909ff";

        /// <summary>
        /// 分销销售员编号
        /// </summary>
        public const string MCS_DISTRIBUTION_SPREAD_ID_COOKIE_NAME = "MCS-dspreadid";

        /// <summary>
        /// 需要清理分销销售员编号
        /// </summary>
        public const string MCS_NEED_CLEAR_DISTRIBUTION_SPREAD_ID_COOKIE_NAME = "MCS-needclearspreadid";

        /// <summary>
        /// 不同平台用户key
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static string MCS_USER_KEY(string platform)
        {
            return string.Format("MCS-{0}User", platform);
        }

        /// <summary>
        /// 
        /// </summary>
        public const string MCS_USER_OpenID = "MCS-User_OpenId";
        
        /// <summary>
        /// 最后产生访问时间
        /// </summary>
        public const string MCS_LASTOPERATETIME = "MCS_LastOpTime";

		/// <summary>
		/// 用户角色(Admin)
		/// </summary>
		public const string USERROLE_ADMIN = "0";

		/// <summary>
		/// 用户角色(User)
		/// </summary>
		public const string USERROLE_USER = "2";
    }
}