using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.DataMeterLocation">v1 equivalent (DataMeterLocation)</seealso>
public class MeterLocation
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public System.Guid? Id { get; set; }

    /// <summary>
    /// The meter location identifier. Was <see cref="v1.DataMeterLocation.MeloId"/> in v1.
    /// </summary>
    [JsonPropertyName("identifierMeterLocation")]
    public string? IdentifierMeterLocation { get; set; }

    [JsonPropertyName("meterNumber")]
    public string? MeterNumber { get; set; }

    [JsonPropertyName("meterLocationMeasuringPointOperators")]
    public List<MeterLocationMeasuringPointOperator>? MeterLocationMeasuringPointOperators { get; set; }
}
