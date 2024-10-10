using System;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels;

public class IdentificationParameter
{
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
