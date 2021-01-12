using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.JsonConverters;

namespace PoC_Serialization.Model.ProcessinstanceResearch
{
    public class HierarchyItem : IHasStatus, IHasChilds<HierarchyItem>, IHasChilds<Section>, IHasParent
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(HierarchyItemIdJsonConverter))]
        public HierarchyItemId Id { get; set; } = new HierarchyItemId();

        [JsonPropertyName("items")]
        public List<HierarchyItem> Items { get; set; } = new List<HierarchyItem>();

        [JsonPropertyName("sections")]
        public List<Section>? Sections { get; set; }

        public StatusId CurrentStatusId { get; set; }
        public void SetStatus(StatusId statusId)
        {
            throw new System.NotImplementedException();
        }

        public IHasParent? Parent { get; set; }
    }
}