
using System;

namespace MCS.CommonModel
{
    /// <summary>
    /// 缓存键值集合
    /// </summary>
    public static class CacheKeyCollection
    {
        /// <summary>
        /// 管理员账号信息缓存键
        /// </summary>
        /// <param name="managerId">管理员id</param>
        /// <returns></returns>
        public static string Manager(long managerId)
        {
            return string.Format("Cache-Manager-{0}", managerId);
        }

        /// <summary>
        /// 会员信息缓存键
        /// </summary>
        /// <param name="memberId">会员id</param>
        /// <returns></returns>
        public static string Member(long memberId)
        {
            return string.Format("Cache-Member-{0}", memberId);
        }

        /// <summary>
        /// 同时导入限制
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public const string UserImportOpCount = "Cache-UserImportOpCount";

        /// <summary>
        /// 移动端首页分页商品
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static string MobileHomeProductInfo(string name, long page)
        {
            return string.Format("Cache-M-HomeProductInfo-{0}-{1}", name, page);
        }

        /// <summary>
        /// 登录错误缓存（一般保留15分钟）
        /// </summary>
        /// <param name="username">出错时用户名</param>
        /// <returns></returns>
        public static string ManagerLoginError(string username)
        {
            return string.Format("Cache-Manager-Login-{0}", username);
        }

        /// <summary>
        /// 登录错误缓存（一般保留15分钟）
        /// </summary>
        /// <param name="username">出错时用户名</param>
        /// <returns></returns>
        public static string MemberLoginError(string username)
        {
            return string.Format("Cache-Member-Login-{0}", username);
        }

        /// <summary>
        /// 验证码短信发送次数
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string MessageSendNum(string username)
        {
            return string.Format("Cache-Message-Send-{0}", username);
        }


        public static string MemberPluginCheck(string username, string pluginId)
        {
            return string.Format("Cache-Member-{0}-{1}", username, pluginId);
        }

        public static string MemberPluginCheckTime(string username, string pluginId)
        {
            return string.Format("Cache-CheckTime-{0}-{1}", username, pluginId);
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pluginId"></param>
        /// <returns></returns>
        public static string MemberFindPwd(string username)
        {
            return string.Format("Cache-MemberFindPwd-{0}", username);
        }

        /// <summary>
        /// 验证管理员身份
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pluginId">插件域</param>
        /// <returns></returns>
        public static string MemberPluginAuthenticate(string username, string pluginId)
        {
            return string.Format("Cache-Authenticate-{0}-{1}", username, pluginId);
        }

        /// <summary>
        /// 验证管理员身份，时间
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pluginId">插件域</param>
        /// <returns></returns>
        public static string MemberPluginAuthenticateTime(string username, string pluginId)
        {
            return string.Format("Cache-AuthenticateTime-{0}-{1}", username, pluginId);
        }

        public static string MemberPluginFindPassWordTime(string username, string pluginId)
        {
            return string.Format("Cache-FindPasswordTime-{0}-{1}", username, pluginId);
        }

        public static string MemberPluginReBindTime(string username, string pluginId)
        {
            return string.Format("Cache-ReBindTime-{0}-{1}", username, pluginId);
        }
        public static string MemberPluginReBindStepTime(string username, string pluginId)
        {
            return string.Format("Cache-ReBindStepTime-{0}-{1}", username, pluginId);
        }

        public static string MemberFindPasswordCheck(string username, string pluginId)
        {
            return string.Format("Cache-Member-PassWord-{0}-{1}", username, pluginId);
        }

        public static string ShopPluginAuthenticate(string username, string pluginId)
        {
            return string.Format("Cache-ShopAut-{0}-{1}", username, pluginId);
        }
        public static string ShopPluginAuthenticateTime(string username, string pluginId)
        {
            return string.Format("Cache-ShopAutTime-{0}-{1}", username, pluginId);
        }

        /// <summary>
        /// 绑定银行卡
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pluginId"></param>
        /// <returns></returns>
        public static string ShopPluginBindBankTime(string username, string pluginId)
        {
            return string.Format("Cache-ShopBankTime-{0}-{1}", username, pluginId);
        }
        public static string ShopPluginBindBank(string username, string pluginId)
        {
            return string.Format("Cache-ShopBank-{0}-{1}", username, pluginId);
        }

        /// <summary>
        /// 支付状态缓存
        /// </summary>
        /// <param name="orderIds">订单编号</param>
        /// <returns></returns>
        public static string PaymentState(string orderIds)
        {
            return string.Format("Cache-PaymentState-{0}", orderIds);
        }

        /// <summary>
        /// 场景值缓存
        /// </summary>
        /// <param name="sceneid"></param>
        /// <returns></returns>
        public static string SceneState(string sceneid)
        {
            return string.Format("Cache-SceneState-{0}", sceneid);
        }
        public static string ChargeOrderKey(string id)
        {
            return string.Format("Cache-ChargeOrder-{0}", id);
        }

        /// <summary>
        /// 场景返回结果
        /// </summary>
        /// <param name="sceneid"></param>
        /// <returns></returns>
        public static string SceneReturn(string sceneid)
        {
            return string.Format("Cache-SceneReturn-{0}", sceneid);
        }

        /// <summary>
        /// 绑定微信
        /// </summary>
        /// <param name="sceneid"></param>
        /// <returns></returns>
        public static string BindingReturn(string sceneid)
        {
            return string.Format("Cache-BindingReturn-{0}", sceneid);
        }
        /// <summary>
        /// 省市区
        /// </summary>
        public const string Region = "Cache-Regions";

        /// <summary>
        /// 站点设置
        /// </summary>
        public const string SiteSettings = "Cache-SiteSettings";

        /// <summary>
        /// 首页菜单导航
        /// </summary>
        public const string Banners = "Cache-Banners";

        /// <summary>
        /// 广告
        /// </summary>
        public const string Advertisement = "Cache-Adverts";

        /// <summary>
        /// 询问菜单
        /// </summary>
        public const string BottomHelpers = "Cache-Helps";

        /// <summary>
        /// 主题设置
        /// </summary>
        public const string Themes = "Cache-Themes";

        /// <summary>
        /// 位置地址信息缓存
        /// </summary>
        /// <param name="fromLatLng"></param>
        /// <returns></returns>
        public static string LatlngCacheKey(string fromLatLng)
        {
            return string.Format("DataCache-latlngAddress-{0}", fromLatLng);
        }

    }
}
