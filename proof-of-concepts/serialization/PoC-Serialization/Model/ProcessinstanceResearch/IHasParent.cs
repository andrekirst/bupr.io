using PoC_Serialization.Model.Ids;

namespace PoC_Serialization.Model.ProcessinstanceResearch
{
    public interface IHasParent
    {
        void SetStatus(StatusId statusId);

        IHasParent? Parent { get; set; }
    }
}