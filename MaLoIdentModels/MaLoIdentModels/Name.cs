using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class Name
{
    [JsonPropertyName("surnames")]
    public string? Surnames { get; set; }

    [JsonPropertyName("firstnames")]
    public string? Firstnames { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("company")]
    public string? Company { get; set; }
}
