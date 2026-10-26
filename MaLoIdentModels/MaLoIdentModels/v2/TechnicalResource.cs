using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.DataTechnicalResource">v1 equivalent (DataTechnicalResource)</seealso>
public class TechnicalResource
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    /// <summary>
    /// The technical resource identifier. Was <see cref="v1.DataTechnicalResource.TrId"/> in v1.
    /// </summary>
    [JsonPropertyName("identifierTechnicalResource")]
    public string? IdentifierTechnicalResource { get; set; }
}
