using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class VariableName
    {
        public string Name { get; }

        public VariableName(string name)
        {
            //Guard.Against.NullOrWhiteSpace(name, nameof(name));
            //Name = name;
        }

        public override string ToString() => Name;
    }
}
