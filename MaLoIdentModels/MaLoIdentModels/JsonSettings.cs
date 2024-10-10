namespace MaLoIdentModels;

using System.Text.Json;
using System.Text.Json.Serialization;

public static class JsonSettings
{
    public static JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions() { Converters = { new JsonStringEnumConverter() } };
    }
}
