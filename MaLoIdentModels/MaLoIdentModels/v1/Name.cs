using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v1;

public class Name
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<string>))]
    [JsonPropertyName("surnames")]
    public string? Surnames { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<string>))]
    [JsonPropertyName("firstnames")]
    public string? Firstnames { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<string>))]
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<string>))]
    [JsonPropertyName("company")]
    public string? Company { get; set; }
}
