using ExchangeService.Enums;

namespace ExchangeService.Model
{
    public class ExchangeRateResponse
    {
        public decimal Amount { get; set; }
        public CurrencyCode InputCurrency { get; set; }
        public CurrencyCode OutputCurrency { get; set; }
        public decimal Value { get; set; }
    }
}
