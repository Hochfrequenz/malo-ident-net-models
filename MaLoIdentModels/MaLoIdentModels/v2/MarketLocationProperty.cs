using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v2;

public enum MarketLocationProperty
{
    [EnumMember(Value = "customerFacility")]
    [JsonStringEnumMemberName("customerFacility")]
    CustomerFacility,

    [EnumMember(Value = "nonActive")]
    [JsonStringEnumMemberName("nonActive")]
    NonActive,

    [EnumMember(Value = "standard")]
    [JsonStringEnumMemberName("standard")]
    Standard,
}
