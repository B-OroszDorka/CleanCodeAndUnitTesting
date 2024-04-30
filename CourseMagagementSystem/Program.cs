using CourseMagagementSystem.Abstractions.Clients;
using CourseMagagementSystem.Abstractions.Repository;
using CourseMagagementSystem.Abstractions.Services;
using CourseMagagementSystem.Clients;
using CourseMagagementSystem.HostedService;
using CourseMagagementSystem.Repository;
using CourseMagagementSystem.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace CourseMagagementSystem
{
    internal class Program
    {
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
           .ConfigureAppConfiguration((hostingContext, configuration) =>
           {
               configuration.Sources.Clear();

               configuration                   
                   .AddUserSecrets<Program>(optional: true, reloadOnChange: true);

               configuration.Build();
           })
           .ConfigureServices((_, services) =>
           {
               services.AddSingleton<IDbClient, DbClient>()
                   .AddSingleton<IFinancialApiClient, FinancialApiClient>()
                   .AddSingleton<INotificationClient, PushNotificationClient>()
                   .AddSingleton<INotificationClient, EmailClient>()
                   .AddSingleton<INotificationService, NotificationService>()
                   .AddSingleton<ICourseService, CourseService>()
                   .AddSingleton<IPaymentService, PaymentService>()
                   .AddSingleton<ICourseRepository, CourseRepository>()
                   .AddLogging(loggingBuilder =>
                   {
                       loggingBuilder.ClearProviders();
                       loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                       loggingBuilder.AddNLog();
                   })
                   .AddHostedService<ProcessHandler>();
           });
        }
        private static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var serviceProvider = host.Services;
            host.Run();
        }
    }
}
