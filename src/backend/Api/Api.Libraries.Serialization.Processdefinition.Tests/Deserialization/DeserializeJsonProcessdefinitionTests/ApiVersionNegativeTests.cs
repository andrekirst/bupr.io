using System;
using Api.Libraries.Serialization.Processdefinition.Model;
using Xunit;

namespace Api.Libraries.Serialization.Processdefinition.Tests.Deserialization.DeserializeJsonProcessdefinitionTests
{
	[Trait("Class", nameof(ApiVersion))]
	public class ApiVersionNegativeTests
	{
		private readonly DeserializeJsonProcessdefinition _systemUnderTest = new DeserializeJsonProcessdefinition();

		[Fact(DisplayName = "ApiVersion can not be null")]
		public void CanNotBeNull()
		{
			var actual = _systemUnderTest.Deserialize("{}");
			
			Assert.Null(actual.ApiVersion);
		}

		[Fact(DisplayName = "ApiVersion can not be empty")]
		public void CanNotBeEmpty()
		{
			Assert.Throws<ArgumentException>(() => _systemUnderTest.Deserialize("{\"apiVersion\":\"\"}"));
		}

		[Fact(DisplayName = "ApiVersion has wrong format with multiple colons")]
		public void CanNotHaveMultipleColons()
		{
			Assert.Throws<ArgumentException>(() => _systemUnderTest.Deserialize("{\"apiVersion\":\"api::version\"}"));
		}
	}
}
