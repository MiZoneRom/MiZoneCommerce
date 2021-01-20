﻿using MCS.Core;
using MCS.Core.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MCS.Plugin.OAuth.WeiXin.Assistant
{
    public class ConfigService<T> where T : class
    {

        public ConfigService()
        {
        }

        public static T GetConfig(string filename)
        {
            T config;
            string sDirectory = IOHelper.UrlToVirtual(filename);

            XmlSerializer xs = new XmlSerializer(typeof(T));
            byte[] b = MCSIO.GetFileContent(sDirectory);
            string str = System.Text.Encoding.Default.GetString(b);
            MemoryStream fs = new MemoryStream(b);
            config = (T)xs.Deserialize(fs);

            return config;
        }

        public static void SaveConfig(T config, string filename)
        {
            string sDirectory = IOHelper.UrlToVirtual(filename);
            XmlSerializer xml = new XmlSerializer(typeof(T));
            MemoryStream Stream = new MemoryStream();
            xml.Serialize(Stream, config);

            byte[] b = Stream.ToArray();
            MemoryStream stream2 = new MemoryStream(b);
            MCSIO.CreateFile(sDirectory, stream2, Core.FileCreateType.Create);
        }
    }
}
