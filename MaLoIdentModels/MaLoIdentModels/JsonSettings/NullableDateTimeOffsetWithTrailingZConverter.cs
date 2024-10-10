using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.JsonSettings;

/// <summary>
/// Similar to <see cref="JsonSettings.DateTimeOffsetWithTrailingZConverter"/> but for nullable DateTimeOffsets.
/// </summary>
public class NullableDateTimeOffsetWithTrailingZConverter : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        // Handle deserialization: if the value is null, return null
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        // Parse the input string to a DateTimeOffset
        return DateTimeOffset.Parse(reader.GetString()!);
    }

    public override void Write(
        Utf8JsonWriter writer,
        DateTimeOffset? value,
        JsonSerializerOptions options
    )
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ssZ"));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
