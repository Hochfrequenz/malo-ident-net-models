using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v1;

public class GeographicCoordinates
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }
    
    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("east")]
    public string? East { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("north")]
    public string? North { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonPropertyName("zone")]
    public Zone? Zone { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("northing")]
    public string? Northing { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("easting")]
    public string? Easting { get; set; }
}
