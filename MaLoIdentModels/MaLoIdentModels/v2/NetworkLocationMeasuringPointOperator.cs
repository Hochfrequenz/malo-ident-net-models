using System;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.NetworkLocationMeasuringPointOperator">v1 equivalent</seealso>
public class NetworkLocationMeasuringPointOperator
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public Guid? Id { get; set; }

    /// <summary>
    /// The 13-digit market partner ID. Serialized as <c>identifierMeasuringPointOperator</c> on the wire.
    /// The spec uses <c>string</c> with pattern <c>^\d{13}$</c>, but we keep <c>long</c> for type safety.
    /// </summary>
    [JsonPropertyName("identifierMeasuringPointOperator")]
    public long MarketPartnerId { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}
