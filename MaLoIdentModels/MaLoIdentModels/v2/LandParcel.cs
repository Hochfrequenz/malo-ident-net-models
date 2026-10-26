using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v2;

public class LandParcel
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("districtName")]
    public string? DistrictName { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("lotNumber")]
    public string? LotNumber { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("subLotNumber")]
    public string? SubLotNumber { get; set; }
}
