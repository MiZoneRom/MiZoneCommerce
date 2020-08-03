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

            SetupResolveRules(builder);  //注入

            //builder.RegisterControllers(Assembly.GetExecutingAssembly());  //注入所有Controller
            //container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            ObjectContainer.ApplicationStart(this);
        }

        #region IinjectContainer 成员
        public void RegisterType<T>()
        {
            _builder.RegisterType<T>();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
        #endregion

        #region 私有方法
        private void SetupResolveRules(ContainerBuilder builder)
        {
            //var services = Assembly.Load("MCS.Service");
            //builder.RegisterAssemblyTypes(services).Where(t => t.GetInterface(typeof(MCS.IServices.IService).Name)!=null).AsImplementedInterfaces().InstancePerLifetimeScope();

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

            builder.RegisterBuildCallback(container => _container = container);
        }
        #endregion

        public static ILifetimeScope GetContainer()
        {
            return _container;
        }

    }
}
