using PoC_Serialization.Model.Ids;

namespace PoC_Serialization.Model.ProcessinstanceResearch
{
    public interface IHasStatus
    {
        StatusId CurrentStatusId { get; set; }
    }
}