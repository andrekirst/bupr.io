using System.Collections.Generic;
using System.Text.Json.Serialization;
using Api.Libraries.Serialization.Processdefinition.Model.JsonConverters;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class Property
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(PropertyIdJsonConverter))]
        public PropertyId? Id { get; set; }

        [JsonPropertyName("technicalName")]
        [JsonConverter(typeof(TechnicalNameJsonConverter))]
        public TechnicalName? TechnicalName { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(PropertyTypeJsonConverter))]
        public PropertyType? Type { get; set; }

        [JsonPropertyName("values")]
        public List<PropertyValue> Values { get; set; } = new List<PropertyValue>();

        public override string ToString() => $"{Id} - {TechnicalName} - {Type} - Values: {Values.Count}";
    }
}
