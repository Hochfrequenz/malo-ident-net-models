using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class IdentificationParameterIdentificationParameterAddress
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("name")]
    public Name? Name { get; set; }

    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    [JsonPropertyName("landParcels")]
    public List<LandParcel>? LandParcels { get; set; }

    [JsonPropertyName("geographicCoordinates")]
    public GeographicCoordinates? GeographicCoordinates { get; set; }
}
