using System;
using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.Ids
{
    public class HierarchyItemId
    {
        public string Id { get; }

        public HierarchyItemId()
        {
            Id = $"hierarchyitem-{Guid.NewGuid()}";
        }
        
        public HierarchyItemId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));
            Id = id;
        }

        public override string ToString() => Id;
    }
}