using System;
using Api.Libraries.Serialization.Processdefinition.Model;
using Xunit;

namespace Api.Libraries.Serialization.Processdefinition.Tests.Deserialization.DeserializeJsonProcessdefinitionTests
{
	[Trait("Class", nameof(Kind))]
	public class KindNegativeTests
	{
		private readonly DeserializeJsonProcessdefinition _systemUnderTest = new DeserializeJsonProcessdefinition();

		[Fact(DisplayName = "Kind can not be null")]
		public void CanNotBeNull()
		{
			var actual = _systemUnderTest.Deserialize("{}");

			Assert.Null(actual.Kind);
		}

		[Fact(DisplayName = "Kind can not be empty")]
		public void CanNotBeEmpty()
		{
			Assert.Throws<ArgumentException>(() => _systemUnderTest.Deserialize("{\"kind\":\"\"}"));
		}
	}
}
