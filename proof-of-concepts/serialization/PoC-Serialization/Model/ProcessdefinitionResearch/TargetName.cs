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

        public static implicit operator TargetName(string name) => new TargetName(name);

        public override string ToString() => Name;
    }
}