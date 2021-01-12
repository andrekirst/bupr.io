#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using PoC_Serialization.Model.ProcessdefinitionResearch;
using PoC_Serialization.Model.ProcessdefinitionResearch.Validations;

namespace PoC_Serialization
{
    public class PropertyValidator : IPropertyValidator
    {
        private readonly IEnumerable<Validator> _validators;
        private readonly IStatusIdentificationMapper _statusIdentificationMapper;

        public PropertyValidator(
            IEnumerable<Validator> validators,
            IStatusIdentificationMapper statusIdentificationMapper)
        {
            _validators = validators;
            _statusIdentificationMapper = statusIdentificationMapper;
        }
        
        public PropertyValidationResult Validate(Property property, object? value, Processdefinition processdefinition)
        {
            if (property.Value == null) throw new ArgumentNullException(nameof(property.Value));
            
            var propertyValue = property.Value!;

            if (propertyValue.Rules == null) throw new ArgumentNullException(nameof(propertyValue.Rules));

            var statusId = _statusIdentificationMapper.Map(property.DefaultStatus, processdefinition);
            
            foreach (var rule in propertyValue.Rules.Where(r => r.ValidationOptions != null).OrderBy(r => r.Order))
            {
                var validator = _validators.FirstOrDefault(v => v.ValidationTypeName == rule.ValidationOptions!.ValidationTypeName);

                if (validator == null)
                {
                    throw new ArgumentNullException($"Did not find validation with name {rule.ValidationOptions!.ValidationTypeName}");
                }

                var successful = validator.IsValid(value, rule.ValidationOptions!);

                statusId = _statusIdentificationMapper.Map(successful ? rule.TargetStatus : rule.StatusOnValidationFailure, processdefinition);

                if (!successful)
                {
                    return new PropertyValidationResult
                    {
                        Successful = false,
                        AffectedValidation = rule.ValidationOptions!,
                        Value = value,
                        AffectedStatusId = statusId
                    };
                }
            }

            return new PropertyValidationResult
            {
                Successful = true,
                AffectedStatusId = statusId
            };
        }
    }
}