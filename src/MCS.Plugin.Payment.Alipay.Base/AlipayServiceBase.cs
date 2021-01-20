using MCS.Core;
using MCS.Core.Plugins;
using MCS.Core.Plugins.Payment;
using MCS.Core.Helper;
using MCS.Plugin.PaymentPlugin;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using Alipay.AopSdk.Core;
using Alipay.AopSdk.Core.Request;
using Alipay.AopSdk.Core.Domain;
using Microsoft.AspNetCore.Http;

namespace MCS.Plugin.Payment.Alipay.Base
{
    public class AlipayServiceBase : PaymentBase<Config>
    {
        #region 配置信息
        private Config __config;
        protected Config _Config
        {
            get
            {
                if (__config == null)
                {
                    __config = GetConfig();
                }
                return __config;
            }
        }
        #endregion

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        public Config GetConfig()
        {
            Config config = Utility<Config>.GetConfig(WorkDirectory);
            return config;
        }

        /// <summary>
        /// 退款入口
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public override RefundFeeReturnModel ProcessRefundFee(PaymentPara para)
        {
            
            Config config = GetConfig();

            if (string.IsNullOrEmpty(config.Private_key))
                throw new PluginException("未设置私钥");
            
            DefaultAopClient client = new DefaultAopClient(config.GatewayUrl, config.APP_ID, config.Private_key, "json", "1.0", config.Sign_type, config.Public_key, config.Input_charset, false);
            AlipayTradeRefundRequest request = new AlipayTradeRefundRequest();
            AlipayTradeRefundModel model = new AlipayTradeRefundModel();
            model.OutTradeNo = para.out_trade_no;//商户支付订单号
            model.TradeNo = para.pay_trade_no;//支付宝交易号
            model.RefundAmount = para.refund_fee.ToString("F2").Trim();
            model.RefundReason = "平台协商退款";
            model.OutRequestNo = para.out_refund_no;
            request.SetBizModel(model);
            var response = client.Execute(request);
            RefundFeeReturnModel paymentInfo = new RefundFeeReturnModel();
            paymentInfo.RefundResult = RefundState.Failure;
            paymentInfo.RefundMode = RefundRunMode.Sync;
            if (!string.IsNullOrWhiteSpace(response.FundChange) && response.FundChange.ToLower()=="y")
            {
                paymentInfo.RefundResult = RefundState.Success;
            }
            return paymentInfo;
            /*
            //退款网关
            string gateway = "https://mapi.alipay.com/gateway.do";
            //数据初始
            RefundFeeReturnModel paymentInfo = new RefundFeeReturnModel();
            paymentInfo.RefundResult = RefundState.Failure;
            paymentInfo.RefundMode = RefundRunMode.Async;
            string refund_batch_no=para.out_refund_no;

            string strResult = string.Empty;
            Config _config = GetConfig();
            if (_config.ToLower() == "md5")
            {
                //多种签名机制参与参数不一样
                if (string.IsNullOrEmpty(_config.Key))
                    throw new PluginException("未设置Key");
            }
            else
            {
                if (string.IsNullOrEmpty(_config.Private_key))
                    throw new PluginException("未设置私钥");
            }

            Dictionary<string, string> dicPara = new Dictionary<string, string>();
            //整理基础数据
            dicPara.Add("service", "refund_fastpay_by_platform_pwd");//服务固定，退款
            dicPara.Add("partner", _config.Partner);//合作者ID，支付宝提供
            dicPara.Add("_input_charset", _config.Input_charset);
            dicPara.Add("notify_url", para.notify_url);

            //整理业务数据
            dicPara.Add("seller_user_id", _config.Partner);
            dicPara.Add("refund_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            dicPara.Add("batch_no", refund_batch_no);
            dicPara.Add("batch_num", "1");
            dicPara.Add("detail_data", para.pay_trade_no.Trim() + "^" + para.refund_fee.ToString("F2").Trim() + "^平台协商退款".Trim());   //要去除非格式时用“^”、“|”、“$”、“#”
            string refundurl = Submit.BuildRequestUrl(dicPara, _config, gateway);
            paymentInfo.RefundResult = RefundState.Success;
            paymentInfo.ResponseContentWhenFinished = refundurl;
            paymentInfo.RefundNo = refund_batch_no;
            return paymentInfo;
            */
        }
        /// <summary>
        /// 退款异步通知
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override PaymentInfo ProcessRefundNotify(HttpRequest context)
        {
            PaymentInfo result = null;
            /*
            NameValueCollection coll = context.Form;
            Dictionary<string, string> paras = new Dictionary<string, string>();
            foreach (string key in coll.AllKeys)
            {
                paras.Add(key, coll[key]);
            }
            Config _config = _Config;
            Notify notify = new Notify(WorkDirectory);
            string notifyid = paras["notify_id"];
            string notifytype = paras["notify_type"];
            if (notifytype == null)
            {
                notifytype = "";
            }

            bool isSign = notify.Verify(paras, notifyid, (string)coll["sign"], _config);
            if (isSign && notifytype.ToLower() == "batch_refund_notify")
            {
                string batch_no = paras["batch_no"];
                string notify_time = paras["notify_time"];
                string success_num = paras["success_num"];
                int _snum = 0;
                if (int.TryParse(success_num, out _snum))
                {
                    if (_snum > 0)
                    {
                        string result_details = paras["result_details"];  //未使用，为退款详情，可以记录日志
#if DEBUG
                        Log.Info("支付宝退款：[" + batch_no + "]" + result_details);  //调试时记录日志
#endif
                        result = new PaymentInfo();
                        result.TradNo = batch_no;
                        result.TradeTime = DateTime.Parse(notify_time);
                        result.ResponseContentWhenFinished = "success";
                    }
                }
            }
            */
            throw new NotImplementedException("ProcessRefundNotify 未实现");
        }

        string _logo;

        public string Logo
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_logo))
                {
                    Config _config = GetConfig();
                    _logo = _config.Logo;
                }
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
        

        public virtual UrlType RequestUrlType
        {
            get { return UrlType.Page; }
        }


        public virtual string HelpImage
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 企业付款
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public override PaymentInfo EnterprisePay(EnterprisePayPara para)
        {
            Config config = _Config;

            DefaultAopClient client = new DefaultAopClient(config.GatewayUrl, config.APP_ID, config.Private_key, "json", "1.0", config.Sign_type, config.Public_key, config.Input_charset, false);
            AlipayFundTransToaccountTransferRequest request = new AlipayFundTransToaccountTransferRequest();
            AlipayFundTransToaccountTransferModel model = new AlipayFundTransToaccountTransferModel();

            model.OutBizNo = para.out_trade_no;//商户订单号
            model.PayeeType = "ALIPAY_LOGONID";//向支付宝账号转账
            model.Amount = para.amount.ToString("f2");//转账金额
            model.PayeeAccount = para.openid;//收款支付宝的账号
            if (para.check_name)
            {
                model.PayeeRealName = para.re_user_name;//如果不为空，会进行实名验证
            }
            model.PayerShowName = para.re_user_name;
            model.Remark = para.desc;

            request.SetBizModel(model);
            var response = client.Execute(request);
            var result = new PaymentInfo { };
            if (!string.IsNullOrWhiteSpace(response.PayDate) && !string.IsNullOrWhiteSpace(response.OrderId))
            {
                long orderid = 0;
                if (long.TryParse(response.OutBizNo, out orderid))
                {
                    result.OrderIds = new long[] { orderid };
                }
                result.TradeTime = DateTime.Parse(response.PayDate);
                result.TradNo = response.OrderId;
            }
            else
            {
                throw new PluginException("付款时,接口返回异常:" + (string.IsNullOrWhiteSpace(response.SubMsg) ? response.Msg : response.SubMsg));
            }

            return result;
        }
        /// <summary>
        /// 处理企业付款通知
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public override EnterprisePayNotifyInfo ProcessEnterprisePayNotify(HttpRequest request)
        {
            throw new NotImplementedException("ProcessEnterprisePayNotify");
            /*
            var queryString = GetQuerystring(request);

            Dictionary<string, string> sPara = UrlHelper.GetRequestPost(queryString);
            EnterprisePayNotifyInfo result = null;

            if (queryString.Count > 0)//判断是否有带返回参数
            {
                Config config = GetConfig();

                Notify notify = new Notify(WorkDirectory);

                bool verifyResult = notify.Verify(sPara, queryString["notify_id"], queryString["sign"], config);

                if (verifyResult)//验证成功
                {
                    result = new EnterprisePayNotifyInfo()
                    {
                        batch_no = sPara["batch_no"],
                        fail_details = sPara.Keys.Contains("fail_details") ? sPara["fail_details"] : "",
                        success_details = sPara.Keys.Contains("success_details") ? sPara["success_details"] : "",
                        notify_time = DateTime.Now
                    };
                }
                else//验证失败
                {
                    throw new ApplicationException("支付宝支付Notify请求验证失败,QueryString:" + queryString.ToString());
                }
            }
            else
                throw new ApplicationException("支付宝支付Notify请求未带参数,QueryString:" + queryString.ToString());
            return result;
            */
        }
    }
}
