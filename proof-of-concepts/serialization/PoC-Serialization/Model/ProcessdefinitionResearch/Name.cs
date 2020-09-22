#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;

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

    public class LanguageName
    {
        [JsonPropertyName("language")]
        [JsonConverter(typeof(LanguageKeyJsonConverter))]
        public LanguageKey? Language { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        public override string ToString() => $"{Language?.Key}: {Value}";
    }

    public class LanguageKey
    {
        public LanguageKey(string key)
        {
            Guard.Against.NullOrWhiteSpace(key, nameof(key));

            Key = key;
        }

        public string Key { get; }

        public override string ToString() => Key;
    }

    public class LanguageKeyJsonConverter : JsonConverter<LanguageKey?>
    {
        public override LanguageKey? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => typeToConvert == typeof(LanguageKey) ? new LanguageKey(reader.GetString()) : null;

        public override void Write(Utf8JsonWriter writer, LanguageKey? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Key ?? string.Empty);
        }
    }
}