namespace PoC_Serialization.Model.ProcessdefinitionResearch.Validations
{
    public class IsRequiredValidator : Validator<object, IsRequiredValidationOptions>
    {
        public override bool IsValid(object? input, IsRequiredValidationOptions options) => input != null;

        public override string ValidationTypeName => "IsRequired";

        public override bool IsValid(object? value, ValidationOptions options) => IsValid(value, (options as IsRequiredValidationOptions)!);

        public override string ToString() => nameof(IsRequiredValidator);
    }

    public class IsRequiredValidationOptions : ValidationOptions
    {
        public override string ValidationTypeName => "IsRequired";
    }
}