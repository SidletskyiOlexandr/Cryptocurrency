using Cryptocurrency.BLL.Interfaces;
using System.Windows;

namespace Cryptocurrency.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICryptocurrencyService _cryptocurrencyService;

        public MainWindow(ICryptocurrencyService cryptocurrencyService)
        {
            InitializeComponent();
            _cryptocurrencyService = cryptocurrencyService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = _cryptocurrencyService.GetTopCurrenciesAsync();
            MessageBox.Show(result);
        }
    }
}
