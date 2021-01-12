using System.Collections.Generic;
using PoC_Serialization.Model.ProcessdefinitionResearch;
using PoC_Serialization.Model.ProcessinstanceResearch;

namespace PoC_Serialization
{
    public class ProcessinstanceEngine : IProcessinstanceEngine
    {
        private readonly IPropertyValidator _propertyValidator;
        private readonly List<IHasStatus> _statusList = new List<IHasStatus>();

        public ProcessinstanceEngine(
            IPropertyValidator propertyValidator)
        {
            _propertyValidator = propertyValidator;
        }
        
        public Processinstance SetValue(Processinstance processinstance, Processdefinition processdefinition, string propertyName, string? value)
        {
            var property = processdefinition.FindPropertyByName(propertyName);

            if (property == null)
            {
                throw new PropertyNotFoundException(propertyName);
            }
            
            // #1 - Validate property
            var propertyValidationResult = _propertyValidator.Validate(property, value, processdefinition);
            
            // #2 - What ever - save the value
            processinstance.SetRawValue(propertyName, value);

            var statusId = propertyValidationResult.AffectedStatusId;

            processinstance.SetStatus(property.Id, statusId);
            processinstance.SetStatusRecursive(property.Id, statusId);
            
            // #3 Set Status in Hierarchy

            return processinstance;
        }
    }
}