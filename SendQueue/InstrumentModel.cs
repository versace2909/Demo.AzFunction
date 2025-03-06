using System.Text.Json.Serialization;

namespace SendQueue;

public class InstrumentModel
{
    [JsonPropertyName("marketCode")]
    public string MarketCode { get; set; } = string.Empty;

    [JsonPropertyName("productCode")]
    public string ProductCode { get; set; } = string.Empty;

    [JsonPropertyName("productPeriodCode")]
    public string ProductPeriodCode { get; set; } = string.Empty;

    [JsonPropertyName("datePeriod")]
    public string DatePeriod { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"MarketCode: {MarketCode}, ProductCode: {ProductCode}, ProductPeriodCode: {ProductPeriodCode}";
    }
}