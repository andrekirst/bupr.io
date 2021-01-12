using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class LanguageKey
    {
        public LanguageKey(string key)
        {
            Guard.Against.NullOrWhiteSpace(key, nameof(key));

            Key = key;
        }

        public string Key { get; }

        public override string ToString() => Key;

        public static LanguageKey Deutsch => new LanguageKey("de");
        public static LanguageKey English => new LanguageKey("en");
    }
}