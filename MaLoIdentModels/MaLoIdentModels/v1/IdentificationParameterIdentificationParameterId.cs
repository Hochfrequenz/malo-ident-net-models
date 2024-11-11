using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

public class IdentificationParameterIdentificationParameterId
{
    [JsonIgnore]
    [Key]
    public System.Guid? Id { get; set; }

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
