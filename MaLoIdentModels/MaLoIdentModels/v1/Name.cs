using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v1;

public class Name
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("surnames")]
    public string? Surnames { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("firstnames")]
    public string? Firstnames { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("company")]
    public string? Company { get; set; }
}
