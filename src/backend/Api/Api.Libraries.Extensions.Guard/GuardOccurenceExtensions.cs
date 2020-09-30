using System;
using System.Linq;
using Ardalis.GuardClauses;

namespace Api.Libraries.Extensions.Guard
{
	public static class GuardOccurenceExtensions
	{
		public static void ExactOccurence(this IGuardClause guardClause, string input, string parameterName, char occurenceCharacter, int occurence)
		{
			if (input.Count(c => c == occurenceCharacter) != occurence)
			{
				throw new ArgumentException("Only one semilcolon allowed", parameterName);
			}
		}
	}
}
