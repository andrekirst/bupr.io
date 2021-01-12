#nullable enable
using System;
using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.Ids
{
    public class ProcessdefinitionId
    {
        public string Id { get; }

        public ProcessdefinitionId()
        {
            Id = $"processdefinition-{Guid.NewGuid()}";
        }
        
        public ProcessdefinitionId(string id)
        {
            Guard.Against.Null(id, nameof(id));

            if (!IsValidIdStructure(id))
            {
                throw new ArgumentException("Id is not in a valid structure", nameof(id));
            }

            Id = id;
        }

        public static bool IsValidIdStructure(string id)
        {
            // TODO Bessere Implementierung
            return Guid.TryParse(id, out _);
        }

        public override string ToString() => Id;

        public static implicit operator string(ProcessdefinitionId id) => id.ToString();
        public static explicit operator ProcessdefinitionId(string value) => new ProcessdefinitionId(value);
    }
}