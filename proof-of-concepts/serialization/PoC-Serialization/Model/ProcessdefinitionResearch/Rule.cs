using System.Text.Json.Serialization;
using PoC_Serialization.Model.ProcessdefinitionResearch.JsonConverters;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Rule
    {
        [JsonPropertyName("targetStatus")]
        [JsonConverter(typeof(StatusIdentificationJsonConverter))]
        public StatusIdentification? TargetStatus { get; set; }

        [JsonPropertyName("validation")]
        [JsonConverter(typeof(ValidationJsonConverter))]
        public Validation? Validation { get; set; }

        [JsonPropertyName("statusOnValidationFailure")]
        [JsonConverter(typeof(StatusIdentificationJsonConverter))]
        public StatusIdentification? StatusOnValidationFailure { get; set; }

        public override string ToString() => $"{TargetStatus} ({Validation}) -> OnFailure: {StatusOnValidationFailure}";
    }
}