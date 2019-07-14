using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using EventBriteAssignment3A.Data;
using Microsoft.Extensions.DependencyInjection;

namespace EventBriteCatalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                var context = services.GetRequiredService<CatalogContext>();
                CatalogSeed.Seed(context);
                }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
    //
}


