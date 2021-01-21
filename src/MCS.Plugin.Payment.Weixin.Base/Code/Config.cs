using MCS.Core;
using MCS.Plugin.PaymentPlugin;

namespace MCS.Plugin.Payment.Weixin.Base
{
    public class Config : ConfigBase
    {

        public string AppId { get; set; }


        public string AppSecret { get; set; }


        public string MCHID { get; set; }


        public string Key { get; set; }

        public string Logo { get; set; }

        public string HelpImage { get; set; }

        public string pkcs12 { get; set; }
        public string Main_AppId { get; set; }
        public string Main_Mch_ID { get; set; }
    }
}
