using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

public enum MarketLocationProperty
{
    [EnumMember(Value = "customerFacility")]
    CustomerFacility,

    [EnumMember(Value = "nonActive")]
    [JsonStringEnumMemberName("nonActive")]
    NonActive,

    [EnumMember(Value = "standard")]
    [JsonStringEnumMemberName("standard")]
    Standard,
}
