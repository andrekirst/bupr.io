using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch.JsonConverters
{
    public class ProcessdefinitionIdJsonConverter : JsonConverter<ProcessdefinitionId?>
    {
        public override ProcessdefinitionId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(ProcessdefinitionId) ? new ProcessdefinitionId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, ProcessdefinitionId? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Id ?? string.Empty);
        }
    }
}