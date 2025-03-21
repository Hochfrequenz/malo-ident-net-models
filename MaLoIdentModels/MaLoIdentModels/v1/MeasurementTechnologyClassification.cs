using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

public enum MeasurementTechnologyClassification
{
    [EnumMember(Value = "intelligentMeasuringSystem")]
    [JsonStringEnumMemberName("intelligentMeasuringSystem")]
    IntelligentMeasuringSystem,

    [EnumMember(Value = "conventionalMeasuringSystem")]
    [JsonStringEnumMemberName("conventionalMeasuringSystem")]
    ConventionalMeasuringSystem,

    [EnumMember(Value = "noMeasurement")]
    [JsonStringEnumMemberName("noMeasurement")]
    NoMeasurement,
}
