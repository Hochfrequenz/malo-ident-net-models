namespace MaLoIdentModels.Validation;

using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// an attribute that checks that a datetimeoffset is 00:00 Uhr in German local time
/// </summary>
public class GermanMidnightValidationAttribute : ValidationAttribute
{
    public const string GermanTimeZoneSerializedAsString =
        "Central Europe Standard Time;60;(UTC+01:00) Belgrad, Bratislava (Pressburg), Budapest, Ljubljana, Prag (Praha);Mitteleuropäische Zeit ;Mitteleuropäische Sommerzeit ;[01:01:0001;12:31:9999;60;[0;02:00:00;3;5;0;];[0;03:00:00;10;5;0;];];";

    private static TimeZoneInfo GermanTimeZoneInfo =>
        TimeZoneInfo.FromSerializedString(GermanTimeZoneSerializedAsString);

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTimeOffset dto)
        {
            return new ValidationResult("Invalid datetime format.");
        }

        var germanLocalTime = TimeZoneInfo.ConvertTime(dto, GermanTimeZoneInfo);

        if (germanLocalTime.Hour != 0 || germanLocalTime.Minute != 0 || germanLocalTime.Second != 0)
        {
            return new ValidationResult(
                $"The date must be at 00:00 (midnight) German time but was '{dto:o}'."
            );
        }
        return ValidationResult.Success;
    }
}
