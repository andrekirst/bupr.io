using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Name
    {
        [JsonPropertyName("names")]
        public List<LanguageName> Names { get; set; }
    }

    public class LanguageName
    {
        [JsonPropertyName("language")]
        public Language Language { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Language
    {
    }
}