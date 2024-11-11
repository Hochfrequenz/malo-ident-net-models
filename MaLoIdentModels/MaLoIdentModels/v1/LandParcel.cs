using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

public class LandParcel
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("districtName")]
    public string? DistrictName { get; set; }

    [JsonPropertyName("lotNumber")]
    public string? LotNumber { get; set; }

    [JsonPropertyName("subLotNumber")]
    public string? SubLotNumber { get; set; }
}
