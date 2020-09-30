using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Libraries.Serialization.Processdefinition.Model.JsonConverters
{
    public class KindJsonConverter : JsonConverter<Kind?>
    {
        public override Kind? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(Kind) ? new Kind(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, Kind? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Value);
        }
    }
}
