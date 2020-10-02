using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class TechnicalName
    {
        public string Name { get; }

        public TechnicalName(string name)
        {
			Guard.Against.NullOrWhiteSpace(name, nameof(name));
			// TODO implementieren
			//Guard.Against.NotMatchRegex(name, nameof(name), @"^[a-zA-Z\-]{1,}$");
			Name = name;
		}

        public override string ToString() => Name;
    }
}
