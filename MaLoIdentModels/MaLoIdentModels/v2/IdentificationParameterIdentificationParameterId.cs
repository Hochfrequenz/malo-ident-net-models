using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v2;

public class IdentificationParameterIdentificationParameterId
{
    [JsonIgnore]
    [Key]
    public System.Guid? Id { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("identifierMarketLocation")]
    public string? IdentifierMarketLocation { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<string>))]
    [JsonPropertyName("identifierMarketTranches")]
    public List<string>? IdentifierMarketTranches { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<string>))]
    [JsonPropertyName("identifierMeterLocations")]
    public List<string>? IdentifierMeterLocations { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<string>))]
    [JsonPropertyName("meterNumbers")]
    public List<string>? MeterNumbers { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }
}
