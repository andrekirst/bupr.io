using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch.JsonConverters
{
    public class SectionIdJsonConverter : JsonConverter<SectionId?>
    {
        public override SectionId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(SectionId) ? new SectionId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, SectionId? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Id ?? string.Empty);
        }
    }
}