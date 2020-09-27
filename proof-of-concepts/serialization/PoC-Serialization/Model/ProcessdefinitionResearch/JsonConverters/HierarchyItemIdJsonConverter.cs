using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch.JsonConverters
{
    public class HierarchyItemIdJsonConverter : JsonConverter<HierarchyItemId?>
    {
        public override HierarchyItemId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(HierarchyItemId) ? new HierarchyItemId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, HierarchyItemId? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Id ?? string.Empty);
        }
    }
}