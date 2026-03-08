using ExchangeService.Configuration;
using ExchangeService.Model;
using Microsoft.Extensions.Options;
using System.Text.Json;
using static ExchangeService.Constants;

namespace ExchangeService.Providers
{
    public class ExchangeRateApiProvider : IExchangeRateApiProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ExchangeRateApiConfig _exchangeRateApiConfig;

        public ExchangeRateApiProvider(IHttpClientFactory httpClientFactory, IOptions<ExchangeRateApiConfig> exchangeRateApiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _exchangeRateApiConfig = exchangeRateApiConfig.Value;
        }

        public async Task<ExchangeRateApiResponse> GetExchangeRate(ExchangeRateApiRequest request)
        {
            var url = $"{_exchangeRateApiConfig.BaseUrl}/{_exchangeRateApiConfig.ApiKey}/pair/{request.InputCurrency}/{request.OutputCurrency}/{request.Amount}";

            var httpClient = _httpClientFactory.CreateClient();

            var apiResponse = await httpClient.GetAsync(url);

            var json = await apiResponse.Content.ReadAsStringAsync();

            var apiResult = JsonSerializer.Deserialize<ExchangeRateApiResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (apiResult == null)
            {
                throw new Exception("Failed to get exchange rate from API - apiResult is null");
            }

            if (apiResult.Result == ExchangeRateApiResult.Error)
            {
                throw new Exception($"Error when calling ExchangeRateApi: {apiResult.ErrorType}");
            }

            if (apiResult.Result != ExchangeRateApiResult.Success)
            {
                throw new Exception($"Unexpected result from ExchangeRateApi: {apiResult.Result}");
            }

            return apiResult;
        }
    }
}
