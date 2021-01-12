#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Hierarchy
    {
        [JsonPropertyName("hierarchies")]
        public List<HierarchyItem> Hierarchies { get; set; } = new List<HierarchyItem>();

        public override string ToString() => $"Count = {Hierarchies?.Count}";
    }
}