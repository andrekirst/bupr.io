using System;
using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.Ids
{
    public class PropertyId
    {
        public string Id { get; }

        public PropertyId()
        {
            Id = $"property-{Guid.NewGuid()}";
        }
        
        public PropertyId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));
            Id = id;
        }

        public override string ToString() => Id;
    }
}