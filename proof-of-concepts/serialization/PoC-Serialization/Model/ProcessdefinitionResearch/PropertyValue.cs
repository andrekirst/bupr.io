using System.Collections.Generic;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.JsonConverters;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
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
        public List<Rule>? Rules { get; set; }
        
        [JsonPropertyName("variableType")]
        public VariableType? VariableType { get; set; }

        public override string ToString() => $"{TargetName} - Rules: {Rules?.Count}";
    }
}