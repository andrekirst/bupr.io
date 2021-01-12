namespace PoC_Serialization.Model.ProcessdefinitionResearch.Validations
{
    public class MinLengthValidator : Validator<string, MinLengthValidationOptions>
    {
        public override bool IsValid(object? input, ValidationOptions options) => IsValid((string)input!, (options as MinLengthValidationOptions)!);

        public override bool IsValid(string? input, MinLengthValidationOptions options) => input?.Length >= options.MinLength;

        public override string ValidationTypeName => "MinLength";
    }

    public class MinLengthValidationOptions : ValidationOptions
    {
        public int MinLength { get; }

        public MinLengthValidationOptions(int minLength)
        {
            MinLength = minLength;
        }

        public override string ValidationTypeName => "MinLength";

        public override string ToString() => MinLength.ToString();
    }
}