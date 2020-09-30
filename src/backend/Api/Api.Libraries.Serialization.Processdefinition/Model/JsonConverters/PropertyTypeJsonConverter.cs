using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Libraries.Serialization.Processdefinition.Model.JsonConverters
{
    public class PropertyTypeJsonConverter : JsonConverter<PropertyType?>
    {
        public override PropertyType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(PropertyType) ? new PropertyType(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, PropertyType? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Type);
        }
    }
}
