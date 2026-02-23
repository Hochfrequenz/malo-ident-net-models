using AwesomeAssertions;
using MaLoIdentModels.v2;

namespace MaLoIdentModelsTests.v2Tests;

public class RoundTripTests
{
    [Fact]
    public void Test_Request()
    {
        var fileBody = File.ReadAllText("v2Tests/examples/request.json");
        var model = System.Text.Json.JsonSerializer.Deserialize<IdentificationParameter>(fileBody);
        model.Should().NotBeNull();
        model!.IdentificationDateTime.Offset.Should().Be(TimeSpan.Zero);
        var reSerialized = System.Text.Json.JsonSerializer.Serialize(model);
        Utilities.AssertJsonStringsAreEquivalent(fileBody, reSerialized);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<IdentificationParameter>(
            reSerialized
        );
        deserialized.Should().BeEquivalentTo(model);
    }

    [Fact]
    public void Test_Positive_Result()
    {
        var fileBody = File.ReadAllText("v2Tests/examples/result_positive.json");
        var model = System.Text.Json.JsonSerializer.Deserialize<ResultPositive>(fileBody);
        model.Should().NotBeNull();
        var reSerialized = System.Text.Json.JsonSerializer.Serialize(model);
        Utilities.AssertJsonStringsAreEquivalent(reSerialized, fileBody);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<ResultPositive>(
            reSerialized
        );
        deserialized.Should().BeEquivalentTo(model);
    }

    [Fact]
    public void Test_Negative_Result()
    {
        var fileBody = File.ReadAllText("v2Tests/examples/result_negative.json");
        var model = System.Text.Json.JsonSerializer.Deserialize<ResultNegative>(fileBody);
        model.Should().NotBeNull();
        var reSerialized = System.Text.Json.JsonSerializer.Serialize(model);
        Utilities.AssertJsonStringsAreEquivalent(reSerialized, fileBody);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<ResultNegative>(
            reSerialized
        );
        deserialized.Should().BeEquivalentTo(model);
    }

    [Fact]
    public void Test_README_Example()
    {
        var myNegativeResponse = new ResultNegative
        {
            DecisionTree = "E_0594",
            ResponseCode = "A10",
            Reason = "Ich bin ein Freitext.",
            IdentifierNetworkOperator = 9900987654321,
        };
        var myJson = System.Text.Json.JsonSerializer.Serialize(myNegativeResponse);
        Console.Out.WriteLine(myJson);
    }
}
