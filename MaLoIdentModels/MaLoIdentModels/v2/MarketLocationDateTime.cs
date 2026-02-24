using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v2;

public class MarketLocationDateTime
{
    [JsonIgnore]
    [Key]
    public Guid? Id { get; set; }

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
