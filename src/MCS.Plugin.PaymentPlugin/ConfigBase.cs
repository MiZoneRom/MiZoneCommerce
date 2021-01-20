using MCS.Core;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MCS.Plugin.PaymentPlugin
{
   public abstract  class ConfigBase
    {

        /// <summary>
        /// 支持的平台
        /// </summary>
        public PlatformType[] SupportPlatfoms { get; set; }


        /// <summary>
        /// 开启状态
        /// </summary>
        public Dictionary<PlatformType, bool> OpenStatus { get; set; }

    }
}
