using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

public class Name
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("surnames")]
    public string? Surnames { get; set; }

    [JsonPropertyName("firstnames")]
    public string? Firstnames { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("company")]
    public string? Company { get; set; }
}
