using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.ItemsPlanningBase.Infrastucture.Data.Entities
{
    public class ItemsPlanningPnSettingVersion : BaseEntity
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Value { get; set; }

        [ForeignKey("TrashInspectionPnSetting")]
        public int TrashInspectionPnSettingId { get; set; }
        
        public int Version { get; set; }
    }
}