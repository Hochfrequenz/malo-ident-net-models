using System.Collections.Generic;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;
using MaLoIdentModels.Validation;

namespace MaLoIdentModels.v2;

public class Tranche
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("identifierTranche")]
    public string? IdentifierTranche { get; set; }

    [JsonPropertyName("proportion")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Proportion Proportion { get; set; }

    [PercentLessHundredValidation]
    [JsonConverter(typeof(PercentLessHundredConverter))]
    [JsonPropertyName("percentLessHundred")]
    public decimal? PercentLessHundred { get; set; }

    [JsonPropertyName("trancheSuppliers")]
    public List<TrancheSupplier>? TrancheSuppliers { get; set; }
}
