using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace PoC_Serialization.Model.ProcessdefinitionResearch.Validations
{
    public class MustMatchRegexValidator : Validator<string, MustMatchRegexValidationOptions>
    {
        public override bool IsValid(object? input, ValidationOptions options) => IsValid((string)input!, (options as MustMatchRegexValidationOptions)!);
        public override string ValidationTypeName => "MustMatchRegex";

        public override bool IsValid(string? input, MustMatchRegexValidationOptions options) => input != null && Regex.IsMatch(input, options.RegexPattern);
    }

    public class MustMatchRegexValidationOptions : ValidationOptions
    {
        public string RegexPattern { get; set; }

        public MustMatchRegexValidationOptions([RegexPattern]string regexPattern)
        {
            RegexPattern = regexPattern;
        }

        public override string ToString() => RegexPattern;
        public override string ValidationTypeName => "MustMatchRegex";
    }
}