using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;

namespace Serilog04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .UseSerilog((hostingContect, loggerConfiguration) => loggerConfiguration
                .MinimumLevel.Warning()
                .MinimumLevel.Override("Serilog04", Serilog.Events.LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", Serilog.Events.LogEventLevel.Warning)
                .ReadFrom.Configuration(hostingContect.Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Assembly", typeof(Program).Assembly.GetName().Name)
                .WriteTo.Console(new CompactJsonFormatter())
            );
    }
}
