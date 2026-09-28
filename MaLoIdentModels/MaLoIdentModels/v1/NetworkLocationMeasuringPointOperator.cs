using System;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v1;

/// <seealso cref="v2.NetworkLocationMeasuringPointOperator">v2 equivalent</seealso>
public class NetworkLocationMeasuringPointOperator
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
