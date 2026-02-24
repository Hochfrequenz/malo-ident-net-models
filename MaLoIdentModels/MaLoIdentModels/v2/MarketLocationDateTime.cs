using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.MarketLocationDateTime">v1 equivalent</seealso>
public class MarketLocationDateTime
{
    [JsonIgnore]
    [Key]
    public Guid? Id { get; set; }

    /// <summary>
    /// Was <see cref="v1.MarketLocationDateTime.MaloId"/> in v1.
    /// </summary>
    [JsonPropertyName("identifierMarketLocation")]
    [RegularExpression(@"\d{11}")]
    public string? IdentifierMarketLocation { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeFrom")]
    public DateTimeOffset ExecutionTimeFrom { get; set; }

    [JsonConverter(typeof(NullableDateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("executionTimeUntil")]
    public DateTimeOffset? ExecutionTimeUntil { get; set; }
}
