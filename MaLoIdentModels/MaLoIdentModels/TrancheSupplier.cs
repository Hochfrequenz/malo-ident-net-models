using System;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class TrancheSupplier
{
    [JsonPropertyName("marketPartnerId")]
    public long MarketPartnerId { get; set; }

    [JsonPropertyName("executionTimeFrom")]
    public DateTime ExecutionTimeFrom { get; set; }

    [JsonPropertyName("executionTimeUntil")]
    public DateTime? ExecutionTimeUntil { get; set; }
}
