using System.ComponentModel.DataAnnotations;

namespace Microting.ItemsPlanningBase.Infrastucture.Data.Entities
{
    public class ItemsPlanningPnSetting : BaseEntity
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Value { get; set; }
        
        public int Version { get; set; }
    }
}