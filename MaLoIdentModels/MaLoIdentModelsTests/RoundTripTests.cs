using FluentAssertions;
using MaLoIdentModels;

namespace MaLoIdentModelsTests;

/// <summary>
/// test serialization and deserialization roundtrips
/// </summary>
public class RoundTripTests
{
    [Fact]
    public void Test_Request()
    {
        var fileBody = File.ReadAllText("examples/request.json");
        var model = System.Text.Json.JsonSerializer.Deserialize<IdentificationParameter>(fileBody);
        model.Should().NotBeNull();
        var reSererialized = System.Text.Json.JsonSerializer.Serialize(model);
        Utilities.AssertJsonStringsAreEquivalent(fileBody, reSererialized);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<IdentificationParameter>(
            reSererialized
        );
        deserialized.Should().BeEquivalentTo(model);
    }

    [Fact]
    public void Test_Positive_Result()
    {
        var settings = JsonSettings.GetJsonSerializerOptions();
        var fileBody = File.ReadAllText("examples/result_positive.json");
        var model = System.Text.Json.JsonSerializer.Deserialize<ResultPositive>(fileBody, settings);
        model.Should().NotBeNull();
        var reSererialized = System.Text.Json.JsonSerializer.Serialize(model, settings);
        Utilities.AssertJsonStringsAreEquivalent(reSererialized, fileBody);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<ResultPositive>(
            reSererialized,
            settings
        );
        deserialized.Should().BeEquivalentTo(model);
    }

    [Fact]
    public void Test_Positive_Negative()
    {
        var settings = JsonSettings.GetJsonSerializerOptions();
        var fileBody = File.ReadAllText("examples/result_negative.json");
        var model = System.Text.Json.JsonSerializer.Deserialize<ResultNegative>(fileBody, settings);
        model.Should().NotBeNull();
        var reSererialized = System.Text.Json.JsonSerializer.Serialize(model, settings);
        Utilities.AssertJsonStringsAreEquivalent(reSererialized, fileBody);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<ResultNegative>(
            reSererialized,
            settings
        );
        deserialized.Should().BeEquivalentTo(model);
    }

    [Fact]
    public void Test_README_Example()
    {
        var myNegativeResponse = new ResultNegative()
        {
            DecisionTree = "E_0594",
            ResponseCode = "A10",
            Reason = "Ich bin ein Freitext.",
            NetworkOperator = 9900987654321,
        };
        var myJson = System.Text.Json.JsonSerializer.Serialize(myNegativeResponse);
        Console.Out.WriteLine(myJson);
    }
}
