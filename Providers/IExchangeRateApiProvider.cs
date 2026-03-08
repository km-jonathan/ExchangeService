using ExchangeService.Model;

namespace ExchangeService.Providers
{
    public interface IExchangeRateApiProvider
    {
        Task<ExchangeRateApiResponse> GetExchangeRate(ExchangeRateApiRequest exchangeRateApiRequest);
    }
}
