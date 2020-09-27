#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.ProcessdefinitionResearch.JsonConverters;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class HierarchyItem
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(HierarchyItemIdJsonConverter))]
        public HierarchyItemId? Id { get; set; }

        [JsonPropertyName("name")]
        public Name? Name { get; set; }

        [JsonPropertyName("items")]
        public List<HierarchyItem> Items { get; set; } = new List<HierarchyItem>();

        [JsonPropertyName("level")]
        public ulong Level { get; set; }

        [JsonPropertyName("sections")]
        public List<Section> Sections { get; set; } = new List<Section>();

        public override string ToString() => $"{Id} - {Name}";
    }
}