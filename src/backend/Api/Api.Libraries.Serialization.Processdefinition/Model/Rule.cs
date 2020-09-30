using System.Text.Json.Serialization;
using Api.Libraries.Serialization.Processdefinition.Model.JsonConverters;

namespace Api.Libraries.Serialization.Processdefinition.Model
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
