using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;

namespace Api.Libraries.Extensions.Guard
{
	public static class GuardStringListExtensions
	{
		public static void SplittedValues(this IGuardClause guardClause, string input, string parameterName,
			char splitCharacter, IList<string> validValues)
		{
			var values = input.Split(splitCharacter, StringSplitOptions.RemoveEmptyEntries);
			foreach (var value in values)
			{
				if (!validValues.Contains(value))
				{
					throw new ArgumentException($"{value} is not a valid value", parameterName);
				}
			}
		}
	}
}
