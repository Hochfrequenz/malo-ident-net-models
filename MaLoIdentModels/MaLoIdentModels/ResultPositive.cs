using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class ResultPositive
{
    [JsonIgnore]
    [Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("dataMarketLocation")]
    public DataMarketLocation? DataMarketLocation { get; set; }

    [JsonPropertyName("dataTranches")]
    public List<DataTranche>? DataTranches { get; set; }

    [JsonPropertyName("dataMeterLocations")]
    public List<DataMeterLocation>? DataMeterLocations { get; set; }

    [JsonPropertyName("dataTechnicalResources")]
    public List<DataTechnicalResource>? DataTechnicalResources { get; set; }

    [JsonPropertyName("dataControllableResources")]
    public List<DataControllableResource>? DataControllableResources { get; set; }

    [JsonPropertyName("dataNetworkLocations")]
    public List<DataNetworkLocation>? DataNetworkLocations { get; set; }
}
