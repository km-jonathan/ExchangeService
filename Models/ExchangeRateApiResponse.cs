using ExchangeService.Enums;
using System.Text.Json.Serialization;

namespace ExchangeService.Model
{
    public class ExchangeRateApiResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;

        [JsonPropertyName("base_code")]
        public CurrencyCode BaseCode { get; set; }

        [JsonPropertyName("target_code")]
        public CurrencyCode TargetCode { get; set; }

        [JsonPropertyName("conversion_rate")]
        public decimal ConversionRate { get; set; }

        [JsonPropertyName("conversion_result")]
        public decimal ConversionResult { get; set; }

        [JsonPropertyName("error-type")]
        public string ErrorType { get; set; } = string.Empty;
    }
}
