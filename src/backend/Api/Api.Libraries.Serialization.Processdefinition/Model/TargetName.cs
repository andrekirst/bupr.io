using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
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
