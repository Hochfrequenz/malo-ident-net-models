using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

public class ControllableResource
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("identifierControllableRessource")]
    public string? IdentifierControllableResource { get; set; }

    [JsonPropertyName("controllableResourceMeasuringPointOperators")]
    public List<ControllableResourceMeasuringPointOperator>? ControllableResourceMeasuringPointOperators { get; set; }
}
