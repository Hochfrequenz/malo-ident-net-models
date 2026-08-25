using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

/// <seealso cref="v2.Tranche">v2 equivalent (Tranche)</seealso>
public class DataTranche
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("tranchenId")]
    public string? TranchenId { get; set; }

    [JsonPropertyName("proportion")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Proportion Proportion { get; set; }

    [JsonPropertyName("percent")]
    public decimal? Percent { get; set; }

    [JsonPropertyName("dataTrancheSuppliers")]
    public List<TrancheSupplier>? DataTrancheSuppliers { get; set; }
}
