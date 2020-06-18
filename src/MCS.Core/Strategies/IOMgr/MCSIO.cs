using System;
using System.Collections.Generic;
using System.IO;
namespace MCS.Core
{
    public static class MCSIO
    {
        private static IMCSIO _wmsIO;
        static MCSIO()
        {
            _wmsIO = null;
            Load();
        }
        private static void Load()
        {
            try
            {
                //container = builder.Build();
                _wmsIO = ObjectContainer.Current.Resolve<IMCSIO>();
            }
            catch (Exception ex)
            {
                throw new CacheRegisterException("ע�Ỻ������쳣", ex);
            }
            //_wmsIO = StrategyMgr.LoadStrategy<IWMSIO>();
        }

        public static IMCSIO GetWMSIO()
        {
            return _wmsIO;
        }
        /// <summary>
        /// ��ȡ�ļ��ľ���·��
        /// </summary>
        /// <param name="fileName">�ļ�����</param>
        /// <returns></returns>
        public static string GetFilePath(string fileName)
        {
            return _wmsIO.GetFilePath(fileName);
        }
        /// <summary>
        /// ��ȡͼƬ��·��
        /// </summary>
        /// <param name="imageName">ͼƬ����</param>
        /// <param name="styleName">��ʽ����</param>
        /// <returns></returns>
        public static string GetImagePath(string imageName, string styleName = null)
        {
            return _wmsIO.GetImagePath(imageName, styleName);
        }
        /// <summary>
        /// ��ȡ�ļ�����
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <returns></returns>
        public static byte[] GetFileContent(string fileName)
        {
            return _wmsIO.GetFileContent(fileName);
        }
        /// <summary>
        /// ������ͨ�ļ�
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <param name="stream">�ļ���</param>
        /// <param name="fileCreateType"></param>
        public static void CreateFile(string fileName, Stream stream, FileCreateType fileCreateType = FileCreateType.CreateNew)
        {
            _wmsIO.CreateFile(fileName, stream, fileCreateType);
        }
        /// <summary>
        /// ������ͨ�ļ�
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content">�ļ�����</param>
        /// <param name="fileCreateType"></param>
        public static void CreateFile(string fileName, string content, FileCreateType fileCreateType = FileCreateType.CreateNew)
        {
            _wmsIO.CreateFile(fileName, content, fileCreateType);
        }

        /// <summary>
        /// ����һ��Ŀ¼
        /// </summary>
        /// <param name="dirName"></param>
        public static void CreateDir(string dirName)
        {
            _wmsIO.CreateDir(dirName);
        }
        /// <summary>
        /// �Ƿ���ڸ��ļ�
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool ExistFile(string fileName)
        {
            if (fileName.Equals(""))
                return false;
            else
                return _wmsIO.ExistFile(fileName);
        }

        /// <summary>
        /// �Ƿ���ڸ�Ŀ¼
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public static bool ExistDir(string dirName)
        {
            return _wmsIO.ExistDir(dirName);
        }
        /// <summary>
        /// ɾ��Ŀ¼
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="recursive">Ҫ�Ƴ� ·���е�Ŀ¼����Ŀ¼���ļ�����Ϊ true������Ϊ false</param>
        public static void DeleteDir(string dirName, bool recursive = false)
        {
            _wmsIO.DeleteDir(dirName, recursive);
        }

        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string fileName)
        {
            _wmsIO.DeleteFile(fileName);
        }
        /// <summary>
        /// ����ɾ���ļ�
        /// </summary>
        /// <param name="fileNames"></param>
        public static void DeleteFiles(List<string> fileNames)
        {
            _wmsIO.DeleteFiles(fileNames);
        }
        /// <summary>
        /// �����ļ�����Ŀ¼
        /// </summary>
        /// <param name="sourceFileName">ԭ·��</param>
        /// <param name="destFileName">Ŀ��·��</param>
        /// <param name="overwrite">�Ƿ񸲸�</param>
        public static void CopyFile(string sourceFileName, string destFileName, bool overwrite = false)
        {
            _wmsIO.CopyFile(sourceFileName, destFileName, overwrite);
        }
        /// <summary>
        /// �ƶ��ļ�����Ŀ¼
        /// </summary>
        /// <param name="sourceFileName">ԭ·��</param>
        /// <param name="destFileName">Ŀ��·��</param>
        /// <param name="overwrite">�Ƿ񸲸�</param>
        public static void MoveFile(string sourceFileName, string destFileName, bool overwrite = false)
        {
            _wmsIO.MoveFile(sourceFileName, destFileName, overwrite);
        }
        /// <summary>
        /// �г�Ŀ¼�µ��ļ�����Ŀ¼
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="self">�Ƿ�������� Ĭ��Ϊfalse</param>
        /// <returns></returns>
        public static List<string> GetDirAndFiles(string dirName, bool self = false)
        {
            return _wmsIO.GetDirAndFiles(dirName, self);
        }

        /// <summary>
        /// �г�Ŀ¼�������ļ�
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="self">�Ƿ��������</param>
        /// <returns></returns>
        public static List<string> GetFiles(string dirName, bool self = false)
        {
            return _wmsIO.GetFiles(dirName, self);
        }
        /// <summary>
        /// ָ�����ļ���׷�����ݣ�����ļ������ڣ��򴴽���׷���ļ���
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="stream"></param>

        public static void AppendFile(string fileName, Stream stream)
        {
            _wmsIO.AppendFile(fileName, stream);
        }
        /// <summary>
        /// ָ�����ļ���׷�����ݣ�����ļ������ڣ��򴴽���׷���ļ���
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        public static void AppendFile(string fileName, string content)
        {
            _wmsIO.AppendFile(fileName, content);
        }
        /// <summary>
        ///  ��ȡĿ¼������Ϣ
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public static MetaInfo GetDirMetaInfo(string dirName)
        {
            return _wmsIO.GetDirMetaInfo(dirName);
        }
        /// <summary>
        /// ��ȡ�ļ�������Ϣ
        /// </summary>
        /// <param name="fileName">�ļ�����</param>
        /// <returns></returns>
        public static MetaInfo GetFileMetaInfo(string fileName)
        {
            return _wmsIO.GetFileMetaInfo(fileName);
        }

        /// <summary>
        /// ��������ͼ
        /// </summary>
        /// <param name="sourceFilename"></param>
        /// <param name="destFilename"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void CreateThumbnail(string sourceFilename, string destFilename, int width, int height)
        {
            _wmsIO.CreateThumbnail(sourceFilename, destFilename, width, height);
        }

        /// <summary>
        /// ��ȡ��ͬ�������ƷͼƬ
        /// </summary>
        /// <param name="productPath"></param>
        /// <param name="index"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static string GetProductSizeImage(string productPath, int index, int width = 0)
        {
            return _wmsIO.GetProductSizeImage(productPath, index, width);
        }

        /// <summary>
        /// ��ȡ��(http)��ȫ·��ͼƬ��APP���߽ӿڵ���
        /// </summary>
        /// <returns></returns>
        public static string GetRomoteImagePath(string imageName, string styleName = null)
        {
            if (string.IsNullOrWhiteSpace(imageName))
            {
                return "";
            }
            var path = _wmsIO.GetImagePath(imageName, styleName);
            if (!path.StartsWith("http"))
            {
                return GetHttpUrl() + path.Trim('/');
            }
            else
            {
                return path;
            }
        }

        /// <summary>
        /// ��ȡ��(http)��ȫ·�����ֳߴ��ͼƬ��APP���߽ӿڵ���
        /// </summary>
        /// <param name="productPath"></param>
        /// <param name="index"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static string GetRomoteProductSizeImage(string productPath, int index, int width = 0)
        {
            if (string.IsNullOrWhiteSpace(productPath))
            {
                return "";
            }
            var path = _wmsIO.GetProductSizeImage(productPath, index, width);
            if (!path.StartsWith("http"))
            {

                return GetHttpUrl() + path;
            }
            else
            {
                return path;
            }
        }

        public static bool CopyFolder(string fromDirName, string toDirName, bool includeFile)
        {
            return _wmsIO.CopyFolder(fromDirName, toDirName, includeFile);
        }

        /// <summary>
        /// ��ȡģ���ļ�
        /// </summary>
        /// <param name="fileName">ģ���ļ�·��</param>
        /// <returns>OSS�򷵻��ļ�,�����򷵻�null</returns>
        public static byte[] DownloadTemplateFile(string fileName)
        {
            if (_wmsIO.GetType().FullName == "WMS.Strategy.OSS")
            {
                if (_wmsIO.ExistFile(fileName))
                {
                    return _wmsIO.GetFileContent(fileName);
                }
            }
            return null;
        }

        /// <summary>
        /// �Ƿ���Ҫ���±����ļ�
        /// </summary>
        /// <param name="fileName">ģ���ļ�·��</param>
        /// <returns>OSS�����򷵻�true</returns>
        public static bool IsNeedRefreshFile(string fileName, out MetaInfo metaInfo)
        {
            metaInfo = null;
            if (_wmsIO.GetType().FullName == "WMS.Strategy.OSS")
            {
                if (_wmsIO.ExistFile(fileName))
                {
                    metaInfo = _wmsIO.GetFileMetaInfo(fileName);
                    return true;
                }
            }
            return false;
        }

        private static string GetHttpUrl()
        {
            string host = Core.Helper.WebHelper.GetHost();
            var port = Core.Helper.WebHelper.GetPort();
            var Scheme = Core.Helper.WebHelper.GetScheme();
            var portPre = port == "80" ? "" : ":" + port;
            return Scheme + "://" + host + portPre + "/";
        }
    }
}
