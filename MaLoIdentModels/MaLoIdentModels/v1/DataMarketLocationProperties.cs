using System;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v1;

public class DataMarketLocationProperties
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public Guid? Id { get; set; }

    [JsonPropertyName("marketLocationProperty")]
    public MarketLocationProperty MarketLocationProperty { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}
