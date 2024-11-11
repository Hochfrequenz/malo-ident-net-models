using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

public enum OptionalChangeForecastBasis
{
    [EnumMember(Value = "possible")]
    [JsonStringEnumMemberName("possible")]
    Possible,

    [EnumMember(Value = "notPossible")]
    [JsonStringEnumMemberName("notPossible")]
    NotPossible,
}
