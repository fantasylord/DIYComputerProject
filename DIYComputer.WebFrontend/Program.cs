using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DIYComputer.WebFrontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>

            WebHost.CreateDefaultBuilder(args)
             .UseUrls("http://*:5555", "http://*:5556")
            .UseKestrel()//kestrel 解决默认绑定IP地址与端口问题 
                .UseStartup<Startup>();
    }
}
