using System.Collections.Generic;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class PropertyType
    {
        public static IList<string> ValidValues = new List<string> { "label", "text", "date", "time", "checkbox" };

        public string Type { get; }

        public PropertyType(string type)
        {
            //Guard.Against.NullOrWhiteSpace(type, nameof(type));
            //Guard.Against.NotMatchRegex(type, nameof(type), @"^[a-z][a-z\d\-]{1,}$");
            //Guard.Against.SplittedValues(type, nameof(type), '-', ValidValues);
            //Type = type;
        }

        public override string ToString() => Type;
    }
}
