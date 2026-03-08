using System.Text.Json.Serialization;

namespace ExchangeService.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CurrencyCode
    {
        AUD = 1,
        USD = 2
    }
}
