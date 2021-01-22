using MCS.Core;
using MCS.Core.Plugins.Message;
using MCS.Plugin.MessagePlugin;
using System;
using System.IO;
using System.Xml.Serialization;

namespace MCS.Plugin.Message.Email
{
    class EmailCore
    {
        /// <summary>
        /// 工作目录
        /// </summary>
        public static string WorkDirectory { get; set; }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public static MessageEmailConfig GetConfig()
        {
            Log.Info("email1---sss");
            string sDirectory = MCS.Core.Helper.IOHelper.UrlToVirtual(WorkDirectory) + "/Data/Email.config";
            MessageEmailConfig config = new MessageEmailConfig();

            if (MCSIO.ExistFile(sDirectory))
            {
                XmlSerializer xs = new XmlSerializer(typeof(MessageEmailConfig));
                byte[] b = MCS.Core.MCSIO.GetFileContent(sDirectory);
                string str = System.Text.Encoding.Default.GetString(b);
                MemoryStream fs = new MemoryStream(b);
                config = (MessageEmailConfig)xs.Deserialize(fs);
            }
            else
            {
                SaveConfig(config);
            }

            Log.Info("email1---eee");
            return config;
        }

        /// <summary>
        /// 获取邮件发送内容
        /// </summary>
        /// <returns></returns>
        public static MessageContent GetMessageContentConfig()
        {
            Log.Info("email2---sss");
            MessageContent config = Core.Cache.Get<MessageContent>("EmailMessageContent");
            if (config == null)
            {
                string sDirectory = MCS.Core.Helper.IOHelper.UrlToVirtual(WorkDirectory) + "/Data/MessageContent.xml";

                if (MCSIO.ExistFile(sDirectory))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(MessageContent));
                    byte[] b = MCS.Core.MCSIO.GetFileContent(sDirectory);
                    string str = System.Text.Encoding.Default.GetString(b);
                    MemoryStream fs = new MemoryStream(b);
                    config = (MessageContent)xs.Deserialize(fs);
                }
                else
                {
                    SaveMessageContentConfig(config);
                }
            }
            Log.Info("email2---eee");
            return config;
        }

        /// <summary>
        /// 获取发送状态
        /// </summary>
        /// <returns></returns>
        public static MessageStatus GetMessageStatus()
        {
            Log.Info("email3---sss");
            MessageStatus config = new MessageStatus();
            string sDirectory = MCS.Core.Helper.IOHelper.UrlToVirtual(WorkDirectory) + "/Data/config.xml";

            if (MCSIO.ExistFile(sDirectory))
            {
                XmlSerializer xs = new XmlSerializer(typeof(MessageStatus));
                byte[] b = MCS.Core.MCSIO.GetFileContent(sDirectory);
                string str = System.Text.Encoding.UTF8.GetString(b);
                Log.Info("email2---:" + str);
                MemoryStream fs = new MemoryStream(b);
                config = (MessageStatus)xs.Deserialize(fs);
            }
            Log.Info("email3---eee");
            return config;
        }


        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="config"></param>
        public static void SaveConfig(MessageEmailConfig config)
        {
            //using (FileStream fs = new FileStream(WorkDirectory + "\\Data\\Email.config", FileMode.Create))
            //{
            //    XmlSerializer xs = new XmlSerializer(typeof(MessageEmailConfig));
            //    xs.Serialize(fs, config);
            //}

            string sDirectory = MCS.Core.Helper.IOHelper.UrlToVirtual(WorkDirectory) + "/Data/Email.config";
            XmlSerializer xml = new XmlSerializer(typeof(MessageEmailConfig));
            MemoryStream Stream = new MemoryStream();
            xml.Serialize(Stream, config);

            byte[] b = Stream.ToArray();
            MemoryStream stream2 = new MemoryStream(b);
            MCS.Core.MCSIO.CreateFile(sDirectory, stream2, Core.FileCreateType.Create);
        }

        /// <summary>
        /// 保存短信内容配置
        /// </summary>
        /// <param name="config"></param>
        public static void SaveMessageContentConfig(MessageContent config)
        {
            //using (FileStream fs = new FileStream(WorkDirectory + "\\Data\\MessageContent.xml", FileMode.Create))
            //{
            //    XmlSerializer xs = new XmlSerializer(typeof(MessageContent));
            //    xs.Serialize(fs, config);
            //    Core.Cache.Insert("MessageContent", config);
            //}

            string sDirectory = MCS.Core.Helper.IOHelper.UrlToVirtual(WorkDirectory) + "/Data/MessageContent.config";
            XmlSerializer xml = new XmlSerializer(typeof(MessageContent));
            MemoryStream Stream = new MemoryStream();
            xml.Serialize(Stream, config);

            byte[] b = Stream.ToArray();
            MemoryStream stream2 = new MemoryStream(b);
            MCS.Core.MCSIO.CreateFile(sDirectory, stream2, Core.FileCreateType.Create);
            Core.Cache.Insert("EmailMessageContent", config);
        }

        /// <summary>
        /// 保持消息发送状态
        /// </summary>
        /// <param name="config"></param>
        public static void SaveMessageStatus(MessageStatus config)
        {
            string sDirectory = MCS.Core.Helper.IOHelper.UrlToVirtual(EmailCore.WorkDirectory) + "/Data/config.xml";
            XmlSerializer xml = new XmlSerializer(typeof(MessageStatus));
            MemoryStream Stream = new MemoryStream();
            xml.Serialize(Stream, config);

            byte[] b = Stream.ToArray();
            MemoryStream stream2 = new MemoryStream(b);
            MCS.Core.MCSIO.CreateFile(sDirectory, stream2, Core.FileCreateType.Create);
        }
    }
}
