using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dapper.Common;
using Microsoft.OpenApi.Models;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using System.Security.Policy;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Autofac;
using MCS.Core;
using System.Reflection;
using MCS.IServices;
using Autofac.Extensions.DependencyInjection;

namespace MCS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer;

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            //添加jwt验证：
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwtSection = Configuration.GetSection("jwt");

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = jwtSection.GetSection("ValidAudience").Value,//Audience
                        ValidIssuer = jwtSection.GetSection("ValidIssuer").Value,//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.GetSection("SecurityKey").Value))//拿到SecurityKey
                    };

                    //认证事件
                    options.Events = new JwtBearerEvents
                    {
                        //认证过期添加过期消息
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("act", "expired");
                            }
                            return Task.CompletedTask;
                        },
                        OnMessageReceived = context =>
                        {
                            return Task.CompletedTask;
                        }
                    };

                });

            services.AddControllersWithViews();

            //配置跨域处理，允许所有来源：
            services.AddCors(options =>
                options.AddPolicy("Any",
                p => p.AllowAnyOrigin().AllowAnyHeader())
            );

            //注册缓存
            services.AddMemoryCache();

            //配置接口文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MCS API",
                    Description = "MCS ASP.NET Core Web API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "MiZone",
                        Email = string.Empty,
                        Url = new System.Uri("https://github.com/MiZoneRom/MiZoneCommerce")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new System.Uri("https://github.com/MiZoneRom/MiZoneCommerce")
                    }
                });
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var xmlPath = Path.Combine(basePath, "MCS.Web.xml");
                c.IncludeXmlComments(xmlPath);
            });

            //注入全局异常捕获
            services.AddMvc(o =>
            {
                o.Filters.Add(typeof(BaseExceptions));
            });

            //实例化 AutoFac  容器   
            var builder = new ContainerBuilder();

            //MZcms.Service是继承接口的实现方法类库名称
            var assemblys = Assembly.Load("MCS.Service");

            //IService 是一个接口（所有要实现依赖注入的借口都要继承该接口）
            var baseType = typeof(IService);

            //注入所有类库下的接口
            builder.RegisterAssemblyTypes(assemblys)
                .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.Populate(services);

            ApplicationContainer = builder.Build();

            //第三方IOC接管 core内置DI容器
            return new AutofacServiceProvider(ApplicationContainer);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MCS API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
