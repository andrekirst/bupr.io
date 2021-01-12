#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Kind
    {
        public string Value { get; }
        public static List<string> ValidKindValues = new List<string>{ "ProcessDefinition", "ProcessInstance" };

        public Kind(string value)
        {
            Guard.Against.NullOrWhiteSpace(value, nameof(value));

            // TODO -> GuardClause
            if (ValidKindValues.All(kind => kind != value))
            {
                throw new ArgumentException("No valid kind value");
            }

            Value = value;
        }

        public override string ToString() => Value;

        public static implicit operator string(Kind kind) => kind.ToString();
        public static explicit operator Kind(string value) => new Kind(value);

        public static Kind ProcessDefinition => new Kind("ProcessDefinition");
        public static Kind ProcessInstance => new Kind("ProcessInstance");
    }
}