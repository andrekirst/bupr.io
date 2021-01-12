using System.Text.Json.Serialization;
using PoC_Serialization.Model.JsonConverters;
using PoC_Serialization.Model.ProcessdefinitionResearch.Validations;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Rule
    {
        [JsonPropertyName("targetStatus")]
        [JsonConverter(typeof(StatusIdentificationJsonConverter))]
        public StatusIdentification TargetStatus { get; set; }

        [JsonPropertyName("validationOptions")]
        public ValidationOptions? ValidationOptions { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; } = 1;

        [JsonPropertyName("statusOnValidationFailure")]
        [JsonConverter(typeof(StatusIdentificationJsonConverter))]
        public StatusIdentification StatusOnValidationFailure { get; set; }

        public override string ToString() => $"{TargetStatus} ({ValidationOptions?.ValidationTypeName}) -> OnFailure: {StatusOnValidationFailure}";
    }
}