using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class DataTechnicalResource
{
    [JsonPropertyName("trId")]
    public string? TrId { get; set; }
}
