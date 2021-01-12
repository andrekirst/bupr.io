using System;
using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.Ids
{
    public class ControlId
    {
        public string Id { get; }

        public ControlId()
        {
            Id = $"control-{Guid.NewGuid()}";
        }

        public ControlId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));
            Id = id;
        }

        public override string ToString() => Id;

        public static ControlId Undefined => new ControlId("undefined");
    }
}