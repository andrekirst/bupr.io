using Api.Libraries.Extensions.Guard;
using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class ApiVersion
    {
        public ApiVersion(string value)
		{
			Guard.Against.NullOrWhiteSpace(value, nameof(value));
			Guard.Against.ExactOccurence(value, nameof(value), ':', 1);

			var values = value.Split(':');
			Api = values[0];
			Version = values[1];
			FullText = value;
		}

        public string Api { get; }
        public string Version { get; }
        public string FullText { get; }

        public override string ToString() => FullText;
    }
}
