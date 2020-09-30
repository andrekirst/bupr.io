using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Libraries.Serialization.Processdefinition.Model.JsonConverters
{
    public class StatusIdJsonConverter : JsonConverter<StatusId?>
    {
        public override StatusId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(StatusId) ? new StatusId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, StatusId? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Id);
        }
    }
}
