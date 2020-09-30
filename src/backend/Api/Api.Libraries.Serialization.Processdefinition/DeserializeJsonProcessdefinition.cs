using System.Text.Json;

namespace Api.Libraries.Serialization.Processdefinition
{
	public class DeserializeJsonProcessdefinition : IDeserializeJsonProcessdefinition
	{
		public Model.Processdefinition Deserialize(string json)
			=> JsonSerializer.Deserialize<Model.Processdefinition>(json);
	}
}
