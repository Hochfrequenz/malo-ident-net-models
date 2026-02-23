using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

public class NetworkLocation
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("identifierNetworkLocation")]
    public string? IdentifierNetworkLocation { get; set; }

    [JsonPropertyName("networkLocationMeasuringPointOperators")]
    public List<NetworkLocationMeasuringPointOperator>? NetworkLocationMeasuringPointOperators { get; set; }
}
