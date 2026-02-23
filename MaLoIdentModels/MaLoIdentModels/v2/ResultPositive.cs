using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v2;

public class ResultPositive
{
    [JsonIgnore]
    [Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("marketLocation")]
    public MarketLocation? MarketLocation { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<Tranche>))]
    [JsonPropertyName("tranches")]
    public List<Tranche>? Tranches { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<MeterLocation>))]
    [JsonPropertyName("meterLocations")]
    public List<MeterLocation>? MeterLocations { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<TechnicalResource>))]
    [JsonPropertyName("technicalResources")]
    public List<TechnicalResource>? TechnicalResources { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<ControllableResource>))]
    [JsonPropertyName("controllableResources")]
    public List<ControllableResource>? ControllableResources { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<NetworkLocation>))]
    [JsonPropertyName("networkLocations")]
    public List<NetworkLocation>? NetworkLocations { get; set; }
}
