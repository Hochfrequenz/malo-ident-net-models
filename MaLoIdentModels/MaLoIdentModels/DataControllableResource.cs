using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class DataControllableResource
{
    [JsonPropertyName("srId")]
    public string? SrId { get; set; }

    [JsonPropertyName("dataControllableResourceMeasuringPointOperators")]
    public List<SrMarketPartner>? DataControllableResourceMeasuringPointOperators { get; set; }
}
