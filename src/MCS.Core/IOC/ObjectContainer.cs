using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.Core
{
    public class ObjectContainer
    {
        private static ObjectContainer current;
        private static ContainerBuilder builder;

        public static ObjectContainer Current
        {
            get
            {
                if (builder == null) {
                    builder = new ContainerBuilder();
                    ConfigurationBuilder configBuild = new ConfigurationBuilder();
                    configBuild.AddJsonFile("Config/autofac.json");
                    IConfigurationRoot config = configBuild.Build();
                    ConfigurationModule module = new ConfigurationModule(config);
                    builder.RegisterModule(module);
                }
                return current;
            }
        }

        protected ContainerBuilder Container
        {
            get
            {
                return builder;
            }
            set
            {
                builder = value;
            }
        }

        public void RegisterType<T>()
        {
            Container.RegisterType<T>();
        }

        public T Resolve<T>()
        {
            Autofac.IContainer container = null;
            T t;
            builder.RegisterType<T>();
            container = builder.Build();
            t = container.Resolve<T>();
            return t;
        }


    }
}
