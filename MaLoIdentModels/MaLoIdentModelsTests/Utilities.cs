using System.Text.Json;

namespace MaLoIdentModelsTests;
using FluentAssertions;
public static class Utilities
{
    /// <summary>
    /// We don't want to compare string equality (because of stuff like 'how are the keys sorted', is the json minified or prettyfied)
    /// but also we want ensure that the JSON objects produced are equivalent on a level, that is not the C# model itself.
    /// Because e.g. if a datetime originally is '2021-01-01T00:00:00Z' and after deserialization it is '2021-01-01T00:00:00.000+00:00' the C# model would be the same, but the JSON would not.
    /// And EDI@Energy care about the trailing 'Z' in the datetime.
    /// </summary>
    /// <param name="actual"></param>
    /// <param name="expected"></param>
    public static void AssertJsonStringsAreEquivalent(string actual, string expected)
    {
        using var actualJsonDocument = JsonDocument.Parse(actual);
        using var expectedJsonDocument = JsonDocument.Parse(expected);
        
        // Use Fluent Assertions to compare the objects
        actualJsonDocument.Should().BeEquivalentTo(expectedJsonDocument);
    }
    
}