using System;
using Xunit;

namespace Api.Libraries.Extensions.Guard.Tests
{
	[Trait("Class", "Guard")]
	public class NotMatchRegexTests
	{
		[Fact(DisplayName = @"Input is ""1"" and the regex pattern is ""\d"". Expect that the Function does not throw an Exception")]
		public void Input1MatchesRegexOnlyOneDigitExpectNoException()
		{
			Ardalis.GuardClauses.Guard.Against.NotMatchRegex("1", nameof(Input1MatchesRegexOnlyOneDigitExpectNoException), @"\d");
		}

		[Fact(DisplayName = @"Input is ""1"" and the regex pattern is ""[a-z]"". Expect an ArgumentException")]
		public void Input1DoesNotMatchWithRegexaTozExpectArgumentException()
		{
			Assert.Throws<ArgumentException>(() =>
				Ardalis.GuardClauses.Guard.Against.NotMatchRegex("1",
					nameof(Input1DoesNotMatchWithRegexaTozExpectArgumentException), @"[a-z]"));
			;
		}
	}
}
