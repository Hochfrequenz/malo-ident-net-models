using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using MaLoIdentModels.JsonSettings;

namespace MaLoIdentModelsTests.v1Tests;

public class SinglePropertyDeserializationTests
{
    private const string JsonWithEmptyString = "{\"OptionalStringField\":\"\"}";

    private const string JsonWithEmptyLists = "{\"EmptylistField\":[]}";

    private const string JsonWithEmptyObjectsList =
        "{\"ListWithEmptyObjectsField\":[{\"Field\":\"\"}]}";

    private const string JsonWithEmptyNestedObjectsList =
        "{\"ListWithEmptyObjectsField\":[{\"Field\":{\"Field\":\"\"}}]}";

    internal class SomethingWithAOptionalStringField
    {
        [JsonConverter(typeof(EmptyStringConverter))]
        [JsonPropertyName("OptionalStringField")]
        public string? OptionalStringField { get; set; }
    }

    internal class SomethingWithAnEmptyListField
    {
        [JsonConverter(typeof(EmptyListToNullConverter<string>))]
        [JsonPropertyName("EmptyListField")]
        public List<string>? EmptyListField { get; set; }
    }

    internal class ObjectForList
    {
        [JsonPropertyName("Field")]
        public string? Field { get; set; }
    }

    internal class SomethingWithAnEmptyObjectListField
    {
        [JsonConverter(typeof(EmptyListToNullConverter<ObjectForList>))]
        [JsonPropertyName("ListWithEmptyObjectsField")]
        public List<ObjectForList>? ListWithEmptyObjectsField { get; set; }
    }

    internal class NestedObject
    {
        [JsonPropertyName("Field")]
        public ObjectForList? Field { get; set; }
    }

    internal class SomethingWithAnNestedEmptyObjectListField
    {
        [JsonConverter(typeof(EmptyListToNullConverter<ObjectForList>))]
        [JsonPropertyName("ListWithEmptyNestedObjectsField")]
        public List<ObjectForList>? ListWithEmptyNestedObjectsField { get; set; }
    }

    [Fact]
    public void Test_Models_With_Empty_Strings()
    {
        var deserializing = () =>
            JsonSerializer.Deserialize<SomethingWithAOptionalStringField>(JsonWithEmptyString);
        var deserializedModel = deserializing();
        deserializedModel.Should().NotBeNull();
        deserializedModel
            .OptionalStringField.Should()
            .BeNull(because: "empty strings should be intpreted as null");
        var reSererialized = JsonSerializer.Serialize(deserializedModel);
        reSererialized.Should().BeEquivalentTo("{\"OptionalStringField\":null}");
    }

    [Fact]
    public void Test_Models_With_Empty_Lists()
    {
        var deserializing = () =>
            JsonSerializer.Deserialize<SomethingWithAnEmptyListField>(JsonWithEmptyLists);
        var deserializedModel = deserializing();
        deserializedModel.Should().NotBeNull();
        deserializedModel
            .EmptyListField.Should()
            .BeNull(because: "empty lists should be intpreted as null");
        var reSererialized = JsonSerializer.Serialize(deserializedModel);
        reSererialized.Should().BeEquivalentTo("{\"EmptylistField\":null}");
    }

    [Fact]
    public void Test_List_With_Empty_Models()
    {
        var deserializing = () =>
            JsonSerializer.Deserialize<SomethingWithAnEmptyObjectListField>(
                JsonWithEmptyObjectsList
            );
        var deserializedModel = deserializing();
        deserializedModel.Should().NotBeNull();
        deserializedModel
            .ListWithEmptyObjectsField.Should()
            .BeNull(
                because: "lists with objects where all fields are an empty string should be null"
            );
        var reSererialized = JsonSerializer.Serialize(deserializedModel);
        reSererialized.Should().BeEquivalentTo("{\"ListWithEmptyObjectsField\":null}");
    }

    [Fact]
    public void Test_List_With_Empty_Nested_Models()
    {
        var deserializing = () =>
            JsonSerializer.Deserialize<SomethingWithAnNestedEmptyObjectListField>(
                JsonWithEmptyNestedObjectsList
            );
        var deserializedModel = deserializing();
        deserializedModel.Should().NotBeNull();
        deserializedModel
            .ListWithEmptyNestedObjectsField.Should()
            .BeNull(
                because: "lists with objects where all fields are an empty string should be null"
            );
        var reSererialized = JsonSerializer.Serialize(deserializedModel);
        reSererialized.Should().BeEquivalentTo("{\"ListWithEmptyNestedObjectsField\":null}");
    }
}
