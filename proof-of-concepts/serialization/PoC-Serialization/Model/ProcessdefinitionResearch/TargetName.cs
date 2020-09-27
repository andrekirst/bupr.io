using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class TargetName
    {
        public string Name { get; }

        public TargetName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Name = name;
        }

        public override string ToString() => Name;
    }
}