using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.ItemsPlanningBase.Infrastucture.Data.Entities
{
    public class ItemCaseVersion : BaseEntity
    {
        public int MicrotingSdkSiteId { get; set; }
        
        public int MicrotingSdkeFormId { get; set; }
        
        public int Status { get; set; }
        
        public int MicrotingSdkCaseId { get; set; }

        [ForeignKey("ItemCase")]
        public int ItemCaseId { get; set; }
    }
}