#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Hierarchy
    {
        [JsonPropertyName("items")]
        public List<HierarchyItem> Items { get; set; } = new List<HierarchyItem>();
    }

    public class HierarchyItem
    {
        [JsonPropertyName("name")]
        public Name? Name { get; set; }
    }
}