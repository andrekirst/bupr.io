#nullable enable
using System.Text.Json.Serialization;
using PoC_Serialization.Model.ProcessdefinitionResearch.JsonConverters;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
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
}