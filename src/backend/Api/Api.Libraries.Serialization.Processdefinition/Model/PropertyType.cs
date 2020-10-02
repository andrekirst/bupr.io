using System.Collections.Generic;
using System.Collections.ObjectModel;
using Api.Libraries.Extensions.Guard;
using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class PropertyType
    {
        private static readonly IReadOnlyCollection<string> ValidValues = new ReadOnlyCollection<string>(new List<string> { "label", "text", "date", "time", "checkbox" });

        public string Type { get; }

        public PropertyType(string type)
        {
			Guard.Against.NullOrWhiteSpace(type, nameof(type));
			// TODO Guards implementieren
			Guard.Against.NotMatchRegex(type, nameof(type), @"^[a-z][a-z\d\-]{1,}$");
			//Guard.Against.SplittedValues(type, nameof(type), '-', ValidValues);
			Type = type;
		}

        public override string ToString() => Type;
    }
}
