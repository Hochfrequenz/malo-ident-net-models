using System.Text.Json;
using System.Text.Json.Serialization;
using AwesomeAssertions;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModelsTests.v2Tests;

public class PercentLessHundredConverterTests
{
    private class ModelWithPercent
    {
        [JsonConverter(typeof(PercentLessHundredConverter))]
        [JsonPropertyName("percent")]
        public decimal? Percent { get; set; }
    }

    [Theory]
    [InlineData(75.912, "\"75.912\"")]
    [InlineData(0, "\"0\"")]
    [InlineData(50.1, "\"50.1\"")]
    [InlineData(99.999, "\"99.999\"")]
    [InlineData(1, "\"1\"")]
    public void Serializes_Decimal_To_String(decimal input, string expectedJsonValue)
    {
        var model = new ModelWithPercent { Percent = input };
        var json = JsonSerializer.Serialize(model);
        json.Should().Contain($"\"percent\":{expectedJsonValue}");
    }

    [Fact]
    public void Serializes_Null_To_Null()
    {
        var model = new ModelWithPercent { Percent = null };
        var json = JsonSerializer.Serialize(model);
        json.Should().Contain("\"percent\":null");
    }

    [Theory]
    [InlineData("\"75.912\"", 75.912)]
    [InlineData("\"0\"", 0)]
    [InlineData("\"50.1\"", 50.1)]
    [InlineData("\"99.999\"", 99.999)]
    public void Deserializes_String_To_Decimal(string jsonValue, decimal expected)
    {
        var json = $"{{\"percent\":{jsonValue}}}";
        var model = JsonSerializer.Deserialize<ModelWithPercent>(json);
        model.Should().NotBeNull();
        model!.Percent.Should().Be(expected);
    }

    [Fact]
    public void Deserializes_Null_To_Null()
    {
        var json = "{\"percent\":null}";
        var model = JsonSerializer.Deserialize<ModelWithPercent>(json);
        model.Should().NotBeNull();
        model!.Percent.Should().BeNull();
    }

    [Theory]
    [InlineData(75.912, "75.912")]
    [InlineData(75.9, "75.9")]
    [InlineData(75.91, "75.91")]
    [InlineData(0, "0")]
    [InlineData(99.999, "99.999")]
    public void Roundtrip_Preserves_Value(decimal input, string expectedStringInJson)
    {
        var model = new ModelWithPercent { Percent = input };
        var json = JsonSerializer.Serialize(model);
        json.Should().Contain($"\"{expectedStringInJson}\"");
        var deserialized = JsonSerializer.Deserialize<ModelWithPercent>(json);
        deserialized!.Percent.Should().Be(input);
    }

    [Fact]
    public void Deserializes_Empty_String_To_Null()
    {
        var json = "{\"percent\":\"\"}";
        var model = JsonSerializer.Deserialize<ModelWithPercent>(json);
        model.Should().NotBeNull();
        model!.Percent.Should().BeNull();
    }

    [Fact]
    public void Deserializes_Whitespace_String_To_Null()
    {
        var json = "{\"percent\":\"  \"}";
        var model = JsonSerializer.Deserialize<ModelWithPercent>(json);
        model.Should().NotBeNull();
        model!.Percent.Should().BeNull();
    }

    [Theory]
    [InlineData("\"0.0\"", 0.0)]
    [InlineData("\"00\"", 0)]
    [InlineData("\"0.100\"", 0.100)]
    public void Deserializes_Non_Canonical_Strings(string jsonValue, decimal expected)
    {
        var json = $"{{\"percent\":{jsonValue}}}";
        var model = JsonSerializer.Deserialize<ModelWithPercent>(json);
        model.Should().NotBeNull();
        model!.Percent.Should().Be(expected);
    }

    [Theory]
    [InlineData(100)]
    [InlineData(100.001)]
    [InlineData(999)]
    public void Serialize_Throws_On_Value_Gte_100(decimal value)
    {
        var model = new ModelWithPercent { Percent = value };
        var serializing = () => JsonSerializer.Serialize(model);
        serializing.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Serialize_Throws_On_Negative_Value()
    {
        var model = new ModelWithPercent { Percent = -1m };
        var serializing = () => JsonSerializer.Serialize(model);
        serializing.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Serialize_Rounds_To_Three_Decimal_Places()
    {
        // 99.9999 rounds to 100.000 which should throw
        var model = new ModelWithPercent { Percent = 99.9999m };
        var serializing = () => JsonSerializer.Serialize(model);
        serializing.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Serialize_Value_That_Rounds_Down_Stays_Valid()
    {
        // 99.9994 rounds to 99.999 which is valid
        var model = new ModelWithPercent { Percent = 99.9994m };
        var json = JsonSerializer.Serialize(model);
        json.Should().Contain("\"99.999\"");
    }
}
