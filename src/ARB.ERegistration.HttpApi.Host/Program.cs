using System;
using System.Reflection;
using ARB.ERegistration.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace ARB.ERegistration
{
    public class Program
    {
        public static int Main(string[] args)
        {
            //            Log.Logger = new LoggerConfiguration()
            //#if DEBUG
            //                            .MinimumLevel.Debug()
            //#else
            //                            .MinimumLevel.Information()
            //#endif
            //                            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //                .Enrich.FromLogContext()
            //                .WriteTo.Async(c => c.File("Logs/logs.txt"))
            //                .CreateLogger();




            //configure logging first for direct connection to elastic search
            ElasticLoggingExtension.ConfigureLogging();

            try
            {
                Log.Information("Starting ARB.ERegistration.HttpApi.Host.");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseAutofac()
                .UseSerilog();


        
    }
}
