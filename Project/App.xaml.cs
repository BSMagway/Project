using Microsoft.Extensions.DependencyInjection;
using Project.Services.Implementation;
using Project.Services.Interface;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
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
            services.AddScoped<IWorkWithBD, WorkWithBD>();

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
