using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class VariableName
    {
        public string Name { get; }

        public VariableName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Name = name;
        }

        public override string ToString() => Name;
    }
}