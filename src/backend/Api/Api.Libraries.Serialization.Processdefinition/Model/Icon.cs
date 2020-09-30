using System.Text.Json.Serialization;

namespace Api.Libraries.Serialization.Processdefinition.Model
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