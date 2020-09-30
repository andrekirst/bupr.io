using System.IO;

namespace Api.Libraries.Serialization.Processdefinition.Tests.Deserialization
{
	public class FullFileTest
	{
		protected string GetJson() => File.ReadAllText("Files\\FullFile_v1.json");
	}
}
