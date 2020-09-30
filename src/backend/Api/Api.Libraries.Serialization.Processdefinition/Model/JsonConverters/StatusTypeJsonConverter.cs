using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Libraries.Serialization.Processdefinition.Model.JsonConverters
{
    public class StatusTypeJsonConverter : JsonConverter<StatusType?>
    {
        public override StatusType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(StatusType) ? new StatusType(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, StatusType? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Value);
        }
    }
}
