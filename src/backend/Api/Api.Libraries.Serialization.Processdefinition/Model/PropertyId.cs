using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
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
