using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.JsonSettings;

/// <summary>
/// A JsonConverter that ensures, that we serialize DateTimeOffsets with the "Z" suffix as required by Edi@Enery.
/// A plain '+00:00' is not sufficient.
/// </summary>
public class DateTimeOffsetWithTrailingZConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return DateTimeOffset.Parse(reader.GetString()!);
    }

    public override void Write(
        Utf8JsonWriter writer,
        DateTimeOffset value,
        JsonSerializerOptions options
    )
    {
        // Always convert the DateTimeOffset to UTC and use the "Z" suffix
        writer.WriteStringValue(value.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ssZ"));
    }
}
