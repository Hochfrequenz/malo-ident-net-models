using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class LandParcel
{
    [JsonPropertyName("districtName")]
    public string? DistrictName { get; set; }

    [JsonPropertyName("lotNumber")]
    public string? LotNumber { get; set; }

    [JsonPropertyName("subLotNumber")]
    public string? SubLotNumber { get; set; }
}
