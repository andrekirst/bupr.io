#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using JetBrains.Annotations;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class ProcessdefinitionId
    {
        public string Id { get; }

        public ProcessdefinitionId(string id)
        {
            Guard.Against.Null(id, nameof(id));

            if (!IsValidIdStructure(id))
            {
                throw new ArgumentException("Id is not in a valid structure", nameof(id));
            }

            Id = id;
        }

        public static bool IsValidIdStructure(string id)
        {
            // TODO Bessere Implementierung
            return Guid.TryParse(id, out _);
        }

        public override string ToString() => Id;

        public static implicit operator string(ProcessdefinitionId id) => id.ToString();
        public static explicit operator ProcessdefinitionId(string value) => new ProcessdefinitionId(value);
    }

    public class ProcessdefinitionIdJsonConverter : JsonConverter<ProcessdefinitionId?>
    {
        public override ProcessdefinitionId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(ProcessdefinitionId) ? new ProcessdefinitionId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, ProcessdefinitionId? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Id ?? string.Empty);
        }
    }
}