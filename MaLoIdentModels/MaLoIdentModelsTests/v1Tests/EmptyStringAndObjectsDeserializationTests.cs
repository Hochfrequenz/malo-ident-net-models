using System.Text.Json;
using FluentAssertions;
using MaLoIdentModels.v1;

namespace MaLoIdentModelsTests.v1Tests;

public class EmptyStringAndObjectsDeserializationTests
{
    [Fact]
    public void Deserializing_An_DatetimeOffset_Without_Explicit_Offset_Throws_JsonException()
    {
        var fileBody = File.ReadAllText("v1Tests/examples/request_empty_string.json");
        fileBody
            .Should()
            .Contain(
                "\"\"",
                because: "In the testdata an empty string is used to represent a missing value"
            );
        var deserializing = () => JsonSerializer.Deserialize<IdentificationParameter>(fileBody);
        var deserializedModel = deserializing();
        deserializedModel.Should().NotBeNull();
        deserializedModel.IdentificationParameterAddress.Should().NotBeNull();
        deserializedModel.IdentificationParameterAddress.GeographicCoordinates.Should().NotBeNull();
        deserializedModel
            .IdentificationParameterAddress.GeographicCoordinates.Easting.Should()
            .BeNull();
        deserializedModel
            .IdentificationParameterAddress.GeographicCoordinates.Northing.Should()
            .BeNull();
        deserializedModel
            .IdentificationParameterAddress.GeographicCoordinates.East.Should()
            .BeNull();
        deserializedModel
            .IdentificationParameterAddress.GeographicCoordinates.North.Should()
            .BeNull();
        deserializedModel.IdentificationParameterAddress.LandParcels.Should().BeNull();
    }
}
