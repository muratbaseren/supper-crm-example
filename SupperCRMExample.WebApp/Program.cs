using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SupperCRMExample.Services;

namespace SupperCRMExample.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            var scope = host.Services.CreateScope();

            var serviceProvider = scope.ServiceProvider;
            IMockService mockService = serviceProvider.GetRequiredService<IMockService>();
            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();

            string username = configuration.GetValue<string>("AppSettings:AdminUsername");
            string pass = configuration.GetValue<string>("AppSettings:AdminPassword");
            string name = configuration.GetValue<string>("AppSettings:AdminName");
            string email = configuration.GetValue<string>("AppSettings:AdminEmail");

            mockService.AddAdmin(email, name, username, pass);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
