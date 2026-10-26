using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.MarketLocationNetworkOperator">v1 equivalent</seealso>
public class MarketLocationNetworkOperator
{
    [JsonIgnore]
    [Key]
    public Guid? Id { get; set; }

    /// <summary>
    /// 13-digit market partner ID as string per v2 spec.
    /// Serialized as <c>identifierNetworkOperator</c> on the wire.
    /// </summary>
    [JsonPropertyName("identifierNetworkOperator")]
    [RegularExpression(@"^\d{13}$")]
    public string? MarketPartnerId { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}
