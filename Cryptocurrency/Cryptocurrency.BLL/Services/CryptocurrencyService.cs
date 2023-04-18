using Cryptocurrency.BLL.Interfaces;
using Cryptocurrency.DAL.DTOs;

namespace Cryptocurrency.BLL.Services
{
    public class CryptocurrencyService: ICryptocurrencyService
    {
        private readonly IHttpService _httpService;

        public CryptocurrencyService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<TrendingCurrencyDto> GetTopCurrenciesAsync()
        {
            return await _httpService.Get<TrendingCurrencyDto>("https://api.coingecko.com/api/v3/search/trending");
        }
    }
}
