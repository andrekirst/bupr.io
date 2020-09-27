#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Name
    {
        [JsonPropertyName("names")]
        public List<LanguageName?> Names { get; set; } = new List<LanguageName?>();

        public override string? ToString()
        {
            var languageName = Names.FirstOrDefault();
            return languageName == null ? base.ToString() : $"{languageName.Language}: {languageName.Value}";
        }
    }
}