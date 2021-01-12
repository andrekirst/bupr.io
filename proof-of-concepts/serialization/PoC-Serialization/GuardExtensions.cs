using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using JetBrains.Annotations;

namespace PoC_Serialization
{
    public static class GuardExtensions
    {
        public static void NotMatchRegex(this IGuardClause guardClause, string input, string parameterName, [RegexPattern] string regexPattern)
        {
            if (!Regex.IsMatch(input, regexPattern))
            {
                throw new ArgumentException($"{input} does not match pattern \"{regexPattern}\"", parameterName);
            }
        }

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

        public static void NotInValuelist(this IGuardClause guardClause, string input, string parameterName,
            IList<string> validValues)
        {
            if (!validValues.Contains(input))
            {
                throw new ArgumentException($"{input} is not a valid value", parameterName);
            }
        }
    }
}