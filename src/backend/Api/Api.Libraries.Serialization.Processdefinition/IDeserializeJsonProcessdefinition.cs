namespace Api.Libraries.Serialization.Processdefinition
{
	public interface IDeserializeJsonProcessdefinition
	{
		Model.Processdefinition Deserialize(string json);
	}
}
