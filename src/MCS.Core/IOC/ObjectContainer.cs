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
        private static IinjectContainer container;
        public static void ModuleStart(IinjectContainer c)
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
                    ModuleStart(container);
                }
                return current;
            }
        }

        protected IinjectContainer Container
        {
            get;
            set;
        }

        protected ObjectContainer()
        {
            Container = new DefaultContainerForDictionary();
        }

        protected ObjectContainer(IinjectContainer inversion)
        {
            Container = inversion;
        }

        public void RegisterType<T>()
        {
            Container.RegisterType<T>();
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

    }
}
