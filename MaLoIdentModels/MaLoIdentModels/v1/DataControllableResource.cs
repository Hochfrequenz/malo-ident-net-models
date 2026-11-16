using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

/// <seealso cref="v2.ControllableResource">v2 equivalent (ControllableResource)</seealso>
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
