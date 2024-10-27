using System;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MaLoIdentModels.JsonSettings;

/// <summary>
/// helper methods for handling strings that represent datetimes
/// </summary>
internal static class DateTimeOffsetStringExtensionMethods
{
    private const string FormatWithoutMilliseconds = "yyyy-MM-ddTHH:mm:ssK";
    private const string FormatWithMilliseconds = "yyyy-MM-ddTHH:mm:ss.fffK";
    private const string FormatWithMicroseconds = "yyyy-MM-ddTHH:mm:ss.ffffffK";

    private static readonly string[] SupportedFormats =
    [
        FormatWithoutMilliseconds,
        FormatWithMilliseconds,
        FormatWithMicroseconds,
    ];

    /// <summary>
    /// simple regex to check if a string ends with something that looks like a timezone or UTC offset.
    /// </summary>
    /// <remarks>
    /// Note that this isn't super strict, e.g. '+17:99' would also pass, but that's fine,
    /// because the actual parsing happens with regular DateTime parsing.
    /// </remarks>
    private static readonly Regex EndsWithOffsetPattern = new(
        @"^.+[\+\-]\d{1,2}:\d{2}$"
    );

    /// <summary>
    /// converts the given <paramref name="dtoString"/> to an datetimeoffset
    /// </summary>
    /// <param name="dtoString"></param>
    /// <returns></returns>
    /// <exception cref="JsonException">if no explicit offset is specified in <paramref name="dtoString"/></exception>
    internal static DateTimeOffset ToDateTimeOffset(this string dtoString)
    {
        if (!(dtoString.EndsWith("Z") || EndsWithOffsetPattern.Match(dtoString).Success))
        {
            throw new JsonException(
                $"DateTimeOffset value must have an explicit offset, like 'Z' or '+/-HH:mm' but '{dtoString}' doesn't"
            );
        }

        if (
            !DateTimeOffset.TryParseExact(
                dtoString,
                SupportedFormats,
                null,
                DateTimeStyles.None,
                out var result
            )
        )
        {
            throw new JsonException(
                $"DateTimeOffset value must match any of the supported formats: {string.Join(", ", SupportedFormats)}, but '{dtoString}' doesn't"
            );
        }

        return new DateTimeOffset(result.UtcDateTime);
    }
}
