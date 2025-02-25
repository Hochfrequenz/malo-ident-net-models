using System.Text.Json;
using FluentAssertions;
using MaLoIdentModels.v1;

namespace MaLoIdentModelsTests.v1Tests;

public class EmptyStringAndObjectsDeserializationTests
{
    [Fact]
    public void Deserializing_Objects_With_Empty_Strings()
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
        deserializedModel.IdentificationParameterId.Should().NotBeNull();
        deserializedModel.IdentificationParameterAddress.Should().NotBeNull();
        deserializedModel
            .IdentificationParameterId.TranchenIds.Should()
            .BeNull(
                because: "the field tranchenIds is an empty list in the test data and should therefore be null after deserializing"
            );
        deserializedModel
            .IdentificationParameterAddress.LandParcels.Should()
            .BeNull(
                because: "Landparcels should be null, because in the test data the fields of all objects in this list, are empty strings"
            );
        deserializedModel.IdentificationParameterAddress.GeographicCoordinates.Should().NotBeNull();
        deserializedModel
            .IdentificationParameterAddress.GeographicCoordinates.Easting.Should()
            .BeNull(
                because: "the fields of the geographic coordinates object should be null, because in the test data the fields are empty strings"
            );
        deserializedModel
            .IdentificationParameterAddress.GeographicCoordinates.Northing.Should()
            .BeNull(
                because: "the fields of the geographic coordinates object should be null, because in the test data the fields are empty strings"
            );
        deserializedModel
            .IdentificationParameterAddress.GeographicCoordinates.East.Should()
            .BeNull(
                because: "the fields of the geographic coordinates object should be null, because in the test data the fields are empty strings"
            );
        deserializedModel
            .IdentificationParameterAddress.GeographicCoordinates.North.Should()
            .BeNull(
                "the fields of the geographic coordinates object should be null, because in the test data the fields are empty strings"
            );
        deserializedModel.IdentificationParameterAddress.LandParcels.Should().BeNull();
    }
}
