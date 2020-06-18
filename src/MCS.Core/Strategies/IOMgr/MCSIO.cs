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
                throw new CacheRegisterException("注册缓存服务异常", ex);
            }
            //_wmsIO = StrategyMgr.LoadStrategy<IWMSIO>();
        }

        public static IMCSIO GetWMSIO()
        {
            return _wmsIO;
        }
        /// <summary>
        /// 获取文件的绝对路径
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <returns></returns>
        public static string GetFilePath(string fileName)
        {
            return _wmsIO.GetFilePath(fileName);
        }
        /// <summary>
        /// 获取图片的路径
        /// </summary>
        /// <param name="imageName">图片名称</param>
        /// <param name="styleName">样式名称</param>
        /// <returns></returns>
        public static string GetImagePath(string imageName, string styleName = null)
        {
            return _wmsIO.GetImagePath(imageName, styleName);
        }
        /// <summary>
        /// 获取文件内容
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static byte[] GetFileContent(string fileName)
        {
            return _wmsIO.GetFileContent(fileName);
        }
        /// <summary>
        /// 创建普通文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="stream">文件流</param>
        /// <param name="fileCreateType"></param>
        public static void CreateFile(string fileName, Stream stream, FileCreateType fileCreateType = FileCreateType.CreateNew)
        {
            _wmsIO.CreateFile(fileName, stream, fileCreateType);
        }
        /// <summary>
        /// 创建普通文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content">文件内容</param>
        /// <param name="fileCreateType"></param>
        public static void CreateFile(string fileName, string content, FileCreateType fileCreateType = FileCreateType.CreateNew)
        {
            _wmsIO.CreateFile(fileName, content, fileCreateType);
        }

        /// <summary>
        /// 创建一个目录
        /// </summary>
        /// <param name="dirName"></param>
        public static void CreateDir(string dirName)
        {
            _wmsIO.CreateDir(dirName);
        }
        /// <summary>
        /// 是否存在该文件
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
        /// 是否存在该目录
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public static bool ExistDir(string dirName)
        {
            return _wmsIO.ExistDir(dirName);
        }
        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="recursive">要移除 路径中的目录、子目录和文件，则为 true；否则为 false</param>
        public static void DeleteDir(string dirName, bool recursive = false)
        {
            _wmsIO.DeleteDir(dirName, recursive);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string fileName)
        {
            _wmsIO.DeleteFile(fileName);
        }
        /// <summary>
        /// 批量删除文件
        /// </summary>
        /// <param name="fileNames"></param>
        public static void DeleteFiles(List<string> fileNames)
        {
            _wmsIO.DeleteFiles(fileNames);
        }
        /// <summary>
        /// 复制文件到新目录
        /// </summary>
        /// <param name="sourceFileName">原路径</param>
        /// <param name="destFileName">目标路径</param>
        /// <param name="overwrite">是否覆盖</param>
        public static void CopyFile(string sourceFileName, string destFileName, bool overwrite = false)
        {
            _wmsIO.CopyFile(sourceFileName, destFileName, overwrite);
        }
        /// <summary>
        /// 移动文件到新目录
        /// </summary>
        /// <param name="sourceFileName">原路径</param>
        /// <param name="destFileName">目标路径</param>
        /// <param name="overwrite">是否覆盖</param>
        public static void MoveFile(string sourceFileName, string destFileName, bool overwrite = false)
        {
            _wmsIO.MoveFile(sourceFileName, destFileName, overwrite);
        }
        /// <summary>
        /// 列出目录下的文件和子目录
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="self">是否包含本身 默认为false</param>
        /// <returns></returns>
        public static List<string> GetDirAndFiles(string dirName, bool self = false)
        {
            return _wmsIO.GetDirAndFiles(dirName, self);
        }

        /// <summary>
        /// 列出目录下所有文件
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="self">是否包含自身</param>
        /// <returns></returns>
        public static List<string> GetFiles(string dirName, bool self = false)
        {
            return _wmsIO.GetFiles(dirName, self);
        }
        /// <summary>
        /// 指定的文件下追加内容（如果文件不存在，则创建可追加文件）
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="stream"></param>

        public static void AppendFile(string fileName, Stream stream)
        {
            _wmsIO.AppendFile(fileName, stream);
        }
        /// <summary>
        /// 指定的文件下追加内容（如果文件不存在，则创建可追加文件）
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        public static void AppendFile(string fileName, string content)
        {
            _wmsIO.AppendFile(fileName, content);
        }
        /// <summary>
        ///  获取目录基本信息
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public static MetaInfo GetDirMetaInfo(string dirName)
        {
            return _wmsIO.GetDirMetaInfo(dirName);
        }
        /// <summary>
        /// 获取文件基本信息
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <returns></returns>
        public static MetaInfo GetFileMetaInfo(string fileName)
        {
            return _wmsIO.GetFileMetaInfo(fileName);
        }

        /// <summary>
        /// 创建缩略图
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
        /// 获取不同尺码的商品图片
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
        /// 获取带(http)的全路径图片给APP或者接口调用
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
        /// 获取带(http)的全路径各种尺寸的图片给APP或者接口调用
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
        /// 获取模版文件
        /// </summary>
        /// <param name="fileName">模版文件路径</param>
        /// <returns>OSS则返回文件,其它则返回null</returns>
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
        /// 是否需要更新本地文件
        /// </summary>
        /// <param name="fileName">模版文件路径</param>
        /// <returns>OSS规则则返回true</returns>
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
