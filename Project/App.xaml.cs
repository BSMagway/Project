using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using Project.Interfaces.Services;
using Project.Services;
using Project.ViewModels;
using System;
using System.Windows;

namespace Project
{
    public partial class App : Application
    {
        private static IServiceProvider? serviceProvider;

        public static IServiceProvider ServiceProvider => serviceProvider ??= InitializeServices().BuildServiceProvider();
        private static IServiceCollection? InitializeServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            });

            services.AddSingleton<MainWindowViewModel>().AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddNLog(serviceProvider =>
                {
                    var config = serviceProvider.GetService(typeof(IConfiguration)) as IConfiguration;
                    var filename = "NLog.config";
                    return LogManager.Setup().LoadConfigurationFromFile(filename).LogFactory;
                });
            });

            services.AddScoped(typeof(IWorkWithBDGeneric<>), typeof(WorkWithBDGenericService<>));
            services.AddTransient<IAuthInterface, AuthService>();

            return services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            MainWindow mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
