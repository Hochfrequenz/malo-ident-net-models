using System;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class NetworkLocationMeasuringPointOperator
{
    [JsonPropertyName("marketPartnerId")]
    public long MarketPartnerId { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}
