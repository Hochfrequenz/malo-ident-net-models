using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaLoIdentModels.JsonSettings;

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

        return typeof(T)
            .GetProperties()
            .All(property =>
                property.PropertyType == typeof(string)
                    && ((string?)property.GetValue(model))?.Strip() == string.Empty
                || property.GetValue(model) == null
            );
    }
}
