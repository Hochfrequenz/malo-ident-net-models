using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

public class DataMeterLocation
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    [JsonPropertyName("meloId")]
    public string? MeloId { get; set; }

    [JsonPropertyName("meterNumber")]
    public string? MeterNumber { get; set; }

    [JsonPropertyName("dataMeterLocationMeasuringPointOperators")]
    public List<MeterLocationMeasuringPointOperator>? DataMeterLocationMeasuringPointOperators { get; set; }
}
