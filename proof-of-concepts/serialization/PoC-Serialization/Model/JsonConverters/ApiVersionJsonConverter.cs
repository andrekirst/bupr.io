using System;
using System.Text.Json;
using PoC_Serialization.Model.ProcessdefinitionResearch;

namespace PoC_Serialization.Model.JsonConverters
{
    public class ApiVersionJsonConverter : System.Text.Json.Serialization.JsonConverter<ApiVersion>
    {
        public override ApiVersion? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(ApiVersion) ? new ApiVersion(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, ApiVersion? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value?.Api}:{value?.Version}");
        }
    }
}