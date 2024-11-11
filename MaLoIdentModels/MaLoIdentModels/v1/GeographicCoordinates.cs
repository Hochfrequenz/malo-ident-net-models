using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

public class GeographicCoordinates
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

    [JsonPropertyName("east")]
    public string? East { get; set; }

    [JsonPropertyName("north")]
    public string? North { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [JsonPropertyName("zone")]
    public Zone? Zone { get; set; }

    [JsonPropertyName("northing")]
    public string? Northing { get; set; }

    [JsonPropertyName("easting")]
    public string? Easting { get; set; }
}
