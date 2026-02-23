namespace MaLoIdentModels.Validation;

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

/// <summary>
/// Validates that a decimal? value fits the EDI@Energy "percentLessHundred" constraints:
/// - Must be >= 0 and less than 100
/// - Must have at most 3 decimal places
/// Matches the anchored pattern ^\d{1,2}(\.\d{1,3})?$
/// </summary>
public class PercentLessHundredValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }

        if (value is not decimal decimalValue)
        {
            return new ValidationResult("Value must be a decimal.");
        }

        if (decimalValue < 0 || decimalValue >= 100)
        {
            return new ValidationResult(
                $"Value must be >= 0 and < 100 but was '{decimalValue.ToString(CultureInfo.InvariantCulture)}'."
            );
        }

        // Check at most 3 decimal places
        var scaled = decimalValue * 1000;
        if (scaled != Math.Floor(scaled))
        {
            return new ValidationResult(
                $"Value must have at most 3 decimal places but was '{decimalValue.ToString(CultureInfo.InvariantCulture)}'."
            );
        }

        return ValidationResult.Success;
    }
}
