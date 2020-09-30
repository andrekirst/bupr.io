using System.Text.Json.Serialization;
using Api.Libraries.Serialization.Processdefinition.Model.JsonConverters;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class LanguageName
    {
        [JsonPropertyName("language")]
        [JsonConverter(typeof(LanguageKeyJsonConverter))]
        public LanguageKey? Language { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        public override string ToString() => $"{Language?.Key}: {Value}";
    }
}
