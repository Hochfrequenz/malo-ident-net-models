using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class DataTranche
{
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
