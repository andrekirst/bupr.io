#nullable enable
using System;
using System.Linq;
using System.Text.Json;
using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class ApiVersion
    {
        public ApiVersion(string value)
        {
            SetValues(value);
        }

        private void SetValues(string value)
        {
            Guard.Against.NullOrWhiteSpace(value, nameof(value));

            // TODO -> GuardClause
            if (value.Count(c => c == ':') > 1)
            {
                throw new ArgumentException("Only one semilcolon allowed", nameof(value));
            }

            var values = value.Split(':');
            Api = values[0];
            Version = values[1];
        }

        public string Api { get; private set; } = string.Empty;
        public string Version { get; private set; } = string.Empty;

        public override string ToString() => $"{Api}:{Version}";

        public static implicit operator string(ApiVersion apiVersion) => apiVersion.ToString();
        public static explicit operator ApiVersion(string value) => new ApiVersion(value);
    }

    public class ApiVersionJsonConverter : System.Text.Json.Serialization.JsonConverter<ApiVersion?>
    {
        public override ApiVersion? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(ApiVersion) ? new ApiVersion(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, ApiVersion? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value?.Api}:{value?.Version}");
        }
    }
}