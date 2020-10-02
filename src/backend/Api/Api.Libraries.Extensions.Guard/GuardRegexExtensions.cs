using System;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using JetBrains.Annotations;

namespace Api.Libraries.Extensions.Guard
{
	public static class GuardRegexExtensions
	{
		public static void NotMatchRegex(this IGuardClause guardClause, string input, string parameterName, [RegexPattern] string regexPattern)
		{
			if (!Regex.IsMatch(input, regexPattern))
			{
				throw new ArgumentException($"{input} does not match pattern \"{regexPattern}\"", parameterName);
			}
		}
	}
}
