using System.Text.Json;
using AwesomeAssertions;
using MaLoIdentModels.v2;

namespace MaLoIdentModelsTests.v2Tests;

public class EmptyStringAndObjectsDeserializationTests
{
    [Fact]
    public void Deserializing_Objects_With_Empty_Strings()
    {
        var fileBody = File.ReadAllText("v2Tests/examples/request_empty_string.json");
        fileBody
            .Should()
            .Contain(
                "\"\"",
                because: "In the testdata an empty string is used to represent a missing value"
            );
        var deserializedModel = JsonSerializer.Deserialize<IdentificationParameter>(fileBody);
        deserializedModel.Should().NotBeNull();
        deserializedModel.IdentificationParameterId.Should().NotBeNull();
        deserializedModel.IdentificationParameterAddress.Should().NotBeNull();
        deserializedModel
            .IdentificationParameterId.IdentifierMarketTranches.Should()
            .BeNull(
                because: "the field identifierMarketTranches is an empty list in the test data and should therefore be null after deserializing"
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

    [Fact]
    public void Deserializing_Pos_Response_Objects_With_Empty_Strings()
    {
        var fileBody = File.ReadAllText("v2Tests/examples/result_positive_empty_lists.json");
        var deserializedModel = JsonSerializer.Deserialize<ResultPositive>(fileBody);
        deserializedModel.Should().NotBeNull();
        deserializedModel.MarketLocation.Should().NotBeNull();
        deserializedModel
            .MarketLocation.LandParcels.Should()
            .BeNull(because: "this list contains one object, that has only empty string fields");
        deserializedModel.MarketLocation.GeographicCoordinates.Should().NotBeNull();
        deserializedModel
            .MarketLocation.GeographicCoordinates.East.Should()
            .BeNull(because: "field is empty string");
        deserializedModel
            .MarketLocation.GeographicCoordinates.North.Should()
            .BeNull(because: "field is empty string");
        deserializedModel.Tranches.Should().BeNull(because: "this list is empty");
        deserializedModel.MeterLocations.Should().BeNull(because: "this list is empty");
        deserializedModel.TechnicalResources.Should().BeNull(because: "this list is empty");
        deserializedModel.ControllableResources.Should().BeNull(because: "this list is empty");
    }
}
