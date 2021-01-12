using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.ProcessdefinitionResearch;
using PoC_Serialization.Model.ProcessdefinitionResearch.Validations;

namespace PoC_Serialization
{
    public interface IPropertyValidator
    {
        PropertyValidationResult Validate(Property property, object? value, Processdefinition processdefinition);
    }

    public class PropertyValidationResult
    {
        public bool Successful { get; set; }
        public ValidationOptions? AffectedValidation { get; set; }
        public object? Value { get; set; }
        public StatusId AffectedStatusId { get; set; }

        public override string ToString() => Successful ? $"✔" : $"🛑 {AffectedValidation?.ValidationTypeName}";
    }
}