using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class StatusList
    {
        [JsonPropertyName("items")]
        public List<Status> Items { get; set; } = new List<Status>();

        public override string ToString() => $"Items: {Items.Count}";
    }
}
