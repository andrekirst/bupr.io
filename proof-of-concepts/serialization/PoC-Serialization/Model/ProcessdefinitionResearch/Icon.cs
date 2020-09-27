using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Icon
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        public override string ToString() => $"{Type} => {Value}";
    }
}