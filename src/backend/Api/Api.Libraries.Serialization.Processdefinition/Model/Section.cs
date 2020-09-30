using System.Collections.Generic;
using System.Text.Json.Serialization;
using Api.Libraries.Serialization.Processdefinition.Model.JsonConverters;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class Section
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(SectionIdJsonConverter))]
        public SectionId? Id { get; set; }

        [JsonPropertyName("name")]
        public Name? Name { get; set; }

        [JsonPropertyName("order")]
        public ulong Order { get; set; }

        [JsonPropertyName("properties")]
        public List<Property> Properties { get; set; } = new List<Property>();

        public override string ToString() => $"{Id}: {Name} : {Order}";
    }
}
