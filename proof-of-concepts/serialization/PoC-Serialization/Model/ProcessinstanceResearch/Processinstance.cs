using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.Ids;

namespace PoC_Serialization.Model.ProcessinstanceResearch
{
    public class Processinstance
    {
        private readonly Dictionary<string, string?> _stringValues = new Dictionary<string, string?>();
        private readonly Dictionary<IHasStatus, StatusId> _statusList = new Dictionary<IHasStatus, StatusId>();

        private readonly Dictionary<string, DateTime?> _dateTimeValues = new Dictionary<string, DateTime?>();

        [JsonPropertyName("processDefinitionAsJson")]
        public string? ProcessDefinitionAsJson { get; set; }
        
        [JsonPropertyName("data")]
        public Hierarchy Data { get; set; } = new Hierarchy();

        public void SetRawValue(string propertyName, string? value)
        {
            _stringValues.TryAdd(propertyName, value);
        }

        public string? GetStringValue(string propertyName) => _stringValues[propertyName];
        public DateTime? GetDataTimeValue(string propertyName) => _dateTimeValues[propertyName];

        public void SetRawValue(string propertyName, DateTime? value)
        {
            _dateTimeValues.TryAdd(propertyName, value);
        }

        public void SetStatus(PropertyId propertyId, StatusId statusId)
        {
            var property = FindPropertyById(propertyId);

            if (property == null)
            {
                throw new ArgumentNullException();
            }

            property.CurrentStatusId = statusId;
        }

        public void SetStatusRecursive(PropertyId propertyId, StatusId statusId)
        {
            var property = FindPropertyById(propertyId);

            if (property == null)
            {
                throw new ArgumentNullException();
            }

            var parent = property.Parent;

            while (parent != null)
            {
                if (parent is IHasStatus parentWithStatus &&
                    parentWithStatus.CurrentStatusId == statusId)
                {
                    break;
                }

                if (parent is IHasChilds<Property> propertiesOfParent)
                {
                    
                }

                parent = parent.Parent;
            }
        }

        private Property? FindPropertyById(PropertyId propertyId)
        {
            foreach (var hierarchyItem in Data.Items ?? throw new ArgumentException("No hierarchy available"))
            {
                foreach (var item in hierarchyItem.Items)
                {
                    return FindPropertyById(item, propertyId);
                }

                return FindPropertyById(hierarchyItem, propertyId);
            }

            throw new ArgumentOutOfRangeException();
        }

        private static Property? FindPropertyById(HierarchyItem hierarchyItem, PropertyId propertyId)
            => hierarchyItem.Sections?.SelectMany(section => section.Controls.SelectMany(control => control.Properties.Where(property => property.PropertyId.Id == propertyId.Id))).FirstOrDefault();
    }
}