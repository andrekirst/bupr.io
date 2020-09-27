using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class HierarchyItemId
    {
        public string Id { get; }

        public HierarchyItemId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));
            Id = id;
        }

        public override string ToString() => Id;
    }
}