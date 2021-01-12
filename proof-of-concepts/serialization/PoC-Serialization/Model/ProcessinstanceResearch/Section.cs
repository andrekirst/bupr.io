using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.JsonConverters;

namespace PoC_Serialization.Model.ProcessinstanceResearch
{
    public class Section : IHasStatus, IHasChilds<Control>, IHasParent
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(SectionIdJsonConverter))]
        public SectionId Id { get; set; }

        [JsonPropertyName("controls")]
        public List<Control> Controls { get; set; } = new List<Control>();

        public override string ToString() => Id.Id;
        public StatusId CurrentStatusId { get; set; }
        public void SetStatus(StatusId statusId)
        {
            throw new System.NotImplementedException();
        }

        public IHasParent? Parent { get; set; }
    }
}