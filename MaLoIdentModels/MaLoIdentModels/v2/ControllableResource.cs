using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

public class ControllableResource
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    /// <summary>
    /// The controllable resource identifier. The JSON name uses the spec's typo
    /// <c>identifierControllableRessource</c> (double 's') for wire compatibility.
    /// The C# property uses the correct English spelling.
    /// </summary>
    [JsonPropertyName("identifierControllableRessource")]
    public string? IdentifierControllableResource { get; set; }

    [JsonPropertyName("controllableResourceMeasuringPointOperators")]
    public List<ControllableResourceMeasuringPointOperator>? ControllableResourceMeasuringPointOperators { get; set; }
}
