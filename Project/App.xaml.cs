using Microsoft.Extensions.DependencyInjection;
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
        //private static IServiceProvider? serviceProvider;

        //public static IServiceProvider ServiceProvider => serviceProvider ??= InitializeServices().BuildServiceProvider();
        //private static IServiceCollection? InitializeServices()
        //{
        //    var services = new ServiceCollection();

        //    services.AddSingleton<MainWindowViewModel>();

        //    return services;
        //}

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    MainWindow mainWindow = new MainWindow();
        //    mainWindow.DataContext = ServiceProvider.GetService<MainWindowViewModel>();
        //}
    }
}
