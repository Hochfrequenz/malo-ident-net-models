using System;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

/// <seealso cref="v2.TrancheSupplier">v2 equivalent</seealso>
public class TrancheSupplier
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public Guid? Id { get; set; }

    [JsonPropertyName("marketPartnerId")]
    public long MarketPartnerId { get; set; }

    [JsonPropertyName("executionTimeFrom")]
    public DateTime ExecutionTimeFrom { get; set; }

    [JsonPropertyName("executionTimeUntil")]
    public DateTime? ExecutionTimeUntil { get; set; }
}
