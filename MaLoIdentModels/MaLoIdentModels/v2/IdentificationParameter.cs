using System;
using System.Text.Json.Serialization;
using MaLoIdentModels.JsonSettings;
using MaLoIdentModels.Validation;

namespace MaLoIdentModels.v2;

/// <seealso cref="v1.IdentificationParameter">v1 equivalent</seealso>
public class IdentificationParameter
{
    [JsonIgnore]
    [System.ComponentModel.DataAnnotations.Key]
    public Guid? Id { get; set; }

    /// <remarks>
    /// Has to be midnight in German local time.
    /// See Seite 6 von 111
    /// 1.1.2 SD: Ermittlung der MaLo-ID der Marktlokation
    /// https://www.bundesnetzagentur.de/DE/Beschlusskammern/1_GZ/BK6-GZ/2022/BK6-22-024/Beschluss/Anlage1b_GPKE_Teil2.pdf?__blob=publicationFile&amp;v=1
    /// </remarks>
    [GermanMidnightValidation]
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
