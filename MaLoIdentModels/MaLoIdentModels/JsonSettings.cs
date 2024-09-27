using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaLoIdentModels;

public static class JsonSettings
{
    public static JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions() { Converters = { new JsonStringEnumConverter() } };
    }
}
