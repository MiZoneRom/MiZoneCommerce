using MCS.Core;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using MCS.Core.Plugins.Payment;
using MCS.Core.Helper;
using MCS.Plugin.PaymentPlugin;
using MCS.Plugin.Payment.Alipay.Base;
using System.Web;
using Alipay.AopSdk.Core;
using Alipay.AopSdk.Core.Domain;
using Alipay.AopSdk.Core.Request;
using Alipay.AopSdk.Core.Response;
using Microsoft.AspNetCore.Http;
using Alipay.AopSdk.Core.Util;
using MCS.Core.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace MCS.Plugin.Payment.Alipay
{
    public class Service : AlipayServiceBase, IPaymentPlugin
    {
        #region 属性

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

        public string ConfirmPayResult()
        {
            return "success";
        }




        public UrlType RequestUrlType
        {
            get { return UrlType.Page; }
        }


        public string HelpImage
        {
            get { throw new NotImplementedException(); }
        }
        #endregion

        public void Regist(IServiceCollection services)
        {

        }

        public void UsePlugin(IApplicationBuilder app)
        {

        }

        public string GetRequestUrl(string returnUrl, string notifyUrl, string orderId, decimal totalFee, string productInfo, string openId = null)
        {

            Config config = _Config;
            //服务器异步通知页面路径
            notifyUrl = string.Format(notifyUrl);
            //页面跳转同步通知页面路径
            returnUrl = string.Format(returnUrl);
            //商户订单号
            string outTradeNo = orderId.ToString();
            DefaultAopClient client = new DefaultAopClient(config.GatewayUrl, config.APP_ID, config.Private_key, "json", "1.0", config.Sign_type, config.Public_key, config.Input_charset, false);

            // 外部订单号，商户网站订单系统中唯一的订单号
            string out_trade_no = orderId;
            // 订单名称
            string subject = productInfo;
            // 付款金额
            string total_amout = totalFee.ToString("F2");
            // 商品描述
            string body = productInfo;

            // 组装业务参数model
            AlipayTradePagePayModel model = new AlipayTradePagePayModel();
            model.Body = body;
            model.Subject = subject;
            model.TotalAmount = total_amout;
            model.OutTradeNo = out_trade_no;
            model.ProductCode = "FAST_INSTANT_TRADE_PAY";

            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();

            // 设置同步回调地址
            request.SetReturnUrl(returnUrl);
            // 设置异步通知接收地址
            request.SetNotifyUrl(notifyUrl);
            // 将业务model载入到request
            request.SetBizModel(model);

            AlipayTradePagePayResponse response = null;
            try
            {
                response = client.PageExecute(request, null, "GET");
                //Log.Debug("GetRequestUrl response=" + response.Body);
                return response.Body.ToString();
            }
            catch (Exception exp)
            {
                throw exp;
            }

            //return Submit.BuildRequestUrl(parameters, config);
        }
        public PaymentInfo ProcessReturn(HttpRequest request)
        {
            var queryString = GetQuerystring(request);
            Dictionary<string, string> sPara = UrlHelper.GetRequestGet(queryString);
            Config config = Utility<Config>.GetConfig(WorkDirectory);
            PaymentInfo paymentInfo = new PaymentInfo();
            if (sPara.Count > 0)//判断是否有带返回参数
            {
                if (sPara.ContainsKey("str"))
                {
                    sPara.Remove("str");
                }
                if (sPara.ContainsKey("balance"))
                {
                    sPara.Remove("balance");
                }
                bool verifyResult = AlipaySignature.RSACheckV1(sPara, config.Public_key, config.Input_charset, config.Sign_type, false);
                Core.Log.Debug("ProcessReturn verifyResult=" + verifyResult);
                if (verifyResult)//验证成功
                {
                    paymentInfo.OrderIds = queryString["out_trade_no"].Split(',').Select(t => long.Parse(t));//商户订单号
                    paymentInfo.TradNo = queryString["trade_no"];//支付宝交易流水号
                    paymentInfo.TradeTime = TypeHelper.StringToDateTime(queryString["notify_time"]);//交易时间
                }
                else//验证失败
                {
                    throw new ApplicationException("支付宝支付返回请求验证失败,QueryString:" + queryString.ToString());
                }
            }
            else
                throw new ApplicationException("支付宝支付返回请求未带参数,QueryString:" + queryString.ToString());
            return paymentInfo;
        }


        public PaymentInfo ProcessNotify(HttpRequest request)
        {
            var queryString = GetQuerystring(request);

            Dictionary<string, string> sPara = UrlHelper.GetRequestPost(queryString);
            PaymentInfo paymentInfo = null;

            if (queryString.Count > 0)//判断是否有带返回参数
            {
                Config config = GetConfig();
                if (sPara.ContainsKey("str"))
                {
                    sPara.Remove("str");
                }
                if (sPara.ContainsKey("balance"))
                {
                    sPara.Remove("balance");
                }
                bool verifyResult = AlipaySignature.RSACheckV1(sPara, config.Public_key, config.Input_charset, config.Sign_type, false);
                Core.Log.Debug("ProcessNotify verifyResult=" + verifyResult);
                if (verifyResult && (queryString["trade_status"] == "TRADE_FINISHED" || queryString["trade_status"] == "TRADE_SUCCESS"))//验证成功
                {
                    string tradeNo = queryString["trade_no"];//支付宝交易号
                    DateTime tradeTime = TypeHelper.StringToDateTime(queryString["gmt_payment"]);//交易时间

                    paymentInfo = new PaymentInfo()
                    {
                        OrderIds = queryString["out_trade_no"].Split(',').Select(t => long.Parse(t)),//商户订单号
                        TradNo = queryString["trade_no"],//支付宝交易流水号
                        TradeTime = TypeHelper.StringToDateTime(queryString["gmt_payment"])//交易时间
                    };
                }
                else//验证失败
                {
                    throw new ApplicationException("支付宝支付Notify请求验证失败,QueryString:" + queryString.ToString());
                }
            }
            else
                throw new ApplicationException("支付宝支付Notify请求未带参数,QueryString:" + queryString.ToString());
            return paymentInfo;
        }


        NameValueCollection GetQuerystring(HttpRequest request)
        {
            NameValueCollection querystring;
            if (request.Method == "POST")
                querystring = (NameValueCollection)request.Form;
            else
                querystring = (NameValueCollection)request.Query;
            return querystring;
        }

        public string PluginListUrl
        {
            set { }
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

    }
}
