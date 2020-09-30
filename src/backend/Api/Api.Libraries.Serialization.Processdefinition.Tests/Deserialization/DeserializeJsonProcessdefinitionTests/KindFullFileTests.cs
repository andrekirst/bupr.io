using Api.Libraries.Serialization.Processdefinition.Model;
using Shouldly;
using Xunit;

namespace Api.Libraries.Serialization.Processdefinition.Tests.Deserialization.DeserializeJsonProcessdefinitionTests
{
	[Trait("Class", nameof(Kind))]
	public class KindFullFileTests : FullFileTest
	{
		private readonly DeserializeJsonProcessdefinition _systemUnderTest = new DeserializeJsonProcessdefinition();

		[Fact]
		public void ExpectTextProcessDefinition()
		{
			var json = GetJson();
			var actual = _systemUnderTest.Deserialize(json);
			actual.Kind.Value.ShouldBe("ProcessDefinition");
		}
	}
}
