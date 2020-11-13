using Autofac;
using Autofac.Configuration;
using MCS.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MCS.Web
{
    public class AutoFacModule : Autofac.Module, IinjectContainer
    {
        private ContainerBuilder _builder;
        private static ILifetimeScope _container;

        protected override void Load(ContainerBuilder builder)
        {
            _builder = builder;

            //业务逻辑层所在程序集命名空间
            Assembly service = Assembly.Load("MCS.Service");

            //接口层所在程序集命名空间
            Assembly repository = Assembly.Load("MCS.IService");

            //自动注入
            builder.RegisterAssemblyTypes(service, repository)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            //注入模组
            ConfigurationBuilder configBuild = new ConfigurationBuilder();
            configBuild.AddJsonFile("Config/autofac.json");
            IConfigurationRoot config = configBuild.Build();
            ConfigurationModule module = new ConfigurationModule(config);
            builder.RegisterModule(module);

            //注入回调
            builder.RegisterBuildCallback(container => _container = container);

            ObjectContainer.ModuleStart(this);
        }

        #region IinjectContainer 成员
        /// <summary>
        /// 注册类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RegisterType<T>()
        {
            _builder.RegisterType<T>();
        }

        /// <summary>
        /// 解释
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// 解释
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
        #endregion

        public static ILifetimeScope GetContainer()
        {
            return _container;
        }

    }
}
