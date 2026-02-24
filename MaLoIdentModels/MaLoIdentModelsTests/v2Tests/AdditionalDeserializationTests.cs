using System;
using System.Text.Json;
using AwesomeAssertions;
using MaLoIdentModels.v2;

namespace MaLoIdentModelsTests.v2Tests;

public class AdditionalDeserializationTests
{
    [Fact]
    public void Zone_Null_Deserializes_To_Null()
    {
        var json = """
            {
                "latitude": "52.52",
                "longitude": "13.405",
                "zone": null
            }
            """;
        var model = JsonSerializer.Deserialize<GeographicCoordinates>(json);
        model.Should().NotBeNull();
        model!.Zone.Should().BeNull();
    }

    [Fact]
    public void Zone_Missing_Deserializes_To_Null()
    {
        var json = """
            {
                "latitude": "52.52",
                "longitude": "13.405"
            }
            """;
        var model = JsonSerializer.Deserialize<GeographicCoordinates>(json);
        model.Should().NotBeNull();
        model!.Zone.Should().BeNull();
    }

    [Fact]
    public void Zone_Valid_Value_Deserializes()
    {
        var json = """
            {
                "latitude": "52.52",
                "longitude": "13.405",
                "zone": "UTMZone32"
            }
            """;
        var model = JsonSerializer.Deserialize<GeographicCoordinates>(json);
        model.Should().NotBeNull();
        model!.Zone.Should().Be(Zone.UTMZone32);
    }

    [Fact]
    public void Zone_Null_Serializes_To_Null()
    {
        var model = new GeographicCoordinates { Zone = null };
        var json = JsonSerializer.Serialize(model);
        json.Should().Contain("\"zone\":null");
    }

    [Fact]
    public void Null_ExecutionTimeUntil_Deserializes_To_Null()
    {
        var json = """
            {
                "identifierNetworkOperator": 9900987654321,
                "executionTimeFrom": "2023-08-01T22:00:00Z",
                "executionTimeUntil": null
            }
            """;
        var model = JsonSerializer.Deserialize<MarketLocationNetworkOperator>(json);
        model.Should().NotBeNull();
        model!.ExecutionTimeUntil.Should().BeNull();
        model
            .ExecutionTimeFrom.Should()
            .Be(new DateTimeOffset(2023, 8, 1, 22, 0, 0, TimeSpan.Zero));
    }

    [Fact]
    public void Missing_ExecutionTimeUntil_Deserializes_To_Null()
    {
        var json = """
            {
                "identifierNetworkOperator": 9900987654321,
                "executionTimeFrom": "2023-08-01T22:00:00Z"
            }
            """;
        var model = JsonSerializer.Deserialize<MarketLocationNetworkOperator>(json);
        model.Should().NotBeNull();
        model!.ExecutionTimeUntil.Should().BeNull();
    }

    [Fact]
    public void Unknown_EnergyDirection_Throws_JsonException()
    {
        var json = """
            {
                "identificationDateTime": "2023-08-02T22:00:00Z",
                "energyDirection": "unknownValue"
            }
            """;
        var deserializing = () => JsonSerializer.Deserialize<IdentificationParameter>(json);
        deserializing.Should().Throw<JsonException>();
    }

    [Fact]
    public void Unknown_MarketLocationProperty_Throws_JsonException()
    {
        var json = """
            {
                "marketLocationProperty": "unknownValue",
                "executionTimeFrom": "2023-08-01T22:00:00Z"
            }
            """;
        var deserializing = () => JsonSerializer.Deserialize<MarketLocationCharacteristic>(json);
        deserializing.Should().Throw<JsonException>();
    }

    [Fact]
    public void Unknown_Proportion_Throws_JsonException()
    {
        var json = """
            {
                "identifierTranche": "57685676742",
                "proportion": "unknownValue"
            }
            """;
        var deserializing = () => JsonSerializer.Deserialize<Tranche>(json);
        deserializing.Should().Throw<JsonException>();
    }

    [Fact]
    public void Unknown_Zone_Throws_JsonException()
    {
        var json = """
            {
                "latitude": "52.52",
                "zone": "UTMZone99"
            }
            """;
        var deserializing = () => JsonSerializer.Deserialize<GeographicCoordinates>(json);
        deserializing.Should().Throw<JsonException>();
    }
}
