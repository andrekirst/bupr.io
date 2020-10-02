using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
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
