using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Libraries.Serialization.Processdefinition.Model.JsonConverters
{
    public class ValidationJsonConverter : JsonConverter<Validation?>
    {
        public override Validation? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(Validation) ? new Validation(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, Validation? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Value);
        }
    }
}
