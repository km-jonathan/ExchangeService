using ExchangeService.Enums;
using ExchangeService.Model;

namespace ExchangeService.Mapper
{
    public static class ExchangeRateMapper
    {
        public static ExchangeRateApiRequest GetExchangeRateApiRequest(ExchangeRateRequest exchangeRateRequest)
        {
            // Assumption: input and output currency codes are valid and can be parsed to the CurrencyCode enum
            // Improvements: handle invalid currency codes

            return new ExchangeRateApiRequest
            {
                InputCurrency = exchangeRateRequest.InputCurrency,
                OutputCurrency = exchangeRateRequest.OutputCurrency,
                Amount = exchangeRateRequest.Amount
            };
        }

        public static ExchangeRateResponse GetExchangeRateResponse(ExchangeRateApiResponse exchangeRateApiResponse, decimal amount)
        {
            return new ExchangeRateResponse
            {
                InputCurrency = exchangeRateApiResponse.BaseCode,
                OutputCurrency = exchangeRateApiResponse.TargetCode,
                Amount = amount,
                Value = Decimal.Round(exchangeRateApiResponse.ConversionResult, 2)
            };
        }
    }
}
