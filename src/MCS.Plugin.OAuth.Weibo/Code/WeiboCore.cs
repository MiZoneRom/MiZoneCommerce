using MCS.Core;
using MCS.Core.Helper;
using System.IO;
using System.Xml.Serialization;

namespace MCS.Plugin.OAuth.Weibo.Code
{
    public class WeiboCore
    {

        /// <summary>
        /// 工作目录
        /// </summary>
        public static string WorkDirectory { get; set; }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public static OAuthWeiboConfig GetConfig()
        {
            OAuthWeiboConfig config = new OAuthWeiboConfig();

            string sDirectory = IOHelper.UrlToVirtual(WorkDirectory) + "/Weibo.config";

            if (MCSIO.ExistFile(sDirectory))
            {
                XmlSerializer xs = new XmlSerializer(typeof(OAuthWeiboConfig));
                byte[] b = MCSIO.GetFileContent(sDirectory);
                string str = System.Text.Encoding.Default.GetString(b);
                MemoryStream fs = new MemoryStream(b);
                config = (OAuthWeiboConfig)xs.Deserialize(fs);
            }
            else
            {
                SaveConfig(config);
            }

            return config;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="config"></param>
        public static void SaveConfig(OAuthWeiboConfig config)
        {
            string sDirectory = IOHelper.UrlToVirtual(WorkDirectory) + "/Weibo.config";
            XmlSerializer xml = new XmlSerializer(typeof(OAuthWeiboConfig));
            MemoryStream Stream = new MemoryStream();
            xml.Serialize(Stream, config);

            byte[] b = Stream.ToArray();
            MemoryStream stream2 = new MemoryStream(b);
            MCSIO.CreateFile(sDirectory, stream2, Core.FileCreateType.Create);
        }
    }
}
