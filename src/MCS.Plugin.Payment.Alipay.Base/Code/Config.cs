using MCS.Plugin.PaymentPlugin;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MCS.Plugin.Payment.Alipay.Base
{
    public class Config : ConfigBase
    {

        static string app_id = "";

        public string APP_ID
        {
            get { return app_id; }
            set { app_id = value; }
        }

        // 支付宝网关
        static string gatewayUrl = "https://openapi.alipay.com/gateway.do";

        public string GatewayUrl
        {
            get { return gatewayUrl; }
            set { gatewayUrl = value; }
        }
        // 商户私钥，您的原始格式RSA私钥
        static string private_key = "";

        /// <summary>
        /// 获取或设置商户的私钥
        /// 如果签名方式设置为“0001”时，请设置该参数
        /// </summary>
        public string Private_key
        {
            get { return private_key; }
            set { private_key = value; }
        }

        // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
        static string alipay_public_key = "";
        /// <summary>
        /// 获取或设置支付宝的公钥
        /// 如果签名方式设置为“0001”时，请设置该参数
        /// </summary>
        public string Public_key
        {
            get { return alipay_public_key; }
            set { alipay_public_key = value; }
        }
        // 签名方式
        static string sign_type = "RSA2";
        /// <summary>
        /// 获取签名方式
        /// </summary>
        public string Sign_type
        {
            get
            {
                //签名方式，选择项：RSA、RSA2
                return sign_type;
            }
            set
            {
                sign_type = value;
            }
        }
        // 编码格式
        static string charset = "UTF-8";
        /// <summary>
        /// 获取字符编码格式
        /// </summary>
        [XmlIgnoreAttribute]
        public string Input_charset
        {
            get
            {
                //字符编码格式 目前支持 gbk 或 utf-8
                return charset;
            }
        }
        public string Logo { get; set; }
        public string HelpImage
        {
            get;
            set;
        }

        public string GatewayUrlMethod
        {
            get; set;
        }
    }
}
