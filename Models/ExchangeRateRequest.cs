using ExchangeService.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExchangeService.Model
{
    public class ExchangeRateRequest
    {
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
        [Required]
        public CurrencyCode InputCurrency { get; set; }
        [Required]
        public CurrencyCode OutputCurrency { get; set; }
    }
}
