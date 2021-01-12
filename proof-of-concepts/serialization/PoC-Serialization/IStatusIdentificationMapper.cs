#nullable enable
using System;
using System.Linq;
using PoC_Serialization.Model.Ids;
using PoC_Serialization.Model.ProcessdefinitionResearch;

namespace PoC_Serialization
{
    public interface IStatusIdentificationMapper
    {
        StatusId Map(StatusIdentification statusIdentification, Processdefinition processdefinition);
    }

    public class StatusIdentificationMapper : IStatusIdentificationMapper
    {
        public StatusId Map(StatusIdentification statusIdentification, Processdefinition processdefinition)
        {
            var value = processdefinition.StatusList.Items.FirstOrDefault(status =>
                status.StatusId?.Id == statusIdentification.Value ||
                status.InternalName == statusIdentification.Value)
                .StatusId;

            return value ?? throw new ArgumentNullException($"Could not find any Status for value \"{statusIdentification.Value}\"");
        }
    }
}