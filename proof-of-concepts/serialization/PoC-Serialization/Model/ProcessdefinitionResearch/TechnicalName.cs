using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class TechnicalName
    {
        public string Name { get; }

        public TechnicalName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.NotMatchRegex(name, nameof(name), @"^[a-zA-Z\-]{1,}$");
            Name = name;
        }

        public override string ToString() => Name;
    }
}