using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCS.Core.Plugins.Payment;
using MCS.Core.Plugins;
using MCS.Plugin.PaymentPlugin;
using MCS.Core;
using System.Collections.Specialized;
using System.Xml;
using MCS.Plugin.Payment.Alipay.Base;
using System.Web;
using Alipay.AopSdk.Core;
using Alipay.AopSdk.Core.Request;
using Alipay.AopSdk.Core.Domain;
using Microsoft.AspNetCore.Http;
using Alipay.AopSdk.Core.Util;

namespace MCS.Plugin.Payment.AlipayWAP
{
    public class Service : AlipayServiceBase, IPaymentPlugin
    {
        public FormData GetFormData()
        {
            Config config = Utility<Config>.GetConfig(WorkDirectory);

            var formData = new FormData()
            {
                Items = new FormData.FormItem[] { 

                    //Partner
                   new  FormData.FormItem(){
                     DisplayName = "APPID",
                     Name = "APP_ID",
                     IsRequired = true,
                      Type= FormData.FormItemType.text,
                      Value=config.APP_ID
                   },

                   //Key
                   new  FormData.FormItem(){
                     DisplayName = "商户私钥",
                     Name = "Private_key",
                     IsRequired = true,
                       Type= FormData.FormItemType.text,
                       Value=config.Private_key
                   },
                   
                   //AlipayAccount
                   new  FormData.FormItem(){
                     DisplayName = "支付宝公钥",
                     Name = "Public_key",
                     IsRequired = true,
                      Type= FormData.FormItemType.text,
                      Value=config.Public_key
                   }
                }

            };
            return formData;
        }
        public string GetRequestUrl(string returnUrl, string notifyUrl, string orderId, decimal totalFee, string productInfo, string openId = null)
        {

            var config = Utility<Config>.GetConfig(WorkDirectory);
            DefaultAopClient client = new DefaultAopClient(config.GatewayUrl, config.APP_ID, config.Private_key, "json", "1.0", config.Sign_type, config.Public_key, config.Input_charset, false);
            AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
            AlipayTradeWapPayModel model = new AlipayTradeWapPayModel();
            model.Subject = productInfo;
            model.OutTradeNo = orderId;
            model.TimeoutExpress = "60m";
            model.TotalAmount = totalFee.ToString("f2");
            model.ProductCode = "QUICK_WAP_WAY";
            // 设置同步回调地址
            request.SetReturnUrl(returnUrl);
            // 设置异步通知接收地址
            request.SetNotifyUrl(notifyUrl);

            request.SetBizModel(model);
            var response = client.PageExecute(request, null, "GET");
            string strResult = string.Empty;
            if (!string.IsNullOrWhiteSpace(response.TradeNo))
            {
                strResult = response.Body;
                Log.Debug("GetRequestUrl response=" + strResult);
            }
            return response.Body;
        }

        /* GetRequestUrl 旧方法
        public string GetRequestUrl(string returnUrl, string notifyUrl, string orderId, decimal totalFee, string productInfo, string openId = null)
        {

            if (string.IsNullOrEmpty(productInfo))
                throw new PluginConfigException("商品信息不能为空!");
            if (string.IsNullOrEmpty(orderId))
                throw new PluginConfigException("订单号不能为空!");
            if (string.IsNullOrEmpty(returnUrl))
                throw new PluginConfigException("返回URL不能为空!");

            if (_config == null)
            {
                _config = Utility<Config>.GetConfig(WorkDirectory);
            }

            string strResult = string.Empty;
            Dictionary<string, string> dicPara = new Dictionary<string, string>();
            dicPara.Add("service", _config.GetTokenService);//取令牌接口
            dicPara.Add("format", "xml");//固定参数
            dicPara.Add("v", "2.0");//固定参数
            dicPara.Add("partner", _config.Partner);//合作者ID，支付宝提供
            dicPara.Add("req_id", System.DateTime.Now.ToString("yyyyMMddHHmmss"));
            dicPara.Add("sec_id", _config.Sign_type);//签名方式，暂时使用MD5
            dicPara.Add("_input_charset", "utf-8");

            //**************************
            #region 整理请求数据
            StringBuilder reqdata = new StringBuilder();
            reqdata.Append("<direct_trade_create_req>");

            reqdata.Append("<notify_url>");
            reqdata.Append(notifyUrl);
            reqdata.Append("</notify_url>");
            //用户购买的商品名称
            reqdata.Append("<subject>");
            reqdata.Append(productInfo);
            reqdata.Append("</subject>");
            //支付宝合作商户网站唯一订单号
            reqdata.Append("<out_trade_no>");
            reqdata.Append(orderId);
            reqdata.Append("</out_trade_no>");
            //该笔订单的资金总额，单位为RMB-Yuan。取值范围为[0.01，100000000.00]，精确到小数点后两位
            reqdata.Append("<total_fee>");
            reqdata.Append(totalFee);
            reqdata.Append("</total_fee>");
            //卖家的支付宝账号
            reqdata.Append("<seller_account_name>");
            reqdata.Append(_config.Seller_email);
            reqdata.Append("</seller_account_name>");
            //支付成功后的跳转页面链接
            reqdata.Append("<call_back_url>");
            reqdata.Append(returnUrl);
            reqdata.Append("</call_back_url>");
            //支付宝服务器主动通知商户网站里指定的页面http路径
            reqdata.Append("<notify_url>");
            reqdata.Append(notifyUrl);
            reqdata.Append("</notify_url>");
            //买家在商户系统的唯一标识。当该买家支付成功一次后，再次支付金额在30元内时，不需要再次输入密码
            reqdata.Append("<out_user>");
            reqdata.Append(string.Empty);
            reqdata.Append("</out_user>");
            //用户付款中途退出返回商户的地址
            reqdata.Append("<merchant_url>");
            reqdata.Append(string.Empty);
            reqdata.Append("</merchant_url>");
            //交易自动关闭时间，单位为分钟。默认值21600（即15天）agent_id
            reqdata.Append("<pay_expire>");
            reqdata.Append("30");
            reqdata.Append("</pay_expire>");
            //代理人ID
            reqdata.Append("<agent_id>");
            reqdata.Append(string.Empty);
            reqdata.Append("</agent_id>");

            reqdata.Append("</direct_trade_create_req>");
            #endregion
            //**************************
            dicPara.Add("req_data", reqdata.ToString());
            string strToken = Submit.BuildRequest(dicPara, _config);//调用接口取令牌
            Dictionary<string, string> dicResult = new Dictionary<string, string>();
            //Log.Debug("strToken=" + strToken);
            dicResult = Submit.ParseResponse(strToken, _config);
            if (dicResult["request_token"] != null)
            {
                dicPara = new Dictionary<string, string>();
                dicPara.Add("service", _config.GetDataService);//支付接口
                dicPara.Add("format", "xml");//固定参数
                dicPara.Add("v", "2.0");//固定参数
                dicPara.Add("partner", _config.Partner);//合作者ID，支付宝提供
                dicPara.Add("sec_id", _config.Sign_type);//签名方式，暂时使用MD5
                dicPara.Add("_input_charset", "utf-8");//固定参数

                reqdata = new StringBuilder();
                reqdata.Append("<auth_and_execute_req>");
                reqdata.Append("<request_token>");
                reqdata.Append(dicResult["request_token"].ToString());
                reqdata.Append("</request_token>");
                reqdata.Append("</auth_and_execute_req>");

                dicPara.Add("req_data", reqdata.ToString());
                strResult = Submit.BuildRequestUrl(dicPara, _config);//生成支付请求地址
            }
            else if (dicResult["res_error"] != null)
            {
                throw new PluginConfigException("调用支付接口返回异常：" + dicResult["res_error"].ToString());
            }
            return strResult;
        }
        */
        public string ConfirmPayResult()
        {
            return "success";
        }

        public string HelpImage
        {
            get { throw new NotImplementedException(); }
        }

        string _logo;
        public string Logo
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_logo))
                    _logo = Utility<Config>.GetConfig(WorkDirectory).Logo;
                return _logo;
            }
            set
            {
                _logo = value;
            }
        }

        public string PluginListUrl
        {
            set { throw new NotImplementedException(); }
        }

        NameValueCollection GetQuerystring(HttpRequest request)
        {
            NameValueCollection querystring;
            if (request.Method == "POST")
                querystring = request.Form;
            else
                querystring = request.Query;
            return querystring;
        }

        public PaymentInfo ProcessNotify(System.Web.HttpRequest context)
        {
            //Post方式
            var queryString = GetQuerystring(context);
            NameValueCollection coll = context.Form;
            Dictionary<string, string> paras = new Dictionary<string, string>();
            foreach (string key in coll.AllKeys)
            {
                paras.Add(key, coll[key]);
            }
            PaymentInfo info = new PaymentInfo();
            Config config = GetConfig();
            bool verifyResult = AlipaySignature.RSACheckV1(paras, config.Public_key, config.Input_charset, config.Sign_type, false);
            Core.Log.Debug("ProcessNotify verifyResult=" + verifyResult);
            if (verifyResult)
            {
                if ((queryString["trade_status"] == "TRADE_FINISHED" || queryString["trade_status"] == "TRADE_SUCCESS"))//验证成功
                {
                    string tradeNo = queryString["trade_no"];//支付宝交易号
                    DateTime tradeTime = DateTime.Parse(queryString["gmt_payment"]);//交易时间

                    info = new PaymentInfo()
                    {
                        OrderIds = queryString["out_trade_no"].Split(',').Select(t => long.Parse(t)),//商户订单号
                        TradNo = tradeNo,//支付宝交易流水号
                        TradeTime = tradeTime,//交易时间
                        ResponseContentWhenFinished = "success"
                    };
                }
            }
            return info;
        }
        public PaymentInfo ProcessReturn(HttpRequest context)
        {
            //Get方式
            var queryString = GetQuerystring(context);
            IFormCollection coll = context.Form;
            Dictionary<string, string> paras = new Dictionary<string, string>();
            foreach (string key in coll.AllKeys)
            {
                paras.Add(key, coll[key]);
            }
            PaymentInfo info = new PaymentInfo();
            Config config = GetConfig();
            bool verifyResult = AlipaySignature.RSACheckV1(paras, config.Public_key, config.Input_charset, config.Sign_type, false);
            Core.Log.Debug("ProcessReturn verifyResult=" + verifyResult);
            if (verifyResult)
            {
                if ((queryString["trade_status"] == "TRADE_FINISHED" || queryString["trade_status"] == "TRADE_SUCCESS"))//验证成功
                {
                    string tradeNo = queryString["trade_no"];//支付宝交易号
                    DateTime tradeTime = DateTime.Parse(queryString["gmt_payment"]);//交易时间

                    info = new PaymentInfo()
                    {
                        OrderIds = queryString["out_trade_no"].Split(',').Select(t => long.Parse(t)),//商户订单号
                        TradNo = tradeNo,//支付宝交易流水号
                        TradeTime = tradeTime,//交易时间
                        ResponseContentWhenFinished = "success"
                    };
                }
            }
            return info;
        }
        /* 旧回调方法
        public PaymentInfo ProcessNotify(System.Web.HttpRequestBase context)
        {
            //Post方式
            NameValueCollection coll = context.Form;
            Dictionary<string, string> paras = new Dictionary<string, string>();
            foreach (string key in coll.AllKeys)
            {
                paras.Add(key, coll[key]);
            }
            Notify notify = new Notify(WorkDirectory);
            PaymentInfo info = new PaymentInfo();
            string notifyid = notify.GetNotifyId(paras);
            bool isSign = notify.Verify(paras, notifyid, (string)coll["sign"], _config, false);
            if (isSign)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(coll["notify_data"]);
                string out_trade_no = xmlDoc.SelectSingleNode("/notify/out_trade_no").InnerText;
                string trade_no = xmlDoc.SelectSingleNode("/notify/trade_no").InnerText;
                string trade_status = xmlDoc.SelectSingleNode("/notify/trade_status").InnerText;
                string notify_time = xmlDoc.SelectSingleNode("/notify/notify_time").InnerText;
                if (trade_status == "TRADE_FINISHED" || trade_status == "TRADE_SUCCESS")
                {
                    info.OrderIds = out_trade_no.Split(',').Select(item => long.Parse(item));
                    info.TradNo = trade_no;
                    info.TradeTime = DateTime.Parse(notify_time);
                    info.ResponseContentWhenFinished = "success";
                }
            }
            return info;
        }
        
        public PaymentInfo ProcessReturn(System.Web.HttpRequestBase context)
        {
            //Get方式
            NameValueCollection coll = context.QueryString;
            Dictionary<string, string> paras = new Dictionary<string, string>();
            foreach (string key in coll.AllKeys)
            {
                paras.Add(key, coll[key]);
            }
            Notify notify = new Notify(WorkDirectory);
            string notifyid = notify.GetNotifyId(paras);
            bool isSign = notify.Verify(paras, notifyid, (string)coll["sign"], _config);
            PaymentInfo info = new PaymentInfo();
            if (isSign)
            {
                info.OrderIds = coll["out_trade_no"].Split(',').Select(item => long.Parse(item));
                info.TradNo = coll["trade_no"];
            }
            return info;
        }
        */
        public UrlType RequestUrlType
        {
            get { return UrlType.Page; }
        }

        public void SetFormValues(IEnumerable<KeyValuePair<string, string>> values)
        {
            var partnerItem = values.FirstOrDefault(item => item.Key == "APP_ID");
            if (string.IsNullOrWhiteSpace(partnerItem.Value))
                throw new PluginConfigException("APPID不能为空");

            var Private_keyItem = values.FirstOrDefault(item => item.Key == "Private_key");
            if (string.IsNullOrWhiteSpace(Private_keyItem.Value))
                throw new PluginConfigException("商户私钥不能为空");

            var Public_keyItem = values.FirstOrDefault(item => item.Key == "Public_key");
            if (string.IsNullOrWhiteSpace(Public_keyItem.Value))
                throw new PluginConfigException("支付宝公钥不能为空");

            Config oldConfig = Utility<Config>.GetConfig(WorkDirectory);
            oldConfig.APP_ID = partnerItem.Value;
            oldConfig.Private_key = Private_keyItem.Value;
            oldConfig.Public_key = Public_keyItem.Value;
            Utility<Config>.SaveConfig(oldConfig, WorkDirectory);
        }

        public void CheckCanEnable()
        {
            Config config = Utility<Config>.GetConfig(WorkDirectory);
            if (string.IsNullOrWhiteSpace(config.APP_ID))
                throw new PluginConfigException("未设置APPID");
            if (string.IsNullOrWhiteSpace(config.Private_key))
                throw new PluginConfigException("未设置商户私钥");

            if (string.IsNullOrWhiteSpace(config.Public_key))
                throw new PluginConfigException("未设置支付宝公钥");

            if (string.IsNullOrWhiteSpace(config.GatewayUrl))
                throw new PluginConfigException("未设置支付宝网关");

            if (string.IsNullOrWhiteSpace(config.Sign_type))
                throw new PluginConfigException("未设置签名方式");

            if (string.IsNullOrWhiteSpace(config.Input_charset))
                throw new PluginConfigException("未设置编码方式");
        }
    }
}
