using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.JsonConverters;
using PoC_Serialization.Model.ProcessdefinitionResearch;
using PoC_Serialization.Model.ProcessdefinitionResearch.Validations;

namespace PoC_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var processdefinition = new Processdefinition
            {
                Name = new Name
                {
                    Names = new List<LanguageName?>
                    {
                        LanguageName.For(LanguageKey.Deutsch, "Bewerberverwaltung"),
                        LanguageName.For(LanguageKey.English, "Applicant management")
                    }
                },
                Version = "1",
                StatusList = new StatusList
                {
                    Items = new List<Status>
                    {
                        new Status
                        {
                            Name = new Name
                            {
                                Names = new List<LanguageName?>
                                {
                                    LanguageName.For(LanguageKey.Deutsch, "Grün"),
                                    LanguageName.For(LanguageKey.English, "Green")
                                }
                            },
                            Type = StatusType.Success,
                            InternalName = "green",
                            StatusId = new StatusId()
                        },
                        new Status
                        {
                            Name = new Name
                            {
                                Names = new List<LanguageName?>
                                {
                                    LanguageName.For(LanguageKey.Deutsch, "Gelb"),
                                    LanguageName.For(LanguageKey.English, "Yellow")
                                }
                            },
                            Type = StatusType.Warning,
                            InternalName = "yellow",
                            StatusId = new StatusId()
                        },
                        new Status
                        {
                            Name = new Name
                            {
                                Names = new List<LanguageName?>
                                {
                                    LanguageName.For(LanguageKey.Deutsch, "Rot"),
                                    LanguageName.For(LanguageKey.English, "Red")
                                }
                            },
                            Type = StatusType.Error,
                            InternalName = "red",
                            StatusId = new StatusId()
                        }
                    }
                },
                ApiVersion = new ApiVersion("ProcessDefinition:v1"),
                IsEnabled = true,
                Kind = Kind.ProcessDefinition,
                ProcessdefinitionId = new ProcessdefinitionId(),
                Hierarchy = new Hierarchy
                {
                    Hierarchies = new List<HierarchyItem>
                    {
                        new HierarchyItem
                        {
                            Id = new HierarchyItemId(),
                            Level = 1,
                            Sections = new List<Section>
                            {
                                new Section
                                {
                                    Id = new SectionId(),
                                    Order = 1,
                                    Name = new Name
                                    {
                                        Names = new List<LanguageName?>
                                        {
                                            LanguageName.For(LanguageKey.Deutsch, "Persönliche Informationen"),
                                            LanguageName.For(LanguageKey.English, "Personal information")
                                        }
                                    },
                                    Controls = new List<Control>
                                    {
                                        new Control
                                        {
                                            ControlId = new ControlId(),
                                            Type = new ControlType("label-text"),
                                            TechnicalName = new TechnicalName("control-firstname"),
                                            Properties = new List<Property>
                                            {
                                                new Property
                                                {
                                                    Id = new PropertyId(),
                                                    TechnicalName = new TechnicalName("label-firstname"),
                                                    DefaultStatus = "notset",
                                                    Value = new PropertyValue
                                                    {
                                                        TargetName = "label1",
                                                        NameValue = new Name
                                                        {
                                                            Names = new List<LanguageName?>
                                                            {
                                                                LanguageName.For(LanguageKey.Deutsch, "Vorname"),
                                                                LanguageName.For(LanguageKey.English, "First name")
                                                            }
                                                        }
                                                    }
                                                },
                                                new Property
                                                {
                                                    Id = new PropertyId(),
                                                    TechnicalName = "text-firstname",
                                                    DefaultStatus = "red",
                                                    Value = new PropertyValue
                                                    {
                                                        TargetName = "text1",
                                                        VariableName = new VariableName("firstname"),
                                                        VariableType = "string",
                                                        Rules = new List<Rule>
                                                        {
                                                            new Rule
                                                            {
                                                                TargetStatus = "green",
                                                                ValidationOptions = new IsRequiredValidationOptions(),
                                                                StatusOnValidationFailure = "red",
                                                                Order = 1
                                                            },
                                                            new Rule
                                                            {
                                                                TargetStatus = "green",
                                                                ValidationOptions = new MinLengthValidationOptions(1),
                                                                StatusOnValidationFailure = "red",
                                                                Order = 2
                                                            },
                                                            new Rule
                                                            {
                                                                TargetStatus = "green",
                                                                ValidationOptions = new MaxLengthValidationOptions(256),
                                                                StatusOnValidationFailure = "red",
                                                                Order = 3
                                                            },
                                                            new Rule
                                                            {
                                                                TargetStatus = "green",
                                                                ValidationOptions = new MustMatchRegexValidationOptions(@"^[A-Z]{1,}[a-zA-Z0-9À-ž]{1,}$"),
                                                                StatusOnValidationFailure = "red",
                                                                Order = 4
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        new Control
                                        {
                                            ControlId = new ControlId(),
                                            Type = new ControlType("label-text"),
                                            TechnicalName = new TechnicalName("control-lastname"),
                                            Properties = new List<Property>
                                            {
                                                new Property
                                                {
                                                    Id = new PropertyId(),
                                                    TechnicalName = new TechnicalName("label-lastname"),
                                                    DefaultStatus = "red",
                                                    Value = new PropertyValue
                                                    {
                                                        TargetName = "label1",
                                                        NameValue = new Name
                                                        {
                                                            Names = new List<LanguageName?>
                                                            {
                                                                LanguageName.For(LanguageKey.Deutsch, "Nachanme"),
                                                                LanguageName.For(LanguageKey.English, "Last name")
                                                            }
                                                        }
                                                    }
                                                },
                                                new Property
                                                {
                                                    Id = new PropertyId(),
                                                    TechnicalName = "text-lastname",
                                                    Value = new PropertyValue
                                                    {
                                                        TargetName = "text1",
                                                        VariableName = new VariableName("lastname"),
                                                        VariableType = "string",
                                                        Rules = new List<Rule>
                                                        {
                                                            new Rule
                                                            {
                                                                TargetStatus = "green",
                                                                ValidationOptions = new IsRequiredValidationOptions(),
                                                                StatusOnValidationFailure = "red",
                                                                Order = 1
                                                            },
                                                            new Rule
                                                            {
                                                                TargetStatus = "green",
                                                                ValidationOptions = new MinLengthValidationOptions(1),
                                                                StatusOnValidationFailure = "red",
                                                                Order = 2
                                                            },
                                                            new Rule
                                                            {
                                                                TargetStatus = "green",
                                                                ValidationOptions = new MaxLengthValidationOptions(256),
                                                                StatusOnValidationFailure = "red",
                                                                Order = 3
                                                            },
                                                            new Rule
                                                            {
                                                                TargetStatus = "green",
                                                                ValidationOptions = new MustMatchRegexValidationOptions(@"^[A-Z]{1,}[a-zA-Z0-9À-ž]{1,}$"),
                                                                StatusOnValidationFailure = "red",
                                                                Order = 4
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        new Control
                                        {
                                            ControlId = new ControlId(),
                                            Type = new ControlType("label-date"),
                                            TechnicalName = new TechnicalName("control-birthday"),
                                            Properties = new List<Property>
                                            {
                                                new Property
                                                {
                                                    Id = new PropertyId(),
                                                    TechnicalName = new TechnicalName("label-birthday"),
                                                    Value = new PropertyValue
                                                    {
                                                        TargetName = "label1",
                                                        NameValue = new Name
                                                        {
                                                            Names = new List<LanguageName?>
                                                            {
                                                                LanguageName.For(LanguageKey.Deutsch, "Geburtsdatum"),
                                                                LanguageName.For(LanguageKey.English, "Date of birth")
                                                            }
                                                        }
                                                    }
                                                },
                                                new Property
                                                {
                                                    Id = new PropertyId(),
                                                    TechnicalName = "date-birthday",
                                                    Value = new PropertyValue
                                                    {
                                                        TargetName = "date1",
                                                        VariableName = new VariableName("birthday"),
                                                        VariableType = "date",
                                                        Rules = new List<Rule>
                                                        {
                                                            new Rule
                                                            {
                                                                TargetStatus = "green",
                                                                ValidationOptions = new IsRequiredValidationOptions(),
                                                                StatusOnValidationFailure = "red",
                                                                Order = 1
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            Name = new Name
                            {
                                Names = new List<LanguageName?>
                                {
                                    LanguageName.For(LanguageKey.Deutsch, "Allgemein"),
                                    LanguageName.For(LanguageKey.English, "Common")
                                }
                            }
                        }
                    }
                }
            };

            var processdefinitionValidations = new List<ProcessdefinitionValidation>
            {
                new ProcessdefinitionValidationUniqueVariableNames()
            };
            ProcessdefinitionValidator processDefinitionValidator = new ProcessdefinitionValidator(processdefinitionValidations);
            processDefinitionValidator.Validate(processdefinition);

            var processinstanceFactory = new ProcessinstanceFactory(processDefinitionValidator);
            var processinstance = processinstanceFactory.Create(processdefinition);
            
            var validators = new List<Validator>
            {
                new IsRequiredValidator(),
                new MinLengthValidator(),
                new MustMatchRegexValidator(),
                new MaxLengthValidator()
            };

            var propertyValidator = new PropertyValidator(validators, new StatusIdentificationMapper());

            var engine = new ProcessinstanceEngine(propertyValidator);
            engine.SetValue(processinstance, processdefinition, "text-firstname", "André");

            var jsonAsByte = JsonSerializer.SerializeToUtf8Bytes(processdefinition, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                DefaultBufferSize = 4096,
                Converters =
                {
                    new ValidationTypeConverter<ValidationOptions>()
                }
            });

            var json = Encoding.UTF8.GetString(jsonAsByte);

            Console.WriteLine(json);
        }
    }
}
