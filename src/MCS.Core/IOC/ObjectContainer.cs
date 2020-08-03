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
        private static ContainerBuilder container;

        public static void ApplicationStart(ContainerBuilder c)
        {
            container = c;
            current = new ObjectContainer(container);
        }

        public static ObjectContainer Current
        {
            get
            {
                if (current == null)
                {
                    ApplicationStart(container);
                }
                return current;
            }
        }

        protected ContainerBuilder Container
        {
            get;
            set;
        }

        protected ObjectContainer()
        {
            Container = new ContainerBuilder();
        }

        protected ObjectContainer(ContainerBuilder inversion)
        {
            Container = inversion;
        }

        public void RegisterType<T>()
        {
            current.RegisterType<T>();
        }

        public T Resolve<T>()
        {
            Autofac.IContainer container = null;
            T t;
            Container.RegisterType<T>();

            ConfigurationBuilder configBuild = new ConfigurationBuilder();
            configBuild.AddJsonFile("Config/autofac.json");
            IConfigurationRoot config = configBuild.Build();
            ConfigurationModule module = new ConfigurationModule(config);
            Container.RegisterModule(module);

            container = Container.Build();
            t = container.Resolve<T>();
            return t;
        }


    }
}
