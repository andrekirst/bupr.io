using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using PoC_Serialization.Model.ProcessdefinitionResearch;
using PoC_Serialization.Model.ProcessinstanceResearch;
using HierarchyItem = PoC_Serialization.Model.ProcessinstanceResearch.HierarchyItem;
using Section = PoC_Serialization.Model.ProcessinstanceResearch.Section;

namespace PoC_Serialization
{
    public class ProcessinstanceFactory
    {
        private readonly ProcessdefinitionValidator _processDefinitionValidator;

        public ProcessinstanceFactory(
            // TODO Ersetzen durch Middlware-Mechanismus
            ProcessdefinitionValidator processDefinitionValidator)
        {
            _processDefinitionValidator = processDefinitionValidator;
        }
        
        public Processinstance Create(Processdefinition processdefinition)
        {
            _processDefinitionValidator.Validate(processdefinition);

            var jsonAsByte = JsonSerializer.SerializeToUtf8Bytes(processdefinition, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var json = Encoding.UTF8.GetString(jsonAsByte);
            var data = CreateEmptyData(processdefinition);

            return new Processinstance
            {
                ProcessDefinitionAsJson = json,
                Data = data
            };
        }

        private Model.ProcessinstanceResearch.Hierarchy CreateEmptyData(Processdefinition processdefinition)
        {
            var hierarchy = new Model.ProcessinstanceResearch.Hierarchy();

            foreach (var hierarchyItem in processdefinition.Hierarchy.Hierarchies)
            {
                // TODO Rekursion

                var sectionsCopy = new List<Section>();

                foreach (var section in hierarchyItem.Sections)
                {
                    var sectionCopy = new Section
                    {
                        Id = section.Id,
                        Parent = hierarchyItem
                    };

                    foreach (var sectionControl in section.Controls)
                    {
                        var controlCopy = new Model.ProcessinstanceResearch.Control
                        {
                            ControlId = sectionControl.ControlId,
                            Parent = sectionCopy
                        };

                        foreach (var sectionControlProperty in sectionControl.Properties)
                        {
                            var propertyCopy = new Model.ProcessinstanceResearch.Property
                            {
                                PropertyId = sectionControlProperty.Id,
                                Parent = controlCopy,
                                Value = null
                            };
                            controlCopy.Properties.Add(propertyCopy);
                        }
                        sectionCopy.Controls.Add(controlCopy);
                    }
                    sectionsCopy.Add(sectionCopy);
                }

                hierarchy.Items.Add(new Model.ProcessinstanceResearch.HierarchyItem
                {
                    Id = hierarchyItem.Id,
                    Sections = sectionsCopy,
                    Parent = hierarchy
                });
            }

            return hierarchy;
        }

        //private Model.ProcessinstanceResearch.Hierarchy CreateSubTreeWithNoData(HierarchyItem hierarchyItem)
        //{

        //}
    }
}