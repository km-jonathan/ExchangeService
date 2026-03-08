using ExchangeService.Mapper;
using ExchangeService.Model;
using ExchangeService.Providers;

namespace ExchangeService.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IExchangeRateApiProvider _exchangeRateApiProvider;

        public ExchangeRateService(IExchangeRateApiProvider exchangeRateApiProvider)
        {
            _exchangeRateApiProvider = exchangeRateApiProvider;
        }

        public async Task<ExchangeRateResponse> GetExchangeRate(ExchangeRateRequest request)
        {
            var apiRequest = ExchangeRateMapper.GetExchangeRateApiRequest(request);
            var apiResponse = await _exchangeRateApiProvider.GetExchangeRate(apiRequest);

            var exchangeRateResponse = ExchangeRateMapper.GetExchangeRateResponse(apiResponse, request.Amount);

            return exchangeRateResponse;
        }
    }
}
