using Cryptocurrency.BLL.Interfaces;

namespace Cryptocurrency.BLL.Services
{
    public class CryptocurrencyService: ICryptocurrencyService
    {
        private readonly IHttpService _httpService;

        public CryptocurrencyService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public string GetTopCurrenciesAsync()
        {
            return "bla bla bla";
        }
    }
}
