using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public class DataMeterLocation
{
    [JsonPropertyName("meloId")]
    public string? MeloId { get; set; }

    [JsonPropertyName("meterNumber")]
    public string? MeterNumber { get; set; }

    [JsonPropertyName("dataMeterLocationMeasuringPointOperators")]
    public List<MeterLocationMeasuringPointOperator>? DataMeterLocationMeasuringPointOperators { get; set; }
}
