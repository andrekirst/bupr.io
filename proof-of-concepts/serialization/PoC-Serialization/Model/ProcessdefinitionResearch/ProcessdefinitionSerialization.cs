using System.IO;
using System.Text.Json;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public static class ProcessdefinitionSerialization
    {
        public static void DeserializePoC1File()
        {
            const string file = @"Model\ProcessdefinitionResearch\Files\poc1.json";
            var json = File.ReadAllText(file);
            var processdefinition = JsonSerializer.Deserialize<Processdefinition>(json);
        }
    }
}