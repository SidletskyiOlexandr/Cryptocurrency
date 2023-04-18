
using Cryptocurrency.DAL.DTOs;

namespace Cryptocurrency.BLL.Interfaces
{
    public interface ICryptocurrencyService
    {
        Task<TrendingCurrencyDto> GetTopCurrenciesAsync();
    }
}
