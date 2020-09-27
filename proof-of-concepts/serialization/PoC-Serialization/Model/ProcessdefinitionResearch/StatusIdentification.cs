using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class StatusIdentification
    {
        public string Value { get; }

        public StatusIdentification(string value)
        {
            Guard.Against.NullOrWhiteSpace(value, nameof(value));
            Value = value;
        }

        public override string ToString() => Value;
    }
}