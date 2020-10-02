using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class SectionId
    {
        public string Id { get; }

        public SectionId(string id)
        {
			Guard.Against.NullOrWhiteSpace(id, nameof(id));
			Id = id;
		}

        public override string ToString() => Id;
    }
}
