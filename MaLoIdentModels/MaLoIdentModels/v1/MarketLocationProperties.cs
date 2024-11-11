using System;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v1;

public class MarketLocationProperties
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public Guid? Id { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonPropertyName("marketLocationProperty")]
    public MarketLocationProperty MarketLocationProperty { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}
