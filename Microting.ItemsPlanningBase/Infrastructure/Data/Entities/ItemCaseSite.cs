/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class ItemCaseSite : BaseEntity
    {
        public int MicrotingSdkSiteId { get; set; }

        public int MicrotingSdkeFormId { get; set; }

        public int Status { get; set; }
        
        public string FieldStatus { get; set; }

        public int MicrotingSdkCaseId { get; set; }
        
        public DateTime? MicrotingSdkCaseDoneAt { get; set; }
        
        public int NumberOfImages { get; set; }
        
        public string Comment { get; set; }
        
        public string Location { get; set; }

        public int ItemId { get; set; }
        
        public string SdkFieldValue1 { get; set; }
        
        public string SdkFieldValue2 { get; set; }
        
        public string SdkFieldValue3 { get; set; }
        
        public string SdkFieldValue4 { get; set; }
        
        public string SdkFieldValue5 { get; set; }
        
        public string SdkFieldValue6 { get; set; }
        
        public string SdkFieldValue7 { get; set; }
        
        public string SdkFieldValue8 { get; set; }
        
        public string SdkFieldValue9 { get; set; }
        
        public string SdkFieldValue10 { get; set; }
        
        public int DoneByUserId { get; set; }
        
        public string DoneByUserName { get; set; }
        
        [ForeignKey("ItemCase")]
        public int ItemCaseId { get; set; }

        public async Task Create(ItemsPlanningPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            await dbContext.ItemCaseSites.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.ItemCaseSiteVersions.AddAsync(MapVersion(this));
            await dbContext.SaveChangesAsync();

        }

        public async Task Update(ItemsPlanningPnDbContext dbContext)
        {
            ItemCaseSite itemCaseSite = await dbContext.ItemCaseSites.FirstOrDefaultAsync(x => x.Id == Id);

            if (itemCaseSite == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            itemCaseSite.MicrotingSdkSiteId = MicrotingSdkSiteId;
            itemCaseSite.MicrotingSdkeFormId = MicrotingSdkeFormId;
            itemCaseSite.Status = Status;
            itemCaseSite.FieldStatus = FieldStatus;
            itemCaseSite.MicrotingSdkCaseId = MicrotingSdkCaseId;
            itemCaseSite.ItemId = ItemId;
            itemCaseSite.MicrotingSdkCaseDoneAt = MicrotingSdkCaseDoneAt;
            itemCaseSite.WorkflowState = WorkflowState;
            itemCaseSite.NumberOfImages = NumberOfImages;
            itemCaseSite.Comment = Comment;
            itemCaseSite.Location = Location;
            itemCaseSite.SdkFieldValue1 = SdkFieldValue1;
            itemCaseSite.SdkFieldValue2 = SdkFieldValue2;
            itemCaseSite.SdkFieldValue3 = SdkFieldValue3;
            itemCaseSite.SdkFieldValue4 = SdkFieldValue4;
            itemCaseSite.SdkFieldValue5 = SdkFieldValue5;
            itemCaseSite.SdkFieldValue6 = SdkFieldValue6;
            itemCaseSite.SdkFieldValue7 = SdkFieldValue7;
            itemCaseSite.SdkFieldValue8 = SdkFieldValue8;
            itemCaseSite.SdkFieldValue9 = SdkFieldValue9;
            itemCaseSite.SdkFieldValue10 = SdkFieldValue10;
            itemCaseSite.DoneByUserId = DoneByUserId;
            itemCaseSite.DoneByUserName = DoneByUserName;
            itemCaseSite.ItemCaseId = ItemCaseId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                itemCaseSite.UpdatedAt = DateTime.UtcNow;
                itemCaseSite.Version += 1;

                await dbContext.ItemCaseSiteVersions.AddAsync(MapVersion(itemCaseSite));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(ItemsPlanningPnDbContext dbContext)
        {
            ItemCaseSite itemCaseSite = await dbContext.ItemCaseSites.FirstOrDefaultAsync(x => x.Id == Id);

            if (itemCaseSite == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            itemCaseSite.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                itemCaseSite.UpdatedAt = DateTime.UtcNow;
                itemCaseSite.Version += 1;

                await dbContext.ItemCaseSiteVersions.AddAsync(MapVersion(itemCaseSite));
                await dbContext.SaveChangesAsync();
            }
        }

        private ItemCaseSiteVersion MapVersion(ItemCaseSite itemCaseSite)
        {
            ItemCaseSiteVersion itemCaseVersion = new ItemCaseSiteVersion
            {
                MicrotingSdkSiteId = itemCaseSite.MicrotingSdkSiteId,
                MicrotingSdkeFormId = itemCaseSite.MicrotingSdkeFormId,
                Status = itemCaseSite.Status,
                FieldStatus = itemCaseSite.FieldStatus,
                MicrotingSdkCaseId = itemCaseSite.MicrotingSdkCaseId,
                ItemId = itemCaseSite.ItemId,
                MicrotingSdkCaseDoneAt = itemCaseSite.MicrotingSdkCaseDoneAt,
                NumberOfImages = itemCaseSite.NumberOfImages,
                Comment = itemCaseSite.Comment,
                Location = itemCaseSite.Location,
                ItemCaseId = itemCaseSite.Id,
                Version = itemCaseSite.Version,
                CreatedAt = itemCaseSite.CreatedAt,
                CreatedByUserId = itemCaseSite.CreatedByUserId,
                UpdatedAt = itemCaseSite.UpdatedAt,
                UpdatedByUserId = itemCaseSite.UpdatedByUserId,
                WorkflowState = itemCaseSite.WorkflowState,
                SdkFieldValue1 = itemCaseSite.SdkFieldValue1,
                SdkFieldValue2 = itemCaseSite.SdkFieldValue2,
                SdkFieldValue3 = itemCaseSite.SdkFieldValue3,
                SdkFieldValue4 = itemCaseSite.SdkFieldValue4,
                SdkFieldValue5 = itemCaseSite.SdkFieldValue5,
                SdkFieldValue6 = itemCaseSite.SdkFieldValue6,
                SdkFieldValue7 = itemCaseSite.SdkFieldValue7,
                SdkFieldValue8 = itemCaseSite.SdkFieldValue8,
                SdkFieldValue9 = itemCaseSite.SdkFieldValue9,
                SdkFieldValue10 = itemCaseSite.SdkFieldValue10,
                DoneByUserId = itemCaseSite.DoneByUserId,
                DoneByUserName = itemCaseSite.DoneByUserName,
                ItemCaseSiteId = itemCaseSite.ItemCaseId
            };

            return itemCaseVersion;
        }
        
    }
}