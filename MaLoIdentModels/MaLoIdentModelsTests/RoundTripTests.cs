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
        var settings = MaLoIdentModels.JsonSettings.GetJsonSerializerOptions();
        var fileBody = System.IO.File.ReadAllText("examples/request.json");
        var model = System.Text.Json.JsonSerializer.Deserialize<IdentificationParameter>(fileBody);
        model.Should().NotBeNull();
        var reSererialized = System.Text.Json.JsonSerializer.Serialize(model);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<IdentificationParameter>(reSererialized);
        deserialized.Should().BeEquivalentTo(model);        
    }
    
    [Fact]
    public void Test_Positive_Result()
    {
        var settings = MaLoIdentModels.JsonSettings.GetJsonSerializerOptions();
        var fileBody = System.IO.File.ReadAllText("examples/result_positive.json");
        var model = System.Text.Json.JsonSerializer.Deserialize<ResultPositive>(fileBody, settings);
        model.Should().NotBeNull();
        var reSererialized = System.Text.Json.JsonSerializer.Serialize(model, settings);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<ResultPositive>(reSererialized, settings);
        deserialized.Should().BeEquivalentTo(model);        
    }
    [Fact]
    public void Test_Positive_Negative()
    {
        var settings = MaLoIdentModels.JsonSettings.GetJsonSerializerOptions();
        var fileBody = System.IO.File.ReadAllText("examples/result_negative.json");
        var model = System.Text.Json.JsonSerializer.Deserialize<ResultNegative>(fileBody, settings);
        model.Should().NotBeNull();
        var reSererialized = System.Text.Json.JsonSerializer.Serialize(model, settings);
        var deserialized = System.Text.Json.JsonSerializer.Deserialize<ResultNegative>(reSererialized, settings);
        deserialized.Should().BeEquivalentTo(model);        
    }
}