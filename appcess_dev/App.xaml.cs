using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using appcess_dev.Services;
using appcess_dev.Services.Interfaces;
using appcess_dev.Services.Implementations;
using appcess_dev.Services.Utilities;

namespace appcess_dev
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public static ConfigurationService ConfigurationService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigurationService = new ConfigurationService();
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            LogService.LogInfo("Application started.");
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            MainWindow = new MainWindow();
            MainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IErrorHandler, WpfErrorHandler>();
            services.AddTransient<FileSystemUtilities>();

            //add other services and ViewModel
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            LogService.LogInfo("Application exited.");
            LogManager.Shutdown();
        }

        private void App_DispatcherUnhandledException (object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            LogService.LogError(e.Exception, "Unhandled exception");

            var errorHandler = ServiceProvider.GetService<IErrorHandler>();
            errorHandler?.ShowErrorMessage("An unexpected error occurred. Please check the log file for details.\n\nError: {e.Exception.Message}");
            
            e.Handled = true;
        }
    }
}
