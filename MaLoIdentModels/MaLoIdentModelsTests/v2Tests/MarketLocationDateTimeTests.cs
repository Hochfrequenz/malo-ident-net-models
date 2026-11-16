using System;
using System.Text.Json;
using AwesomeAssertions;
using MaLoIdentModels.v2;

namespace MaLoIdentModelsTests.v2Tests;

public class MarketLocationDateTimeTests
{
    [Fact]
    public void Deserializes_With_V2_Property_Names()
    {
        var json = """
            {
                "identifierMarketLocation": "57685676748",
                "executionTimeFrom": "2023-08-01T22:00:00Z",
                "executionTimeUntil": "2024-01-01T23:00:00Z"
            }
            """;
        var model = JsonSerializer.Deserialize<MarketLocationDateTime>(json);
        model.Should().NotBeNull();
        model!.IdentifierMarketLocation.Should().Be("57685676748");
        model
            .ExecutionTimeFrom.Should()
            .Be(new DateTimeOffset(2023, 8, 1, 22, 0, 0, TimeSpan.Zero));
        model
            .ExecutionTimeUntil.Should()
            .Be(new DateTimeOffset(2024, 1, 1, 23, 0, 0, TimeSpan.Zero));
    }

    [Fact]
    public void Serializes_With_V2_Property_Names()
    {
        var model = new MarketLocationDateTime
        {
            IdentifierMarketLocation = "57685676748",
            ExecutionTimeFrom = new DateTimeOffset(2023, 8, 1, 22, 0, 0, TimeSpan.Zero),
            ExecutionTimeUntil = new DateTimeOffset(2024, 1, 1, 23, 0, 0, TimeSpan.Zero),
        };
        var json = JsonSerializer.Serialize(model);
        json.Should().Contain("\"identifierMarketLocation\"");
        json.Should().NotContain("\"maloId\"");
    }

    [Fact]
    public void Roundtrip_Preserves_Values()
    {
        var model = new MarketLocationDateTime
        {
            IdentifierMarketLocation = "57685676748",
            ExecutionTimeFrom = new DateTimeOffset(2023, 8, 1, 22, 0, 0, TimeSpan.Zero),
            ExecutionTimeUntil = null,
        };
        var json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MarketLocationDateTime>(json);
        deserialized.Should().BeEquivalentTo(model);
    }

    [Fact]
    public void Null_ExecutionTimeUntil_Roundtrips()
    {
        var json = """
            {
                "identifierMarketLocation": "57685676748",
                "executionTimeFrom": "2023-08-01T22:00:00Z",
                "executionTimeUntil": null
            }
            """;
        var model = JsonSerializer.Deserialize<MarketLocationDateTime>(json);
        model.Should().NotBeNull();
        model!.ExecutionTimeUntil.Should().BeNull();
        var reSerialized = JsonSerializer.Serialize(model);
        reSerialized.Should().Contain("\"executionTimeUntil\":null");
    }
}
