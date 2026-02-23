using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

public class TechnicalResource
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("identifierTechnicalResource")]
    public string? IdentifierTechnicalResource { get; set; }
}
