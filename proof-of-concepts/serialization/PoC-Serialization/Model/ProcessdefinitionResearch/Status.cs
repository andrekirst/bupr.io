#nullable enable
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class StatusList
    {
        [JsonPropertyName("items")]
        public List<Status> Items { get; set; } = new List<Status>();

        public override string ToString() => $"Items: {Items.Count}";
    }

    public class Status
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(StatusIdJsonConverter))]
        public StatusId? StatusId { get; set; }

        [JsonPropertyName("internalName")]
        public string? InternalName { get; set; }

        [JsonPropertyName("name")]
        public Name? Name { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(StatusTypeJsonConverter))]
        public StatusType Type { get; set; } = StatusType.Error;

        [JsonPropertyName("icon")]
        public Icon? Icon { get; set; }

        public override string ToString() => $"{InternalName} ({Name})";
    }

    public class Icon
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        public override string ToString() => $"{Type} => {Value}";
    }

    public class StatusType
    {
        public string Value { get; }

        public StatusType(string value)
        {
            Guard.Against.NullOrWhiteSpace(value, nameof(value));

            Value = value;
        }

        public override string ToString() => Value;

        public static StatusType Error = new StatusType("error");
        public static StatusType Warning = new StatusType("warning");
        public static StatusType Success = new StatusType("success");
    }

    public class StatusTypeJsonConverter : JsonConverter<StatusType?>
    {
        public override StatusType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(StatusType) ? new StatusType(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, StatusType? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Value ?? string.Empty);
        }
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

    public class StatusIdJsonConverter : JsonConverter<StatusId?>
    {
        public override StatusId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(StatusId) ? new StatusId(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, StatusId? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Id ?? string.Empty);
        }
    }
}