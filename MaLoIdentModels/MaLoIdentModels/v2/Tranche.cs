using System.Collections.Generic;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;
using MaLoIdentModels.Validation;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.DataTranche">v1 equivalent (DataTranche)</seealso>
public class Tranche
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    /// <summary>
    /// The tranche identifier. Was <see cref="v1.DataTranche.TranchenId"/> in v1.
    /// </summary>
    [JsonPropertyName("identifierTranche")]
    public string? IdentifierTranche { get; set; }

    [JsonPropertyName("proportion")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Proportion Proportion { get; set; }

    /// <summary>
    /// The tranche percentage. Was <see cref="v1.DataTranche.Percent"/> in v1.
    /// v2 uses a string wire format; the <see cref="PercentLessHundredConverter"/> handles conversion transparently.
    /// </summary>
    [PercentLessHundredValidation]
    [JsonConverter(typeof(PercentLessHundredConverter))]
    [JsonPropertyName("percentLessHundred")]
    public decimal? PercentLessHundred { get; set; }

    [JsonPropertyName("trancheSuppliers")]
    public List<TrancheSupplier>? TrancheSuppliers { get; set; }
}
