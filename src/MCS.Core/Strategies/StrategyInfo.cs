using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

namespace MCS.Core.Plugins
{
    public class StrategyInfo
    {
        /// <summary>
        /// 插件标识
        /// </summary>
        public string StrategyId { get; set; }

        /// <summary>
        /// 插件显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 程序集类全名
        /// </summary>
        public string ClassFullName { get; set; }

        /// <summary>
        /// 插件描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 插件所在目录
        /// </summary>
        public string StrategyDirectory { get; set; }

        public string Author { get; set; }

        public string Version { get; set; }

        public DateTime? AddedTime { get; set; }

        public string MinVersion { get; set; }

        public string MaxVersion { get; set; }

        public string Logo { get; set; }

        /// <summary>
        /// 是否开启
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 插件显示顺序
        /// </summary>
        public int DisplayIndex { get; set; }
    }
}
