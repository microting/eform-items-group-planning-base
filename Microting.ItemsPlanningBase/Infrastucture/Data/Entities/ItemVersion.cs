using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.ItemsPlanningBase.Infrastucture.Data.Entities
{
    public class ItemVersion : BaseEntity
    {
        public string Sku { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool Enabled { get; set; }
        
        public string RepeatType { get; set; }        
        
        [ForeignKey("Item")]
        public int ItemId { get; set; }
    }
}