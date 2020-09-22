#nullable enable
using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Processdefinition
    {
        [JsonPropertyName("apiVersion")]
        [JsonConverter(typeof(ApiVersionJsonConverter))]
        public ApiVersion? ApiVersion { get; set; }

        [JsonPropertyName("kind")]
        [JsonConverter(typeof(KindJsonConverter))]
        public Kind? Kind { get; set; }

        [JsonPropertyName("processdefinitionId")]
        [JsonConverter(typeof(ProcessdefinitionIdJsonConverter))]
        public ProcessdefinitionId? ProcessdefinitionId { get; set; }

        [JsonPropertyName("name")]
        public Name? Name { get; set; }

        [JsonPropertyName("statusList")]
        public StatusList? StatusList { get; set; }
    }
}