namespace PoC_Serialization.Model.ProcessdefinitionResearch.Validations
{
    public class MaxLengthValidator : Validator<string, MaxLengthValidationOptions>
    {
        public override bool IsValid(object? input, ValidationOptions options) => IsValid((string)input!, (options as MaxLengthValidationOptions)!);

        public override bool IsValid(string? input, MaxLengthValidationOptions options) => input?.Length <= options.MaxLength;

        public override string ValidationTypeName => "MaxLength";
    }

    public class MaxLengthValidationOptions : ValidationOptions
    {
        public int MaxLength { get; }

        public MaxLengthValidationOptions(int maxLength)
        {
            MaxLength = maxLength;
        }
        
        public override string ValidationTypeName => "MaxLength";

        public override string ToString() => MaxLength.ToString();
    }
}