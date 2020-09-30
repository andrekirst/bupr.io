using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class Hierarchy
    {
        [JsonPropertyName("items")]
        public List<HierarchyItem> Items { get; set; } = new List<HierarchyItem>();

        public override string ToString() => $"Count = {Items.Count}";
    }
}
