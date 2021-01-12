using System;
using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.Ids
{
    public class SectionId
    {
        public string Id { get; }

        public SectionId()
        {
            Id = $"section-{Guid.NewGuid()}";
        }
        
        public SectionId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));
            Id = id;
        }

        public override string ToString() => Id;
    }
}