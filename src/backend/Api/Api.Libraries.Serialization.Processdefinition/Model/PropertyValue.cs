using System.Collections.Generic;
using System.Text.Json.Serialization;
using Api.Libraries.Serialization.Processdefinition.Model.JsonConverters;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class PropertyValue
    {
        [JsonPropertyName("targetName")]
        [JsonConverter(typeof(TargetNameJsonConverter))]
        public TargetName? TargetName { get; set; }

        [JsonPropertyName("nameValue")]
        public Name? NameValue { get; set; }

        [JsonPropertyName("variableName")]
        [JsonConverter(typeof(VariableNameJsonConverter))]
        public VariableName? VariableName { get; set; }

        [JsonPropertyName("rules")]
        public List<Rule> Rules { get; set; } = new List<Rule>();

        public override string ToString() => $"{TargetName} - Rules: {Rules.Count}";
    }
}
