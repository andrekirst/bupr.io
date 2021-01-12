using System.Collections.Generic;
using PoC_Serialization.Model.ProcessdefinitionResearch;

namespace PoC_Serialization
{
    public class ProcessdefinitionValidator
    {
        private readonly IEnumerable<ProcessdefinitionValidation> _processDefinitionValidations;

        public ProcessdefinitionValidator(IEnumerable<ProcessdefinitionValidation> processDefinitionValidations)
        {
            _processDefinitionValidations = processDefinitionValidations;
        }

        public void Validate(Processdefinition processdefinition)
        {
            foreach (var processDefinitionValidation in _processDefinitionValidations)
            {
                processDefinitionValidation.Validate(processdefinition);
            }
        }
    }
}