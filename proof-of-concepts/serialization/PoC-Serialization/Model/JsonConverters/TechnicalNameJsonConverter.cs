using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.ProcessdefinitionResearch;

namespace PoC_Serialization.Model.JsonConverters
{
    public class TechnicalNameJsonConverter : JsonConverter<TechnicalName>
    {
        public override TechnicalName? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(TechnicalName) ? new TechnicalName(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, TechnicalName? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Name);
        }
    }
}