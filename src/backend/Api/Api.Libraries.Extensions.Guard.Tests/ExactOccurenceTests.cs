using System;
using Xunit;

namespace Api.Libraries.Extensions.Guard.Tests
{
	[Trait("Class", "Guard")]
    public class ExactOccurenceTests
    {
        [Fact]
        public void TextWithOneColonOccurenceOneColon()
        {
			Ardalis.GuardClauses.Guard.Against.ExactOccurence("api:version", nameof(TextWithOneColonOccurenceOneColon), ':', 1);
        }

        [Fact]
        public void TextWithNoColonButExpectOneColon()
        {
	        Assert.Throws<ArgumentException>(() =>
		        Ardalis.GuardClauses.Guard.Against.ExactOccurence(
			        "apiversion",
			        nameof(TextWithNoColonButExpectOneColon),
			        ':', 
			        1));

        }

        [Fact]
        public void TextWithTwoColonsButExpectOneColon()
        {
	        Assert.Throws<ArgumentException>(() =>
		        Ardalis.GuardClauses.Guard.Against.ExactOccurence(
			        "api::version",
			        nameof(TextWithNoColonButExpectOneColon),
			        ':',
			        1));
        }
	}
}
