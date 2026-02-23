using System.ComponentModel.DataAnnotations;
using AwesomeAssertions;
using MaLoIdentModels.Validation;

namespace MaLoIdentModelsTests.v2Tests;

public class PercentLessHundredValidationTests
{
    private class ModelWithPercent
    {
        [PercentLessHundredValidation]
        public decimal? Percent { get; set; }
    }

    [Theory]
    [InlineData(0)]
    [InlineData(50)]
    [InlineData(75.912)]
    [InlineData(99.999)]
    [InlineData(99)]
    [InlineData(0.1)]
    [InlineData(0.001)]
    public void Valid_Percentages_Pass_Validation(decimal value)
    {
        var model = new ModelWithPercent { Percent = value };
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);
        isValid.Should().BeTrue();
    }

    [Fact]
    public void Null_Passes_Validation()
    {
        var model = new ModelWithPercent { Percent = null };
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);
        isValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(100)]
    [InlineData(100.001)]
    [InlineData(-1)]
    [InlineData(-0.001)]
    [InlineData(999)]
    public void Invalid_Percentages_Fail_Validation(decimal value)
    {
        var model = new ModelWithPercent { Percent = value };
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);
        isValid.Should().BeFalse();
    }

    [Theory]
    [InlineData(99.9999)]
    [InlineData(0.0001)]
    [InlineData(50.12345)]
    public void Too_Many_Decimal_Places_Fail_Validation(decimal value)
    {
        var model = new ModelWithPercent { Percent = value };
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);
        isValid.Should().BeFalse();
    }
}
