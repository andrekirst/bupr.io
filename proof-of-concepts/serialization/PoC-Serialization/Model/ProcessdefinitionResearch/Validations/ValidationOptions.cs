namespace PoC_Serialization.Model.ProcessdefinitionResearch.Validations
{
    public abstract class ValidationOptions : IValidationOptions
    {
        public abstract string ValidationTypeName { get; }
    }
}