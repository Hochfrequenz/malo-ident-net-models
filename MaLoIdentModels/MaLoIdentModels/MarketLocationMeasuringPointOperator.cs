using System;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

using JsonSettings;

public class MarketLocationMeasuringPointOperator
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public Guid? Id { get; set; }

    [JsonPropertyName("marketPartnerId")]
    public long MarketPartnerId { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}
