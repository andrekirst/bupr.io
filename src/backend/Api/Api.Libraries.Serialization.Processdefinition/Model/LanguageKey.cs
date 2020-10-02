using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
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
    }
}
