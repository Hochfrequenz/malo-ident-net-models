using System.Collections.Generic;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.IdentificationParameterIdentificationParameterAddress">v1 equivalent</seealso>
public class IdentificationParameterIdentificationParameterAddress
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("name")]
    public Name? Name { get; set; }

    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<LandParcel>))]
    [JsonPropertyName("landParcels")]
    public List<LandParcel>? LandParcels { get; set; }

    [JsonPropertyName("geographicCoordinates")]
    public GeographicCoordinates? GeographicCoordinates { get; set; }
}
