using Cryptocurrency.BLL.Interfaces;
using Cryptocurrency.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Cryptocurrency.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            services.AddScoped<ICryptocurrencyService, CryptocurrencyService>();
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create main window and inject service
            var mainWindow = new MainWindow(_serviceProvider.GetService<ICryptocurrencyService>());
            mainWindow.Show();
        }
    }
}
