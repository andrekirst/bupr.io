using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch.JsonConverters
{
    public class PropertyIdJsonConverter : JsonConverter<PropertyId?>
    {
        public override PropertyId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(PropertyId) ? new PropertyId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, PropertyId? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Id ?? string.Empty);
        }
    }
}