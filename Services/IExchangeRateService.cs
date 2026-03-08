using ExchangeService.Model;

namespace ExchangeService.Services
{
    public interface IExchangeRateService
    {
        Task<ExchangeRateResponse> GetExchangeRate(ExchangeRateRequest request);
    }
}
