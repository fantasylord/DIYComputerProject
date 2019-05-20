using AutoMapper;
using DIYComputer.Config.ServiceConfig;
using DIYComputer.Entity.ComputerWareEntity;
using DIYComputer.Entity.DBContext;
using DIYComputer.Repository;
using DIYComputer.Repository.IRepository;
using DIYComputer.WebBackend.MiddleWare.CookieAuth;
using DIYComputer.WebBackend.MiddleWare.MyMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using System.IO;
using System.Linq;
using UEditorNetCore;

namespace DIYComputer.WebBackend
{
    public class Startup
    {

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
            ServiceConfig.Set(Env.WebRootPath);
            ServiceConfig.ClientServices = Configuration["APIServices:Address"];

        }
        public const string CookieScheme = "DIYGroup";

        public IHostingEnvironment Env { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


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
            //仓储工厂注入
            services.AddScoped<ICGRepositor<Case>, CGRepositor<Case>>();
            services.AddScoped<ICGRepositor<CDROM>, CGRepositor<CDROM>>();
            services.AddScoped<ICGRepositor<CPU>, CGRepositor<CPU>>();
            services.AddScoped<ICGRepositor<CPUHS>, CGRepositor<CPUHS>>();
            services.AddScoped<ICGRepositor<Display>, CGRepositor<Display>>();
            services.AddScoped<ICGRepositor<Graphyic>, CGRepositor<Graphyic>>();
            services.AddScoped<ICGRepositor<HardDisk>, CGRepositor<HardDisk>>();
            services.AddScoped<ICGRepositor<Mainboard>, CGRepositor<Mainboard>>();
            services.AddScoped<ICGRepositor<NetWork>, CGRepositor<NetWork>>();
            services.AddScoped<ICGRepositor<Power>, CGRepositor<Power>>();
            services.AddScoped<ICGRepositor<ROM>, CGRepositor<ROM>>();
            services.AddScoped<ICGRepositor<SSD>, CGRepositor<SSD>>();

            //文件上传服务注册
            //services.AddSingleton<IFileProvider>(
            //    new PhysicalFileProvider((ServiceConfig.ImageUpDirectory))
            //    );

            //AuthServer
            //AutoMapper 注入
            services.AddAutoMapper();
            //添加验证方式
            services.AddAuthentication(CookieScheme)
                .AddCookie(CookieScheme, o => {
                    o.AccessDeniedPath = "/Shared/Error";
                    o.LoginPath = "/login";
                });
            services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, ConfigureMyCookie>();
            //授权身份添加
            services.AddAuthorization(o =>
            {

                o.AddPolicy("System", policy => policy.RequireClaim("SystemType").Build());//policy 策略
                o.AddPolicy("Client", policy => policy.RequireClaim("ClientType").Build());//policy 策略
                o.AddPolicy("Admin", policy => policy.RequireClaim("AdminType").Build());//policy 策略
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //MVC

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
            //验证码生成

            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddRazorPagesOptions(o =>
            {

                //o.Conventions.AuthorizeFolder("/Views");
                //o.Conventions.AllowAnonymousToPage("/Views/Admins/Login");
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EFDBContext context,ILoggerFactory loggerFactory)
        {

            loggerFactory.AddNLog();
            app.UseDeveloperExceptionPage();
            //if (env.IsDevelopment())
            //{
            //    //开发环境异常处理

            //}
            //else
            //{
            //    //生产环境异常处理
            //    app.UseExceptionHandler("/Shared/Error");
            // //   app.UseHsts();
            //}

            //跨域使用
            app.UseCors("AllowAllOrigin");
            //app.UseHttpsRedirection();
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
            app.UseCookiePolicy();

            app.UseStatusCodePages();

            context.EnsureSeedDataForContext();//执行种子数据填充.

            Mymapper.RegisterMappings();//注册mapper
            app.UseAuthentication();

            // app.UseMiddleware<TokenAuth>();//启用授权 中间管道


            // app.UseMiddleware<MyProfile>();
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");

            });
        }
    }
}
