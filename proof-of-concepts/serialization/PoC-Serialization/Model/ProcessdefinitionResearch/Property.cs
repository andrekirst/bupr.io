using System.Text.Json.Serialization;
using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.JsonConverters;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Property
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(PropertyIdJsonConverter))]
        public PropertyId Id { get; set; } = new PropertyId();

        [JsonPropertyName("technicalName")]
        [JsonConverter(typeof(TechnicalNameJsonConverter))]
        public TechnicalName? TechnicalName { get; set; }

        [JsonPropertyName("values")]
        public PropertyValue? Value { get; set; }

        [JsonPropertyName("defaultStatus")]
        public StatusIdentification DefaultStatus { get; set; } = "red";

        public override string ToString() => $"{Id} - {TechnicalName}";
    }
}