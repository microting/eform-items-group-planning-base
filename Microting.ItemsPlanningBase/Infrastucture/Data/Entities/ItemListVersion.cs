using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.ItemsPlanningBase.Infrastucture.Data.Entities
{
    public class ItemListVersion : BaseEntity
    {                              
        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool Enabled { get; set; }
        
        public int RelatedeFormId { get; set; }
        
        public string RelatedeFormName { get; set; }
        
        [ForeignKey("ItemList")]
        public int ItemList { get; set; }
        
    }
}