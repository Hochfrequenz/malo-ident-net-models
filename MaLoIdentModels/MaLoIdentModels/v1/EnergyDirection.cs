using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

public enum EnergyDirection
{
    [EnumMember(Value = "consumption")]
    [JsonStringEnumMemberName("consumption")]
    Consumption,

    [EnumMember(Value = "production")]
    [JsonStringEnumMemberName("production")]
    Production,
}
