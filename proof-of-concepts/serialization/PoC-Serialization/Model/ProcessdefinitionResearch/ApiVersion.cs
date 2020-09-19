using System;
using System.Linq;
using System.Text.Json;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class ApiVersion
    {
        public ApiVersion()
        {
        }

        public ApiVersion(string value)
        {
            SetValues(value);
        }

        private void SetValues(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value can not be empty or whitespace", nameof(value));
            }

            if (value.Count(c => c == ':') > 1)
            {
                throw new ArgumentException("Only one semilcolon allowed", nameof(value));
            }

            var values = value.Split(':');
            Api = values[0];
            Version = values[1];
        }

        public string Api { get; private set; }
        public string Version { get; private set; }

        public override string ToString() => $"{Api}:{Version}";

        public static implicit operator string(ApiVersion apiVersion) => apiVersion.ToString();
        public static explicit operator ApiVersion(string value) => new ApiVersion(value);
    }

    public class ApiVersionJsonConverter : System.Text.Json.Serialization.JsonConverter<ApiVersion>
    {
        public override ApiVersion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(ApiVersion) ? new ApiVersion(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, ApiVersion value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}