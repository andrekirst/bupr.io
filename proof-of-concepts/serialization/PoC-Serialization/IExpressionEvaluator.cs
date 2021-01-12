using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using PoC_Serialization.Model.ProcessdefinitionResearch;

namespace PoC_Serialization
{
    public interface IExpressionEvaluator
    {
        bool Evaluate(string validationExpression);
    }

    public class ExpressionEvaluator : IExpressionEvaluator
    {
        private readonly IEnumerable<Function> _functions;
        private readonly IEnumerable<Variable> _variables;

        public ExpressionEvaluator(IEnumerable<Function> functions, IEnumerable<Variable> variables)
        {
            _functions = functions;
            _variables = variables;
        }

        public bool Evaluate(string validationExpression)
        {
            Tokenizer tokenizer = new Tokenizer(_functions, _variables.Select(s => s.VariableName));
            var tokens = tokenizer.Tokenize(validationExpression);

            var isEmptyFunction = new IsEmptyFunction();
            
            var f = Expression.Not(Expression.Call(isEmptyFunction, _variables.First()));
            var f2 = f.Reduce();
            // Not(IsNullOrEmpty("André"))
            var x = Expression.Lambda<Func<bool>>(f).Compile()();

            //var expression = Expression.Call(isEmptyFunction.GetMethodInfo(),
            //    _variables.First().GetConstantExpression());

            //var x = Expression.Lambda<Func<bool>>(expression).Compile()();

            return false;
        }
    }

    public class Tokenizer
    {
        private readonly List<TokenDefinition> _tokenDefinitions;

        public Tokenizer(IEnumerable<Function> functions, IEnumerable<VariableName> variables)
        {
            var functionNames = functions.Select(f => $"^{f.FunctionName.Name}");
            var parameterNames = (from function in functions from parameter in function.Parameters select $"^{parameter.Name.Value}").Distinct().ToList();
            var variableNames = variables.Select(f => $"^{f.Name}");

            _tokenDefinitions = new List<TokenDefinition>
            {
                new TokenDefinition(TokenType.And, @"^\&\&"),
                new TokenDefinition(TokenType.Or, @"^\|\|"),
                new TokenDefinition(TokenType.Negate, @"^\!"),
                new TokenDefinition(TokenType.Functionname, $"{string.Join("|", functionNames)}"),
                new TokenDefinition(TokenType.Parameter, $"{string.Join("|", parameterNames)}"),
                new TokenDefinition(TokenType.ParameterValue, $"{string.Join("|", variableNames)}"),
                new TokenDefinition(TokenType.OpenRoundBracket, @"^\("),
                new TokenDefinition(TokenType.ClosedRoundBracket, @"^\)")
            };
        }
        
        // https://jack-vanlightly.com/blog/2016/2/3/creating-a-simple-tokenizer-lexer-in-c
        public List<DslToken> Tokenize(string text)
        {
            var tokens = new List<DslToken>();
            var remainingText = text;

            while (!string.IsNullOrWhiteSpace(remainingText))
            {
                var match = FindMatch(remainingText);
                if (match.IsMatch)
                {
                    tokens.Add(new DslToken(match.TokenType, match.Value));
                    remainingText = match.RemainingText;
                }
                else
                {
                    if (IsWhitespace(remainingText))
                    {
                        remainingText = remainingText[1..];
                    }
                    else
                    {
                        var invalidTokenMatch = CreateInvalidTokenMatch(remainingText);
                        tokens.Add(new DslToken(invalidTokenMatch.TokenType, invalidTokenMatch.Value));
                        remainingText = invalidTokenMatch.RemainingText;
                    }
                }
            }
            
            tokens.Add(new DslToken(TokenType.SequenceTerminator, string.Empty));

            return tokens;
        }

        private TokenMatch CreateInvalidTokenMatch(string text)
        {
            var match = Regex.Match(text, "(^\\S+\\s)|^\\S+");
            
            return match.Success
                ? new TokenMatch
                {
                    IsMatch = true,
                    RemainingText = text[match.Length..],
                    TokenType = TokenType.Invalid,
                    Value = match.Value.Trim()
                }
                : throw new DslParserException("Failed to generate invalid token");
        }

        private bool IsWhitespace(string text) => Regex.IsMatch(text, "^\\s+");

        private TokenMatch FindMatch(string text)
        {
            foreach (var match in _tokenDefinitions.Select(tokenDefinition => tokenDefinition.Match(text)).Where(match => match.IsMatch))
            {
                return match;
            }

            return TokenMatch.NoMatch;
        }
    }

    internal class DslParserException : Exception
    {
        public DslParserException(string message)
            : base(message)
        {
        }
    }

    public class TokenDefinition
    {
        private readonly TokenType _returnsToken;
        private readonly Regex _regex;

        public TokenDefinition(TokenType returnsToken, [RegexPattern] string regexPattern)
        {
            _regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            _returnsToken = returnsToken;
        }

        public TokenMatch Match(string inputString)
        {
            var match = _regex.Match(inputString);
            if (match.Success)
            {
                var remainingText = string.Empty;
                if (match.Length != inputString.Length)
                {
                    remainingText = inputString[match.Length..];
                }

                return new TokenMatch
                {
                    IsMatch = true,
                    RemainingText = remainingText,
                    TokenType = _returnsToken,
                    Value = match.Value
                };
            }

            return TokenMatch.NoMatch;
        }

        public override string ToString() => $"{_returnsToken} - {_regex}";
    }

    public class TokenMatch
    {
        public bool IsMatch { get; set; }
        public string? RemainingText { get; set; }
        public TokenType TokenType { get; set; }
        public string? Value { get; set; }

        public static TokenMatch NoMatch => new TokenMatch { IsMatch = false };

        public override string ToString() => $"IsMatch: {IsMatch}, RemainingText: \"{RemainingText}\", TokenType: {TokenType}, Value: \"{Value}\"";
    }

    public class DslToken
    {
        public TokenType TokenType { get; }
        public string Value { get; }

        public DslToken(TokenType tokenType, string? value)
        {
            TokenType = tokenType;
            Value = value ?? string.Empty;
        }

        public DslToken Clone() => new DslToken(TokenType, Value);

        public override string ToString() => $"{TokenType} - \"{Value}\"";
    }

    public enum TokenType
    {
        NoToken = 0,
        SequenceTerminator = 1,
        Invalid = 2,
        Negate,
        Functionname,
        Parameter,
        And,
        Or,
        BitAnd,
        BitOr,
        OpenRoundBracket,
        ClosedRoundBracket,
        ParameterValue
    }
}