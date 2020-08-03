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
        private static ObjectContainer _current;
        private static IinjectContainer _container;

        /// <summary>
        /// 模块启动
        /// </summary>
        /// <param name="c"></param>
        public static void ModuleStart(IinjectContainer c)
        {
            _container = c;
            _current = new ObjectContainer(_container);
        }

        public static ObjectContainer Current
        {
            get
            {
                if (_current == null)
                {
                    ModuleStart(_container);
                }
                return _current;
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
