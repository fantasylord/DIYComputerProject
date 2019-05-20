using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DIYComputer.Config.FrontEndConfig;
using DIYComputer.Entity.DBContext;
using DIYComputer.Service.VierificationCodeService;
using DIYComputer.WebBackend.MiddleWare.MyMapper;
using DIYComputer.WebFrontend.MiddleWare.CookitAuth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using UEditorNetCore;

namespace DIYComputer.WebFrontend
{
    public class Startup
    {

        public IHostingEnvironment Env { get; }

        public IConfiguration Configuration { get; }
        public const string CookieScheme = "DIYGroup";

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
            ServiceConfig.Set(Env.WebRootPath);
            ServiceConfig.APIServices = Configuration["APIServices:Address"];

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //添加动态API接口地址
            ServiceConfig.APIServices = Configuration["APIServices:Address"];

            //ueditor注册
            //第一个参数为配置文件路径，默认为项目目录下config.json
            //第二个参数为是否缓存配置文件，默认false　　
            services.AddUEditorService();

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            string constr = "Database=diycom; server=127.0.0.1; uid=root;SslMode=0;Character Set=utf8 ; Charset=utf8;pwd=fantasy;pooling=true;port=3306";
            constr = Configuration["ConnectionString:OnWebConnection"];
            services.AddDbContext<EFDBContext>(options =>
            {
                options.UseMySQL(constr);
            });

            ////令牌缓存
            //services.AddSingleton<IMemoryCache>(factory =>
            //{
            //    return MyNetCoreMemoryCache._cache;
            //});

            //AutoMapper 注入
            services.AddAutoMapper();

            //验证方式添加
            services.AddAuthentication(CookieScheme)
              .AddCookie(CookieScheme, o => {
                  o.AccessDeniedPath = "/Shared/Error";
                  o.LoginPath = "/login";
              });
            //授权身份添加
            services.AddAuthorization(o =>
            {

                o.AddPolicy("System", policy => policy.RequireClaim("SystemType").Build());//policy 策略
                o.AddPolicy("Client", policy => policy.RequireClaim("ClientType").Build());//policy 策略
                o.AddPolicy("User", policy => policy.RequireClaim("UserType").Build());//policy 策略
                o.AddPolicy("Admin", policy => policy.RequireClaim("AdminType").Build());//policy 策略
            });
            ///添加全局HTTPCONTEXT
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, ConfigureMyCookie>();

            //跨域
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();

                });
            });
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAllOrigin"));
            });

            //验证码生成;
            services.AddSingleton<VierificationCodeServices>();
            //MVC
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddRazorPagesOptions(o =>
                {

                    //o.Conventions.AuthorizeFolder("/Views");
                    //o.Conventions.AllowAnonymousToPage("/Views/Admins/Login");
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {

            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseCors("AllowAllOrigin");
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(ServiceConfig.wwwrootDirectory, "upload")),
                RequestPath = "/upload",
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=36000");
                }
            });
            app.UseStaticFiles();
            app.UseSpaStaticFiles(new StaticFileOptions
            {
                RequestPath = "/node_modules",
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
            });
            // app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseStatusCodePages();
            Mymapper.RegisterMappings();
            //  app.UseMiddleware<TokenAuth>();//启用授权 中间管道
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
