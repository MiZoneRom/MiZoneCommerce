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
using Alipay.AopSdk.Core.Domain;
using Alipay.AopSdk.Core.Request;
using Microsoft.AspNetCore.Http;
using Alipay.AopSdk.Core.Util;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace MCS.Plugin.Payment.AlipayApp
{
    public class Service : AlipayServiceBase, IPaymentPlugin
    {
        public Service() : base()
        {

        }

        public void Regist(IServiceCollection services)
        {

        }

        public void UsePlugin(IApplicationBuilder app)
        {

        }

        public FormData GetFormData()
        {
            Config config = Utility<Config>.GetConfig(WorkDirectory);

            var formData = new FormData()
            {
                Items = new FormData.FormItem[] {

                   new  FormData.FormItem(){
                     DisplayName = "APPID",
                     Name = "APP_ID",
                     IsRequired = true,
                      Type= FormData.FormItemType.text,
                      Value=config.APP_ID
                   },

                   new  FormData.FormItem(){
                     DisplayName = "商户私钥",
                     Name = "Private_key",
                     IsRequired = true,
                       Type= FormData.FormItemType.text,
                       Value=config.Private_key
                   },

                   new FormData.FormItem(){
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
            if (string.IsNullOrEmpty(productInfo))
                throw new PluginConfigException("商品信息不能为空!");
            if (string.IsNullOrEmpty(orderId))
                throw new PluginConfigException("订单号不能为空!");
            if (string.IsNullOrEmpty(returnUrl))
                throw new PluginConfigException("返回URL不能为空!");

            DefaultAopClient client = new DefaultAopClient(_Config.GatewayUrl, _Config.APP_ID, _Config.Private_key, "json", "1.0", _Config.Sign_type, _Config.Public_key, _Config.Input_charset, false);
            AlipayTradeAppPayModel model = new AlipayTradeAppPayModel();
            model.Subject = productInfo;
            model.OutTradeNo = orderId;
            model.TimeoutExpress = "60m";
            model.TotalAmount = totalFee.ToString("f2");
            model.ProductCode = "QUICK_MSECURITY_PAY";

            AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();
            request.SetBizModel(model);
            request.SetNotifyUrl(notifyUrl);

            var response = client.SdkExecute(request);
            return response.Body;
        }

        /* GetRequestUrl 旧代码 
        public string GetRequestUrl(string returnUrl, string notifyUrl, string orderId, decimal totalFee, string productInfo, string openId = null)
        {

            if (string.IsNullOrEmpty(productInfo))
                throw new PluginConfigException("商品信息不能为空!");
            if (string.IsNullOrEmpty(orderId))
                throw new PluginConfigException("订单号不能为空!");
            if (string.IsNullOrEmpty(returnUrl))
                throw new PluginConfigException("返回URL不能为空!");

            
            Dictionary<string, string> dicPara = new Dictionary<string, string>();
            dicPara.Add("service", _Config.GetDataService);//取令牌接口
            dicPara.Add("partner", _Config.Partner);//合作者ID，支付宝提供
            dicPara.Add("_input_charset", _Config.Input_charset);
            dicPara.Add("out_trade_no", orderId);//固定参数
            dicPara.Add("subject", productInfo.Length>128?productInfo.Substring(0,128):productInfo) ;//固定参数
            dicPara.Add("payment_type", "1");//固定参数
            dicPara.Add("seller_id", _Config.Seller_email);//固定参数
            dicPara.Add("total_fee", totalFee.ToString());//固定参数
            dicPara.Add("body", productInfo);//固定参数
            dicPara.Add("it_b_pay", "30m");//固定参数
            dicPara.Add("notify_url", notifyUrl);//固定参数

            var paraStr = Submit.BuildRequestParaToString(dicPara, Encoding.GetEncoding(_Config.Input_charset), _Config);

            return paraStr;
        }
        */

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

        public Dictionary<string, string> GetRequestPost(HttpRequest Request)
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = (NameValueCollection)Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }

        public PaymentInfo ProcessNotify(HttpRequest context)
        {
            Dictionary<string, string> paras = GetRequestPost(context);

            PaymentInfo info = new PaymentInfo();
            bool verifyResult = AlipaySignature.RSACheckV1(paras, _Config.Public_key, _Config.Input_charset, _Config.Sign_type, false);
            Core.Log.Debug("ProcessNotify verifyResult=" + verifyResult);
            if (verifyResult)
            {
                if ((paras["trade_status"] == "TRADE_FINISHED" || paras["trade_status"] == "TRADE_SUCCESS"))//验证成功
                {
                    string tradeNo = paras["trade_no"];//支付宝交易号
                    DateTime tradeTime = DateTime.Parse(paras["gmt_payment"]);//交易时间
                    info = new PaymentInfo()
                    {
                        OrderIds = paras["out_trade_no"].Split(',').Select(t => long.Parse(t)),//商户订单号
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
            Dictionary<string, string> paras = GetRequestPost(context);

            PaymentInfo info = new PaymentInfo();
            bool verifyResult = AlipaySignature.RSACheckV1(paras, _Config.Public_key, _Config.Input_charset, _Config.Sign_type, false);
            Core.Log.Debug("ProcessReturn verifyResult=" + verifyResult);
            if (verifyResult)
            {
                if ((paras["trade_status"] == "TRADE_FINISHED" || paras["trade_status"] == "TRADE_SUCCESS"))//验证成功
                {
                    string tradeNo = paras["trade_no"];//支付宝交易号
                    DateTime tradeTime = DateTime.Parse(paras["gmt_payment"]);//交易时间
                    info = new PaymentInfo()
                    {
                        OrderIds = paras["out_trade_no"].Split(',').Select(t => long.Parse(t)),//商户订单号
                        TradNo = tradeNo,//支付宝交易流水号
                        TradeTime = tradeTime,//交易时间
                        ResponseContentWhenFinished = "success"
                    };
                }
            }

            return info;
        }

        /* 旧方法回调
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
            string notifyid = context.Form["notify_id"];//获取notify_id
            string sign = context.Form["sign"];//获取sign
            var signStr = "";
            //foreach(var para in paras)
            //{
            //    signStr += "\r\n" + para.Key + ":" + para.Value+ ";\r\n";
            //}

            //Core.Log.Debug("notifyid:" + notifyid+"，签名方式:"+_Config.Sign_type+"\r\n参数:"+signStr+ ";\r\n");

            bool isSign = notify.Verify(paras, notifyid, sign, _Config);
            if (isSign)
            {
                string out_trade_no =coll["out_trade_no"];
                string trade_status =coll["trade_status"] ;
                string notify_time = coll["notify_time"] ;
                string TradNo = coll["trade_no"];
                if (trade_status == "TRADE_FINISHED" || trade_status == "TRADE_SUCCESS")
                {
                    info.OrderIds = out_trade_no.Split(',').Select(item => long.Parse(item));
                    info.TradeTime = DateTime.Parse(notify_time);
                    info.TradNo = TradNo;
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
            bool isSign = notify.Verify(paras, string.Empty, (string)coll["sign"], _Config);
            PaymentInfo info = new PaymentInfo();
            if (isSign)
            {
                info.OrderIds = coll["out_trade_no"].Split(',').Select(item => long.Parse(item));
                info.TradNo = coll["trade_no"];
            }
            return info;
        }
        */

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
