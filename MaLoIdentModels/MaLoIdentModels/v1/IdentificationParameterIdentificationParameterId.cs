using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModels.v1;

public class IdentificationParameterIdentificationParameterId
{
    [JsonIgnore]
    [Key]
    public System.Guid? Id { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("maloId")]
    public string? MaloId { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<string>))]
    [JsonPropertyName("tranchenIds")]
    public List<string>? TranchenIds { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<string>))]
    [JsonPropertyName("meloIds")]
    public List<string>? MeloIds { get; set; }

    [JsonConverter(typeof(EmptyListToNullConverter<string>))]
    [JsonPropertyName("meterNumbers")]
    public List<string>? MeterNumbers { get; set; }

    [JsonConverter(typeof(EmptyStringConverter))]
    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }
}
