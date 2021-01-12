using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.ProcessdefinitionResearch;

namespace PoC_Serialization.Model.JsonConverters
{
    public class ControlTypeJsonConverter : JsonConverter<ControlType>
    {
        public override ControlType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(ControlType) ? new ControlType(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, ControlType? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Type);
        }
    }
}