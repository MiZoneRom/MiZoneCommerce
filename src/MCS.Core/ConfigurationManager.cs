using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Collections.Generic;

namespace MCS.Core
{
    public class ConfigurationManager
    {
        private static readonly IConfigurationRoot _configuration;
        static ConfigurationManager()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        public static IConfigurationSection ConnectionStrings
        {
            get {
               return _configuration.GetSection("ConnectionStrings");
            }
        }

        public static IConfigurationRoot AppSettings
        {
            get
            {
                return _configuration;
            }
        }

    }

}
