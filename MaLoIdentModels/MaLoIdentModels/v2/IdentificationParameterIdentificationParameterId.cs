using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.IdentificationParameterIdentificationParameterId">v1 equivalent</seealso>
public class IdentificationParameterIdentificationParameterId
{
    [JsonIgnore]
    [Key]
    public System.Guid? Id { get; set; }

    /// <summary>
    /// Was <see cref="v1.IdentificationParameterIdentificationParameterId.MaloId"/> in v1.
    /// </summary>
    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("identifierMarketLocation")]
    public string? IdentifierMarketLocation { get; set; }

    /// <summary>
    /// Was <see cref="v1.IdentificationParameterIdentificationParameterId.TranchenIds"/> in v1.
    /// </summary>
    [JsonConverter(typeof(EmptyListToNullConverter<string>))]
    [JsonPropertyName("identifierMarketTranches")]
    public List<string>? IdentifierMarketTranches { get; set; }

    /// <summary>
    /// Was <see cref="v1.IdentificationParameterIdentificationParameterId.MeloIds"/> in v1.
    /// </summary>
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
