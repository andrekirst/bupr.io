using System;
using System.Collections.Generic;
using PoC_Serialization.Model.Ids;

namespace PoC_Serialization.Model.ProcessinstanceResearch
{
    public class Hierarchy : IHasStatus, IHasChilds<HierarchyItem>, IHasParent
    {
        public List<HierarchyItem> Items { get; set; } = new List<HierarchyItem>();
        
        public StatusId CurrentStatusId { get; set; }
        public void SetStatus(StatusId statusId)
        {
            throw new System.NotImplementedException();
        }

        public IHasParent? Parent { get => null; set => throw new ArgumentException(); }
    }
}