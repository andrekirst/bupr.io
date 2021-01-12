using System.Collections.Generic;
using System.Linq;
using PoC_Serialization.Model.ProcessdefinitionResearch;

namespace PoC_Serialization
{
    public class ProcessdefinitionValidationUniqueVariableNames : ProcessdefinitionValidation
    {
        public override void Validate(Processdefinition processdefinition)
        {
            var variableNames = new List<VariableName>();

            foreach (var variableName in GetVariables(processdefinition))
            {
                if (variableNames.Contains(variableName))
                {
                    throw new DuplicateVariableNameException(variableName.Name);
                }
                variableNames.Add(variableName);
            }
        }

        private IEnumerable<VariableName> GetVariables(Processdefinition processdefinition)
        {
            var hierarchy = processdefinition.Hierarchy;
            foreach (var variableName in hierarchy.Hierarchies.SelectMany(GetVariables))
            {
                yield return variableName;
            }
        }

        private IEnumerable<VariableName> GetVariables(HierarchyItem hierarchyItem)
        {
            if (hierarchyItem.Sections != null)
            {
                foreach (var section in hierarchyItem.Sections)
                {
                    foreach (var control in section.Controls)
                    {
                        foreach (var property in control.Properties)
                        {
                            if (property.Value != null && property.Value?.VariableName != null)
                            {
                                yield return property.Value.VariableName;
                            }
                        }
                    }
                } 
            }

            if (hierarchyItem.Items != null)
            {
                foreach (var variableName in hierarchyItem.Items.SelectMany(GetVariables))
                {
                    yield return variableName;
                } 
            }
        }
    }
}