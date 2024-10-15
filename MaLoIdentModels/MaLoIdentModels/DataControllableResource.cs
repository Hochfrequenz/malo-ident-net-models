using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class DataControllableResource
{
    [JsonIgnore]
    [Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("srId")]
    public string? SrId { get; set; }

    [JsonPropertyName("dataControllableResourceMeasuringPointOperators")]
    public List<SrMarketPartner>? DataControllableResourceMeasuringPointOperators { get; set; }
}
