using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace B進階觀念.Dapper範例
{
    public class DapperWebApiEx
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}