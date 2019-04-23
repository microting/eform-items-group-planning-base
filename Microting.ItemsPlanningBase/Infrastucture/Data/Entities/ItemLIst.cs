using System.Collections.Generic;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.ItemsPlanningBase.Infrastucture.Data.Entities
{
    public class ItemLIst : BaseEntity
    {               
        
        public ItemLIst()
        {
            this.Items = new HashSet<Item>();
        }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool Enabled { get; set; }
        
        public int RelatedeFormId { get; set; }
        
        public string RelatedeFormName { get; set; }
        
        public int RepeatedType { get; set; }
        
        public virtual ICollection<Item> Items { get; set; }
    }
}