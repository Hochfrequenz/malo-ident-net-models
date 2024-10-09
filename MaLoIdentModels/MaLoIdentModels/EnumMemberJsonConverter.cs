namespace MaLoIdentModels;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

public class EnumMemberJsonConverter<T> : JsonConverter<T> where T : struct, Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var enumText = reader.GetString();

        // Find the enum member with matching EnumMember attribute value
        foreach (var field in typeof(T).GetFields())
        {
            if (field.GetCustomAttribute<EnumMemberAttribute>()?.Value == enumText)
            {
                return (T)field.GetValue(null);
            }
        }

        // Fallback to parsing the string if no EnumMember attribute is found
        if (Enum.TryParse(enumText, ignoreCase: true, out T value))
        {
            return value;
        }

        throw new JsonException($"Unable to convert \"{enumText}\" to enum \"{typeof(T)}\"");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        // Get the EnumMember attribute value, if present
        var enumMemberAttribute = typeof(T)
            .GetField(value.ToString())
            ?.GetCustomAttribute<EnumMemberAttribute>();

        if (enumMemberAttribute != null)
        {
            writer.WriteStringValue(enumMemberAttribute.Value);
        }
        else
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
