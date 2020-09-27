using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class PropertyId
    {
        public string Id { get; }

        public PropertyId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));
            Id = id;
        }

        public override string ToString() => Id;
    }
}