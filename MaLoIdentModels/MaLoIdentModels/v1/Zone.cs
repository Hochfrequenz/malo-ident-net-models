using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.v1;

public enum Zone
{
    [EnumMember(Value = "UTMZone31")]
    [JsonStringEnumMemberName("UTMZone31")]
    UTMZone31,

    [EnumMember(Value = "UTMZone32")]
    [JsonStringEnumMemberName("UTMZone32")]
    UTMZone32,

    [EnumMember(Value = "UTMZone33")]
    [JsonStringEnumMemberName("UTMZone33")]
    UTMZone33,
}
