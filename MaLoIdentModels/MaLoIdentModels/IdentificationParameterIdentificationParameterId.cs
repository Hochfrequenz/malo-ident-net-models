using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class IdentificationParameterIdentificationParameterId
{
    [JsonPropertyName("maloId")]
    public string? MaloId { get; set; }

    [JsonPropertyName("tranchenIds")]
    public List<string>? TranchenIds { get; set; }

    [JsonPropertyName("meloIds")]
    public List<string>? MeloIds { get; set; }

    [JsonPropertyName("meterNumbers")]
    public List<string>? MeterNumbers { get; set; }

    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }
}
