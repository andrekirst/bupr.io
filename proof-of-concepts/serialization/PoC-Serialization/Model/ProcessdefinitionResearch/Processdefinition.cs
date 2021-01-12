#nullable enable
using System;
using System.Linq;
using System.Text.Json.Serialization;
using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.JsonConverters;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class Processdefinition
    {
        [JsonPropertyName("apiVersion")]
        [JsonConverter(typeof(ApiVersionJsonConverter))]
        public ApiVersion ApiVersion { get; set; } = new ApiVersion("ProcessDefinition:v1");

        [JsonPropertyName("kind")]
        [JsonConverter(typeof(KindJsonConverter))]
        public Kind Kind { get; set; } = new Kind("ProcessDefinition");

        [JsonPropertyName("processdefinitionId")]
        [JsonConverter(typeof(ProcessdefinitionIdJsonConverter))]
        public ProcessdefinitionId ProcessdefinitionId { get; set; } = new ProcessdefinitionId();

        [JsonPropertyName("name")]
        public Name Name { get; set; } = new Name();

        [JsonPropertyName("statusList")]
        public StatusList StatusList { get; set; } = new StatusList();

        [JsonPropertyName("isEnabled")]
        public bool IsEnabled { get; set; } = true;

        [JsonPropertyName("hierarchy")]
        public Hierarchy Hierarchy { get; set; } = new Hierarchy();

        [JsonPropertyName("version")]
        public string Version { get; set; } = "v1";

        public Property? FindPropertyByName(string name)
        {
            foreach (var hierarchyItem in Hierarchy.Hierarchies ?? throw new ArgumentException("No hierarchy available"))
            {
                foreach (var item in hierarchyItem.Items)
                {
                    return FindPropertyByName(item, name);
                }

                return FindPropertyByName(hierarchyItem, name);
            }

            return null;
        }
        
        private static Property? FindPropertyByName(HierarchyItem hierarchyItem, string name)
            => hierarchyItem.Sections?.SelectMany(section => section.Controls.SelectMany(control => control.Properties.Where(property => property.TechnicalName?.Name == name))).FirstOrDefault();
    }
}