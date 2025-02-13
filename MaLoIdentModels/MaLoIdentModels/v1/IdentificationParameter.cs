using System;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v1;

public class IdentificationParameter
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public Guid? Id { get; set; }

    [JsonConverter(typeof(DateTimeOffsetWithTrailingZConverter))]
    [JsonPropertyName("identificationDateTime")]
    public DateTimeOffset IdentificationDateTime { get; set; }

    [JsonPropertyName("energyDirection")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EnergyDirection EnergyDirection { get; set; }

    [JsonPropertyName("identificationParameterId")]
    public IdentificationParameterIdentificationParameterId? IdentificationParameterId { get; set; }

    [JsonPropertyName("identificationParameterAddress")]
    public IdentificationParameterIdentificationParameterAddress? IdentificationParameterAddress { get; set; }
}
