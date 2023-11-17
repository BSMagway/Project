using Microsoft.Extensions.DependencyInjection;
using NLog;
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

            services.AddSingleton<MainWindowViewModel>();

            services.AddScoped(typeof(IWorkWithBDGeneric<>), typeof(WorkWithBDGenericService<>));
            services.AddTransient<IAuthInterface, AuthService>();

            return services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "${basedir}/logs/${shortdate}.log"};
        
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
          
            LogManager.Configuration = config;

            MainWindow mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
