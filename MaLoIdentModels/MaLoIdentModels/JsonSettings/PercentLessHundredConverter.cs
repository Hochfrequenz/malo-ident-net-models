using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.JsonSettings;

/// <summary>
/// A JsonConverter that serializes decimal? to/from the EDI@Energy "percentLessHundred" string format.
/// The wire format is a string matching the pattern ^\d{1,2}(\.\d{1,3})?$.
/// We keep decimal? as the C# type for ergonomics and handle conversion transparently.
/// </summary>
public class PercentLessHundredConverter : JsonConverter<decimal?>
{
    public override decimal? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        var stringValue = reader.GetString();
        if (string.IsNullOrWhiteSpace(stringValue))
        {
            return null;
        }

        return decimal.Parse(stringValue, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        // Normalize: remove trailing zeros but keep at most 3 decimal places
        var rounded = Math.Round(value.Value, 3, MidpointRounding.AwayFromZero);
        if (rounded < 0 || rounded >= 100)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                rounded,
                "PercentLessHundred must be >= 0 and < 100."
            );
        }

        // G29 removes trailing zeros; we use InvariantCulture for '.' as decimal separator
        var stringValue = rounded.ToString("G29", CultureInfo.InvariantCulture);
        writer.WriteStringValue(stringValue);
    }
}
