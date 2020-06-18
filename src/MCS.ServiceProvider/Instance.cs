using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using MZcms.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MZcms.Common;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace MZcms.ServiceProvider
{
    public class Instance<T> where T : IService
    {

        public static T Create
        {
            get
            {
                ContainerBuilder builder = new ContainerBuilder();

                ConfigurationBuilder configBuild = new ConfigurationBuilder();
                configBuild.SetBasePath(Directory.GetCurrentDirectory());
                configBuild.Add(new JsonConfigurationSource { Path = "Config/autofac.json", ReloadOnChange = true });
                IConfigurationRoot config = configBuild.Build();
                ConfigurationModule module = new ConfigurationModule(config);
                var components = config.GetSection("components").GetChildren();
                IConfigurationSection element = null;

                foreach (var item in components)
                {
                    var services = item.GetSection("services").GetChildren().FirstOrDefault();
                    var serviceItem = services.GetSection("type");
                    var serviceValue = serviceItem.Value;
                    if (serviceValue.Contains(typeof(T).FullName))
                    {
                        element = serviceItem;
                    }
                }

                GetServiceProviders();
                IContainer container = null;
                try
                {
                    //返回
                    T t;

                    if (element == null)
                    {

                        //服务名称
                        string iserviceName = typeof(T).Name;

                        //类型全名
                        string fullName = typeof(T).FullName;

                        //命名空间
                        string namespaceName = fullName.Substring(0, fullName.LastIndexOf('.'));

                        string implementClass = ServiceProviders[namespaceName] as string;

                        if (implementClass == null)
                            throw new ApplicationException("未配置" + fullName + "的实现");

                        string nameSpace = implementClass.Split(',')[0];
                        string assembly = implementClass.Split(',')[1];
                        string implementName = iserviceName.Substring(1);
                        string className = string.Format("{0}.{1}, {2}", nameSpace, implementName, assembly);

                        //获取对应类型
                        Type implementType = Type.GetType(className);

                        //如果未找到类型
                        if (implementType == null)
                            throw new NotImplementedException("未找到" + className);

                        //注册类型
                        builder.RegisterType(implementType).As<T>().InstancePerLifetimeScope();

                    }
                    else
                    {
                        Log.Info("RegisterModule");

                        builder.RegisterType<T>();
                        builder.RegisterModule(module);
                    }

                    container = builder.Build();
                    t = container.Resolve<T>();
                    return t;

                }
                catch (Exception ex)
                {
                    throw new ServiceInstacnceCreateException(typeof(T).Name + "服务实例创建失败", ex);
                }

            }

        }

        static object locker = new object();
        static Hashtable ServiceProviders = null;

        //获取服务列表
        static void GetServiceProviders()
        {
            if (ServiceProviders == null)
            {
                lock (locker)
                {
                    if (ServiceProviders == null)
                    {
                        ServiceProviders = new Hashtable();
                        ServiceProviders.Add("MZcms.IServices", "MZcms.Service" + "," + "MZcms.Service");
                    }
                }
            }
        }

    }
}
