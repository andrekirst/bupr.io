using System.Text.Json.Serialization;
using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.JsonConverters;

namespace PoC_Serialization.Model.ProcessinstanceResearch
{
    public class Property : IHasStatus, IHasParent
    {
        [JsonPropertyName("value")]
        public object? Value { get; set; }

        [JsonPropertyName("id")]
        [JsonConverter(typeof(PropertyIdJsonConverter))]
        public PropertyId PropertyId { get; set; } = new PropertyId();

        public StatusId CurrentStatusId { get; set; }
        
        public void SetStatus(StatusId statusId)
        {
            throw new System.NotImplementedException();
        }

        public IHasParent? Parent { get; set; }
    }
}