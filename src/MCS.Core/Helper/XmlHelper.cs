using System;
using System.IO;
using System.Xml.Serialization;

namespace MCS.Core.Helper
{
    public class XmlHelper
    {
        #region  XML序列化

        /// <summary>
        /// XML序列化
        /// </summary>
        /// <param name="obj">序列对象</param>
        /// <param name="filePath">XML文件路径</param>
        /// <returns>是否成功</returns>
        public static bool SerializeToXml(object obj, string filePath)
        {
            bool result = false;

            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);

                result = true;
            }
            catch (Exception ex)
            {
                Log.Error("", ex);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return result;

        }

        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <param name="type">目标类型(Type类型)</param>
        /// <param name="filePath">XML文件路径</param>
        /// <returns>序列对象</returns>
        public static object DeserializeFromXML(Type type, string filePath)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                Log.Error("", ex);
                return null;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
        #endregion


        #region  XML序列化 OSS策略

        /// <summary>
        /// XML序列化
        /// </summary>
        /// <param name="obj">序列对象</param>
        /// <param name="filePath">XML文件路径</param>
        /// <returns>是否成功</returns>
        public static bool SerializeToXmlByOSS(object obj, string filePath)
        {
            bool result = false;

            try
            {
                string sDirectory = IOHelper.UrlToVirtual(filePath);
                XmlSerializer xml = new XmlSerializer(obj.GetType());
                MemoryStream Stream = new MemoryStream();
                xml.Serialize(Stream, obj);

                byte[] b = Stream.ToArray();
                MemoryStream stream2 = new MemoryStream(b);
                MCSIO.CreateFile(sDirectory, stream2, Core.FileCreateType.Create);

                result = true;
            }
            catch (Exception ex)
            {
                Log.Error("", ex);
            }
            return result;

        }

        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <param name="type">目标类型(Type类型)</param>
        /// <param name="filePath">XML文件路径</param>
        /// <returns>序列对象</returns>
        public static object DeserializeFromXMLByOSS(Type type, string filePath)
        {
            try
            {
                string sDirectory = IOHelper.UrlToVirtual(filePath);
                if (MCSIO.ExistFile(sDirectory))
                {
                    XmlSerializer xs = new XmlSerializer(type);
                    byte[] b = MCSIO.GetFileContent(sDirectory);
                    string str = System.Text.Encoding.Default.GetString(b);
                    MemoryStream fs = new MemoryStream(b);
                    return xs.Deserialize(fs);
                }
                else return DeserializeFromXML(type, filePath);
            }
            catch (Exception ex)
            {
                Log.Error("", ex);
                return null;
            }
        }

        #endregion
    }
}