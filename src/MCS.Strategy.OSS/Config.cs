using MCS.Core;
using MCS.Strategy;
using System.Configuration;

namespace MCS.Strategy
{
    /// <summary>
    /// 配置类
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// OSS 内网Endpoint地址
        /// </summary>
        public static readonly string PrivateEndpoint = Core.ConfigurationManager.AppSettings.GetSection("OSS")["PrivateEndpoint"];

        /// <summary>
        /// 文件服务器域名（即OSS外网域名）
        /// </summary>
        public static readonly string FileServerDomain = Core.ConfigurationManager.AppSettings.GetSection("OSS")["FileServerDomain"];

        /// <summary>
        /// 阿里云AccessKeyId
        /// </summary>
        public static readonly string AccessKeyId = Core.ConfigurationManager.AppSettings.GetSection("OSS")["AccessKeyId"];

        /// <summary>
        /// 阿里云AccessKeySecret
        /// </summary>
        public static readonly string AccessKeySecret = Core.ConfigurationManager.AppSettings.GetSection("OSS")["AccessKeySecret"];

        /// <summary>
        /// OSS BucketName
        /// </summary>
        public static readonly string BucketName = Core.ConfigurationManager.AppSettings.GetSection("OSS")["BucketName"];

        /// <summary>
        /// 图片服务器域名（开通OSS图片服务后给出的图片服务域名）
        /// </summary>
        public static readonly string ImageServerDomain = Core.ConfigurationManager.AppSettings.GetSection("OSS")["ImageServerDomain"];

        static Config()
        {
            if (string.IsNullOrWhiteSpace(PrivateEndpoint))
                throw new MCSIOException("未配置PrivateEndpoint节点");
            if (string.IsNullOrWhiteSpace(FileServerDomain))
                throw new MCSIOException("未配置FileServerDomain节点");
            if (string.IsNullOrWhiteSpace(AccessKeyId))
                throw new MCSIOException("未配置AccessKeyId节点");
            if (string.IsNullOrWhiteSpace(AccessKeySecret))
                throw new MCSIOException("未配置AccessKeySecret节点");
            if (string.IsNullOrWhiteSpace(BucketName))
                throw new MCSIOException("未配置BucketName节点");
        }

    }
}
