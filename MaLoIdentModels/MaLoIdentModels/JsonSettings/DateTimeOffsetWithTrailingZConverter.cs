using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.JsonSettings;

/// <summary>
/// A JsonConverter that ensures, that we serialize DateTimeOffsets with the "Z" suffix as required by Edi@Enery.
/// A plain '+00:00' is not sufficient.
/// For DE-serializing this converter is more lenient: It allows the use of any explicit UTC offset and supports optional milli and microseconds.
/// </summary>
public class DateTimeOffsetWithTrailingZConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var dateTimeString = reader.GetString()!;
        return dateTimeString.ToDateTimeOffset();
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
