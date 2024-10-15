using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class DataTechnicalResource
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("trId")]
    public string? TrId { get; set; }
}
