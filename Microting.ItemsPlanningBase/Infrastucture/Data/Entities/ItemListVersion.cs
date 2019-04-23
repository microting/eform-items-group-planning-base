using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.ItemsPlanningBase.Infrastucture.Data.Entities
{
    public class ItemListVersion : BaseEntity
    {                              
        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool Enabled { get; set; }
        
        public int RelatedeFormId { get; set; }
        
        public string RelatedeFormName { get; set; }
        
        public int RepeatedType { get; set; }
        
        [ForeignKey("ItemList")]
        public int ItemList { get; set; }
        
    }
}