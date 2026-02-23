using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

public class MeterLocation
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("identifierMeterLocation")]
    public string? IdentifierMeterLocation { get; set; }

    [JsonPropertyName("meterNumber")]
    public string? MeterNumber { get; set; }

    [JsonPropertyName("meterLocationMeasuringPointOperators")]
    public List<MeterLocationMeasuringPointOperator>? MeterLocationMeasuringPointOperators { get; set; }
}
