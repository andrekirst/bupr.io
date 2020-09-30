using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Libraries.Serialization.Processdefinition.Model.JsonConverters
{
    public class LanguageKeyJsonConverter : JsonConverter<LanguageKey?>
    {
        public override LanguageKey? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(LanguageKey) ? new LanguageKey(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, LanguageKey? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Key);
        }
    }
}
