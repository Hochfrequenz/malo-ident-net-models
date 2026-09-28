using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.DataNetworkLocation">v1 equivalent (DataNetworkLocation)</seealso>
public class NetworkLocation
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    /// <summary>
    /// The network location identifier. Was <see cref="v1.DataNetworkLocation.NeloId"/> in v1.
    /// </summary>
    [JsonPropertyName("identifierNetworkLocation")]
    public string? IdentifierNetworkLocation { get; set; }

    [JsonPropertyName("networkLocationMeasuringPointOperators")]
    public List<NetworkLocationMeasuringPointOperator>? NetworkLocationMeasuringPointOperators { get; set; }
}
