using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

/// <seealso cref="v2.NetworkLocation">v2 equivalent (NetworkLocation)</seealso>
public class DataNetworkLocation
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("neloId")]
    public string? NeloId { get; set; }

    [JsonPropertyName("dataNetworkLocationMeasuringPointOperators")]
    public List<NetworkLocationMeasuringPointOperator>? DataNetworkLocationMeasuringPointOperators { get; set; }
}
