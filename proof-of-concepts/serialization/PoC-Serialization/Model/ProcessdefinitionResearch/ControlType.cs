using System.Collections.Generic;
using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class ControlType
    {
        public static IList<string> ValidValues = new List<string> { "label", "text", "date", "time", "checkbox" };

        public string Type { get; }

        public ControlType(string type)
        {
            Guard.Against.NullOrWhiteSpace(type, nameof(type));
            Guard.Against.NotMatchRegex(type, nameof(type), @"^[a-z][a-z\d\-]{1,}$");
            Guard.Against.SplittedValues(type, nameof(type), '-', ValidValues);
            Type = type;
        }

        public override string ToString() => Type;
    }

    public class LabelTextControlType : ControlType
    {
        public LabelTextControlType() : base("label-text")
        {
        }
    }
}