using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Dapper;
using Microsoft.OpenApi.Models;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using System.Security.Policy;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Autofac;
using MCS.Core;
using log4net;
using log4net.Config;
using log4net.Repository;
using MCS.Web.Middleware.WebSocket;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Senparc.CO2NET.Cache;
using Senparc.CO2NET.Utilities;
using Senparc.Weixin.MP;
using Senparc.Weixin.RegisterServices;
using Senparc.Weixin.WxOpen;
using Senparc.Weixin.Entities;
using Senparc.CO2NET;
using Senparc.CO2NET.AspNet;
using Senparc.Weixin;
using AutoMapper;
using MCS.Application.Mappers.Profiles;
using Microsoft.AspNetCore.Authentication.Cookies;
using MCS.AdminAPI;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MCS.Web
{
    public class Startup
    {
        //log4net日志
        public static ILoggerRepository Repository { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //加载log4net日志配置文件
            var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录 防止发布后找不到配置文件
            var xmlPath = Path.Combine(basePath, @"Config\log4net.config");//组合log4net配置文件
            Repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(Repository, new FileInfo(xmlPath));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddAuthentication(opts =>
            //{
            //    opts.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddPolicyScheme("MCS_Policy", "Bearer or Jwt", options =>
            //    {
            //        options.ForwardDefaultSelector = context =>
            //        {
            //            var bearerAuth = context.Request.Headers["Authorization"].FirstOrDefault()?.StartsWith("Bearer ") ?? false;
            //            // You could also check for the actual path here if that's your requirement:
            //            // eg: if (context.HttpContext.Request.Path.StartsWithSegments("/api", StringComparison.InvariantCulture))
            //            if (bearerAuth)
            //                return JwtBearerDefaults.AuthenticationScheme;
            //            else
            //                return CookieAuthenticationDefaults.AuthenticationScheme;
            //        };
            //    })
            //    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            //    {


            //    })
            //                    .AddJwtBearer(options =>
            //                    {
            //                        options.SaveToken = true;
            //                        var jwtSection = Configuration.GetSection("jwt");

            //                        options.TokenValidationParameters = new TokenValidationParameters
            //                        {
            //                            ValidateIssuer = true,//是否验证Issuer
            //                            ValidateAudience = true,//是否验证Audience
            //                            ValidateLifetime = true,//是否验证失效时间
            //                            ValidateIssuerSigningKey = true,//是否验证SecurityKey
            //                            ValidAudience = jwtSection.GetSection("ValidAudience").Value,//Audience
            //                            ValidIssuer = jwtSection.GetSection("ValidIssuer").Value,//Issuer，这两项和前面签发jwt的设置一致
            //                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.GetSection("SecurityKey").Value))//拿到SecurityKey
            //                        };

            //                        //认证事件
            //                        options.Events = new JwtBearerEvents
            //                        {
            //                            //认证过期添加过期消息
            //                            OnAuthenticationFailed = context =>
            //                            {
            //                                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            //                                {
            //                                    context.Response.Headers.Add("act", "expired");
            //                                }
            //                                return Task.CompletedTask;
            //                            },
            //                            OnMessageReceived = context =>
            //                            {
            //                                return Task.CompletedTask;
            //                            }
            //                        };
            //                    });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.Name = "MCS_Policy";
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromSeconds(10);
            //    options.LoginPath = "/Identity/Account/Login";
            //    options.LogoutPath = "/Identity/Account/Logout";
            //    options.Events = new CookieAuthenticationEvents()
            //    {
            //        OnRedirectToLogin = context =>
            //        {
            //            //这里区分当访问/api 如果cookie过期那么 不重定向到login登录界面
            //            if (context.Request.Path.Value.StartsWith("/api"))
            //            {
            //                context.Response.Clear();
            //                context.Response.StatusCode = 401;
            //                return Task.FromResult(0);
            //            }
            //            context.Response.Redirect(context.RedirectUri);
            //            return Task.FromResult(0);
            //        }
            //    };
            //});

            //添加jwt验证：
            services.AddAuthentication(opts =>
            {
                //opts.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddPolicyScheme("MCS_Policy", "Bearer or Jwt", options =>
                {
                    options.ForwardDefaultSelector = context =>
                    {
                        var bearerAuth = context.Request.Headers["Authorization"].FirstOrDefault()?.StartsWith("Bearer ") ?? false;
                        // You could also check for the actual path here if that's your requirement:
                        // eg: if (context.HttpContext.Request.Path.StartsWithSegments("/api", StringComparison.InvariantCulture))
                        if (bearerAuth)
                            return JwtBearerDefaults.AuthenticationScheme;
                        else
                            return CookieAuthenticationDefaults.AuthenticationScheme;
                    };
                })
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

                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

            //添加传统mvc认证
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            //注册session
            services.AddSession();

            //注册IO及缓存
            services.AddStrategies();

            //配置Controller全部由Autofac创建
            services.AddControllersWithViews().AddControllersAsServices().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); //序列化时key为驼峰样式
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;//忽略循环引用
            });

            //注册插件
            services.AddPlugins();

            //如果在IIS中搭建
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);

            services.AddSingleton<IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();

            services.AddRazorPages();

            //配置跨域处理，允许所有来源：
            services.AddCors(options =>
            {
                options.AddPolicy("CustomCorsPolicy", policy =>
                {
                    // 设定允许跨域的来源，有多个可以用','隔开
                    policy.WithOrigins(Configuration.GetSection("AllowedCorHosts").Value.Split('|'))
                    //policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "在下框中输入请求头中需要添加Jwt授权Token：Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                c.IncludeXmlComments(Path.Combine(basePath, "MCS.Web.xml"), true);
                c.IncludeXmlComments(Path.Combine(basePath, "MCS.AdminAPI.xml"), true);

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            //添加页面权限控制 控件权限控制
            services.AddAccessControlHelper()
                .AddResourceAccessStrategy<AdminPermissionAccessStrategy>()
                .AddControlAccessStrategy<AdminControlAccessStrategy>();

            //注入全局异常捕获
            services.AddMvc(o =>
            {
                o.Filters.Add(typeof(BaseExceptions));
            })
                .AddApplicationPart(typeof(BaseAdminAPIController).Assembly);//插件式开发

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //AutoMapper 自动转换Model
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<NavigationProfile>();
            });

            //SenparcWeixin 加入微信服务
            services.AddSenparcWeixinServices(Configuration);

        }

        /// <summary>
        /// 设置容器
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {

            Log.Debug("ConfigureContainer");

            //注册Autofac
            var assembly = typeof(AutoFacModule).Assembly;
            builder.RegisterAssemblyModules(assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHttpContextAccessor accessor, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {

            Log.Debug("Configure");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //静态文件
            app.UseStaticFiles();

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MCS API V1");
                c.RoutePrefix = "swagger";
            });

            //使用路由
            app.UseRouting();

            //使用策略
            app.UseStrategies();

            //使用插件
            app.UsePlugins();

            // 启动 CO2NET 全局注册，必须！
            var registerService = app.UseSenparcGlobal(env, senparcSetting.Value, globalRegister =>
            {

            }, true);

            //使用 Senparc.Weixin SDK
            registerService.UseSenparcWeixin(senparcWeixinSetting.Value, weixinRegister =>
            {
                //注册小程序
                weixinRegister.RegisterWxOpenAccount(senparcWeixinSetting.Value, "MCS_SmallProgram");
            });

            //启用跨越
            app.UseCors("CustomCorsPolicy");

            //使用认证中间件
            app.UseAuthentication();

            //使用授权中间件
            app.UseAuthorization();

            app.UseCookiePolicy();

            //如果不设置路由
            //app.UseWebSockets();
            //app.UseMiddleware<WebSocketService>();

            //设置到指定路由
            app.Map("/WebSocket", WebSocketService.Map);

            Core.HttpContextAccessor.Current = accessor;

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}",
                    defaults: new { area = "Web", controller = "Home", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "common",
                    pattern: "Common/{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
