using System.Text.Json.Serialization;
using PoC_Serialization.Model.JsonConverters;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class LanguageName
    {
        [JsonPropertyName("language")]
        [JsonConverter(typeof(LanguageKeyJsonConverter))]
        public LanguageKey? Language { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        public override string ToString() => $"{Language?.Key}: {Value}";

        public static LanguageName For(LanguageKey key, string value)
            => new LanguageName
            {
                Language = key,
                Value = value
            };
    }
}