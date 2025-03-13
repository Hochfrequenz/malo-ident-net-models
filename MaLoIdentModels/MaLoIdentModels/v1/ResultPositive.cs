using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v1;

public class ResultPositive
{
    [JsonIgnore]
    [Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("dataMarketLocation")]
    public DataMarketLocation? DataMarketLocation { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<DataTranche>))]
    [JsonPropertyName("dataTranches")]
    public List<DataTranche>? DataTranches { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<DataMeterLocation>))]
    [JsonPropertyName("dataMeterLocations")]
    public List<DataMeterLocation>? DataMeterLocations { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<DataTechnicalResource>))]
    [JsonPropertyName("dataTechnicalResources")]
    public List<DataTechnicalResource>? DataTechnicalResources { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<DataControllableResource>))]
    [JsonPropertyName("dataControllableResources")]
    public List<DataControllableResource>? DataControllableResources { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<DataNetworkLocation>))]
    [JsonPropertyName("dataNetworkLocations")]
    public List<DataNetworkLocation>? DataNetworkLocations { get; set; }
}
