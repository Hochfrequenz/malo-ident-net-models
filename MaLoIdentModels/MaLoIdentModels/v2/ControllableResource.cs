using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.DataControllableResource">v1 equivalent (DataControllableResource)</seealso>
public class ControllableResource
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    /// <summary>
    /// The controllable resource identifier. Was <see cref="v1.DataControllableResource.SrId"/> in v1.
    /// The JSON name uses the spec's typo <c>identifierControllableRessource</c> (double 's') for wire compatibility.
    /// The C# property uses the correct English spelling.
    /// </summary>
    [JsonPropertyName("identifierControllableRessource")]
    public string? IdentifierControllableResource { get; set; }

    [JsonPropertyName("controllableResourceMeasuringPointOperators")]
    public List<ControllableResourceMeasuringPointOperator>? ControllableResourceMeasuringPointOperators { get; set; }
}
