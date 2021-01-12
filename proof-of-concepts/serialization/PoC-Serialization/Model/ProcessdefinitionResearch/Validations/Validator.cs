namespace PoC_Serialization.Model.ProcessdefinitionResearch.Validations
{
    public abstract class Validator : IValidationType
    {
        public abstract bool IsValid(object? input, ValidationOptions options);
        public abstract string ValidationTypeName { get; }
    }

    public abstract class Validator<TValueType, TValidationOptions> : Validator
        where TValidationOptions : class, IValidationOptions
    {
        public abstract bool IsValid(TValueType input, TValidationOptions options);
    }
}