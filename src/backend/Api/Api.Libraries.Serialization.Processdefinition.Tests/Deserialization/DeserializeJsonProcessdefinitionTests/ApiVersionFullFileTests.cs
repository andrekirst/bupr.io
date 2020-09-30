using Api.Libraries.Serialization.Processdefinition.Model;
using Shouldly;
using Xunit;

namespace Api.Libraries.Serialization.Processdefinition.Tests.Deserialization.DeserializeJsonProcessdefinitionTests
{
	[Trait("Class", nameof(ApiVersion))]
	public class ApiVersionFullFileTests : FullFileTest
	{
		private readonly DeserializeJsonProcessdefinition _systemUnderTest;

		public ApiVersionFullFileTests()
		{
			_systemUnderTest = new DeserializeJsonProcessdefinition();
		}

		[Fact(DisplayName = "Expect Api-Text: \"processdefinition\"")]
		public void ExpectApiTextProcessdefinition()
		{
			var json = GetJson();
			var actual = _systemUnderTest.Deserialize(json);

			actual.ApiVersion.Api.ShouldBe("processdefinition");
		}

		[Fact(DisplayName = "Expect Version-Text: \"v1\"")]
		public void ExpectVersionTextV1()
		{
			var json = GetJson();
			var actual = _systemUnderTest.Deserialize(json);

			actual.ApiVersion.Version.ShouldBe("v1");
		}

		[Fact(DisplayName = "Expect FullText: \"processdefinition:v1\"")]
		public void ExpectFullTextProcessdefinitionV1()
		{
			var json = GetJson();
			var actual = _systemUnderTest.Deserialize(json);

			actual.ApiVersion.FullText.ShouldBe("processdefinition:v1");
		}
	}
}
