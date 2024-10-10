using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class DataNetworkLocation
{
    [JsonPropertyName("neloId")]
    public string? NeloId { get; set; }

    [JsonPropertyName("dataNetworkLocationMeasuringPointOperators")]
    public List<NetworkLocationMeasuringPointOperator>? DataNetworkLocationMeasuringPointOperators { get; set; }
}
