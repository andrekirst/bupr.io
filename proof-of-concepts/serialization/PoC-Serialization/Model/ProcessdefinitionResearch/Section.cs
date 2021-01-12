#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.JsonConverters;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Section
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(SectionIdJsonConverter))]
        public SectionId Id { get; set; } = new SectionId();

        [JsonPropertyName("name")]
        public Name? Name { get; set; }

        [JsonPropertyName("order")]
        public ulong Order { get; set; }

        [JsonPropertyName("controls")]
        public List<Control> Controls { get; set; } = new List<Control>();

        public override string ToString() => $"{Id}: {Name} : {Order}";
    }
}