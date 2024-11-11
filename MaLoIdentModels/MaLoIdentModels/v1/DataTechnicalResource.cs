using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

public class DataTechnicalResource
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("trId")]
    public string? TrId { get; set; }
}
