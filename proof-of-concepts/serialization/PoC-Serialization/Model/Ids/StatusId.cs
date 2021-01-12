#nullable enable
using System;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.Ids
{
    public class StatusId
    {
        public StatusId()
        {
            Id = $"status-{Guid.NewGuid()}";
        }
        
        public StatusId(string id)
        {
            Guard.Against.NullOrWhiteSpace(id, nameof(id));

            Id = id;
        }

        public string Id { get; }

        public override string ToString() => Id;

        //public static bool IsValid(string value) => Regex.IsMatch(value, @"status\-[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$");
    }
}