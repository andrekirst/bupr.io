#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.JsonConverters;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Control
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(ControlIdJsonConverter))]
        public ControlId ControlId { get; set; } = new ControlId();

        [JsonPropertyName("type")]
        [JsonConverter(typeof(ControlTypeJsonConverter))]
        public ControlType? Type { get; set; }

        [JsonPropertyName("properties")]
        public List<Property> Properties { get; set; } = new List<Property>();

        [JsonPropertyName("technicalName")]
        public TechnicalName? TechnicalName { get; set; }
    }
}