using ExchangeService.Enums;

namespace ExchangeService.Model
{
    public class ExchangeRateApiRequest
    {
        public CurrencyCode InputCurrency { get; set; }
        public CurrencyCode OutputCurrency { get; set; }
        public decimal Amount { get; set; }
    }
}
