using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace MCS.Core
{
    public class ConfigurationManager
    {
        public readonly static IConfiguration Configuration;
        static ConfigurationManager()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        public static ConnectionStringSettings ConnectionStrings(string keyName)
        {
            string connectString = Configuration.GetConnectionString(keyName);
            string providerName = Configuration.GetConnectionString(keyName + "ProviderName");
            return new ConnectionStringSettings() { Name = keyName, ConnectionString = providerName, ProviderName = providerName };
        }

        public static string AppSettings(string keyName)
        {
            return Configuration["Appsettings:" + keyName];
        }

        public static int ConnectionStringsCount
        {
            get { return 1; }
        }

    }

    public class ConnectionStringSettings
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
    }

}
