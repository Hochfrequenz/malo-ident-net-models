using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using AwesomeAssertions;
using MaLoIdentModels.v2;

namespace MaLoIdentModelsTests.v2Tests;

public class DateTimeOffsetDeserializationTests
{
    [Theory]
    [InlineData("2023-08-02T22:00:00")]
    [InlineData("2023-08-02T22:00:00+17:99")]
    public void Deserializing_An_DatetimeOffset_Without_Explicit_Offset_Throws_JsonException(
        string invalidDateTimeOffsetString
    )
    {
        var fileBody = File.ReadAllText("v2Tests/examples/request.json");
        fileBody
            .Should()
            .Contain(
                "\"2023-08-02T22:00:00Z\"",
                because: "The original example data use trailing 'Z' to indicate UTC offset 0"
            );
        var requestJsonWithoutExplicitUtcOffset = fileBody.Replace(
            "\"2023-08-02T22:00:00Z\"",
            $"\"{invalidDateTimeOffsetString}\""
        );
        var deserializing = () =>
            JsonSerializer.Deserialize<IdentificationParameter>(
                requestJsonWithoutExplicitUtcOffset
            );
        deserializing.Should().Throw<JsonException>();
    }

    [Theory]
    [InlineData("2023-08-02T22:00:00Z")]
    [InlineData("2023-08-02T22:00:00+00:00")]
    [InlineData("2023-08-03T00:00:00+02:00")]
    [InlineData("2023-08-02T20:00:00-02:00")]
    [InlineData("2023-08-03T00:00:00.000+02:00")]
    [InlineData("2023-08-03T00:00:00.000000+02:00")]
    public void Deserializing_An_DatetimeOffset_With_Explicit_Offset_Works(
        string dateTimeOffsetString
    )
    {
        var fileBody = File.ReadAllText("v2Tests/examples/request.json");
        fileBody
            .Should()
            .Contain(
                "\"2023-08-02T22:00:00Z\"",
                because: "The original example data use trailing 'Z' to indicate UTC offset 0"
            );
        var requestJsonWithoutExplicitUtcOffset = fileBody.Replace(
            "\"2023-08-02T22:00:00Z\"",
            $"\"{dateTimeOffsetString}\""
        );
        var deserializing = () =>
            JsonSerializer.Deserialize<IdentificationParameter>(
                requestJsonWithoutExplicitUtcOffset
            );
        deserializing
            .Should()
            .NotThrow<JsonException>()
            .And.Subject.Invoke()
            .IdentificationDateTime.Should()
            .Be(new DateTimeOffset(2023, 8, 2, 22, 0, 0, 0, TimeSpan.Zero));
    }

    [Theory]
    [InlineData("2025-01-01T00:00:00Z", false)]
    [InlineData("2024-12-31T23:00:00Z", true)]
    [InlineData("2025-06-30T22:00:00Z", true)]
    [InlineData("2025-06-30T23:00:00Z", false)]
    public void Validation_Of_German_Midnight_Works(
        string dateTimeOffsetString,
        bool isValidExpected
    )
    {
        var parameter = new IdentificationParameter
        {
            IdentificationDateTime = DateTimeOffset.Parse(dateTimeOffsetString),
        };
        var context = new ValidationContext(parameter);
        var results = new List<ValidationResult>();
        var isValidActual = Validator.TryValidateObject(parameter, context, results, true);
        isValidActual.Should().Be(isValidExpected);
    }

    [Fact]
    public void Serialization_Strips_SubSecond_Precision()
    {
        var fileBody = File.ReadAllText("v2Tests/examples/request.json");
        var identificationParameter = JsonSerializer.Deserialize<IdentificationParameter>(fileBody);
        identificationParameter.Should().NotBeNull();
        while (
            identificationParameter.IdentificationDateTime.Ticks == 0
            || identificationParameter.IdentificationDateTime.Microsecond == 0
        )
        {
            identificationParameter.IdentificationDateTime = DateTimeOffset.UtcNow;
        }

        identificationParameter.IdentificationDateTime.Ticks.Should().NotBe(0);
        identificationParameter.IdentificationDateTime.Microsecond.Should().NotBe(0);
        var serialized = JsonSerializer.Serialize(identificationParameter);
        var strippedIdentificationDateTime = new DateTimeOffset(
            identificationParameter.IdentificationDateTime.Year,
            identificationParameter.IdentificationDateTime.Month,
            identificationParameter.IdentificationDateTime.Day,
            identificationParameter.IdentificationDateTime.Hour,
            identificationParameter.IdentificationDateTime.Minute,
            identificationParameter.IdentificationDateTime.Second,
            TimeSpan.Zero
        );
        var strippedIdentificationDateTimeString = strippedIdentificationDateTime.ToString(
            "yyyy-MM-ddTHH:mm:ssZ"
        );
        serialized.Should().Contain(strippedIdentificationDateTimeString);
    }
}
