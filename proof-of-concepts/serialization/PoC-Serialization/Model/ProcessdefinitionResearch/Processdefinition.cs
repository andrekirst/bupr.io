using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Processdefinition
    {
        [JsonPropertyName("apiVersion")]
        [JsonConverter(typeof(ApiVersionJsonConverter))]
        public ApiVersion ApiVersion { get; set; }

        [JsonPropertyName("kind")]
        [JsonConverter(typeof(KindJsonConverter))]
        public Kind Kind { get; set; }
    }
}