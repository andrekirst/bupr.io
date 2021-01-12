using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.ProcessdefinitionResearch;

namespace PoC_Serialization.Model.JsonConverters
{
    public class StatusIdentificationJsonConverter : JsonConverter<StatusIdentification>
    {
        public override StatusIdentification? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(StatusIdentification) ? new StatusIdentification(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, StatusIdentification? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Value);
        }
    }
}