using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.JsonConverters;

namespace PoC_Serialization.Model.ProcessinstanceResearch
{
    public class Control : IHasStatus, IHasChilds<Property>, IHasParent
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(ControlIdJsonConverter))]
        public ControlId ControlId { get; set; } = ControlId.Undefined;

        [JsonPropertyName("properties")]
        public List<Property> Properties { get; set; } = new List<Property>();

        public StatusId CurrentStatusId { get; set; }
        public void SetStatus(StatusId statusId)
        {
            throw new System.NotImplementedException();
        }

        public IHasParent? Parent { get; set; }

        public override string ToString() => $"Id: {ControlId.Id} - Properties: {Properties.Count}";
    }
}