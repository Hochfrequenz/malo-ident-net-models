using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

public enum Proportion
{
    [EnumMember(Value = "bilateralAgreement")]
    [JsonStringEnumMemberName("bilateralAgreement")]
    BilateralAgreement,

    [EnumMember(Value = "percent")]
    [JsonStringEnumMemberName("percent")]
    Percent,
}
