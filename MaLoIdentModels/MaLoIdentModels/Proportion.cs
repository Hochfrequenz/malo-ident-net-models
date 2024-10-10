using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public enum Proportion
{
    [EnumMember(Value = "bilateralAgreement")]
    BilateralAgreement,

    [EnumMember(Value = "percent")]
    [JsonStringEnumMemberName("percent")]
    Percent,
}
