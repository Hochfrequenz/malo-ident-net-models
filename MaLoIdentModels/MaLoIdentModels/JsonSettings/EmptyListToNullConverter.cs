using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.JsonSettings;

/// <summary>
/// A custom JSON converter for lists that converts empty lists or lists with all empty models to null.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class EmptyListToNullConverter<T> : JsonConverter<List<T>>
{
    public override List<T>? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            var list = JsonSerializer.Deserialize<List<T>>(ref reader, options);
            if (list != null && (list.Count == 0 || list.All(IsEmptyModel)))
            {
                return null;
            }
            return list;
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, List<T>? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }

    private bool IsEmptyModel(T model)
    {
        if (model is string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        bool allChildPropertiesAreDefault = typeof(T)
            .GetProperties()
            .All(property =>
            {
                var value = property.GetValue(model);
                if (property.PropertyType == typeof(string))
                {
                    return string.IsNullOrWhiteSpace((string?)value);
                }
                // Non-null properties (value types, objects) mean the model has data.
                return value == null;
            });

        return allChildPropertiesAreDefault;
    }
}
