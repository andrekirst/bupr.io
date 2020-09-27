using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Validation
    {
        public string Value { get; }

        public Validation(string value)
        {
            Guard.Against.NullOrWhiteSpace(value, nameof(value));
            Value = value;
        }

        public override string ToString() => Value;
    }
}