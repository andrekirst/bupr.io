using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Libraries.Serialization.Processdefinition.Model.JsonConverters
{
    public class TargetNameJsonConverter : JsonConverter<TargetName?>
    {
        public override TargetName? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(TargetName) ? new TargetName(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, TargetName? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Name);
        }
    }
}
