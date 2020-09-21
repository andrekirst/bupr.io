using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class StatusList
    {
        [JsonPropertyName("items")]
        public List<Status> Items { get; set; }

        public override string ToString() => $"Items: {Items.Count}";
    }

    public class Status
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(StatusIdJsonConverter))]
        public StatusId StatusId { get; set; }

        [JsonPropertyName("internalName")]
        public string InternalName { get; set; }

        [JsonPropertyName("name")]
        public Name Name { get; set; }

        public override string ToString() => $"{InternalName} ({Name})";
    }

    public class StatusId
    {
        public StatusId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));

            Id = id;
        }

        public string Id { get; }

        public override string ToString() => Id;
    }

    public class StatusIdJsonConverter : JsonConverter<StatusId>
    {
        public override StatusId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(StatusId) ? new StatusId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, StatusId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Id);
        }
    }
}