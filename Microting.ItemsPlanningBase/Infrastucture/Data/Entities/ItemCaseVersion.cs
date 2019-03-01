using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.ItemsPlanningBase.Infrastucture.Data.Entities
{
    public class ItemCaseVersion : BaseEntity
    {
        public int SdkSiteId { get; set; }
        
        public int eFomrId { get; set; }
        
        public int Status { get; set; }
        
        public int SdkCaseId { get; set; }

        [ForeignKey("ItemCase")]
        public int ItemCaseId { get; set; }
    }
}