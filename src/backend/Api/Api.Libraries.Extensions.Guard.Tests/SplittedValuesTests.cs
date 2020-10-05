using System;
using System.Collections.Generic;
using Xunit;

namespace Api.Libraries.Extensions.Guard.Tests
{
	[Trait("Class", "Guard")]
	public class SplittedValuesTests
	{
		[Fact]
		public void InputIsLabelTextTextWithStrokesExpectNoArgumentException()
		{
			Ardalis.GuardClauses.Guard.Against.SplittedValues(
				"label-text-text",
				nameof(InputIsLabelTextTextWithStrokesExpectNoArgumentException),
				'-', new List<string> {"label", "text"});
		}

		[Fact]
		public void InputIsLabelTextTextWithColonsButSplitcharIsStrokeExpectArgumentException()
		{
			Assert.Throws<ArgumentException>(() => Ardalis.GuardClauses.Guard.Against.SplittedValues(
					"label:text:text",
					nameof(InputIsLabelTextTextWithStrokesExpectNoArgumentException),
					'-',
					new List<string> { "label", "text" }));
		}

		[Fact]
		public void InputIsLabelSplitcharIsStrokeExpectNoArgumentException()
		{
			Ardalis.GuardClauses.Guard.Against.SplittedValues(
				"label",
				nameof(InputIsLabelTextTextWithStrokesExpectNoArgumentException),
				'-',
				new List<string> { "label", "text" });
		}
	}
}
