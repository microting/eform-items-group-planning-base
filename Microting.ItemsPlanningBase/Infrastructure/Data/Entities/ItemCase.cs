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
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;

    public class ItemCase : BaseEntity
    {
        public int MicrotingSdkSiteId { get; set; }

        public int MicrotingSdkeFormId { get; set; }

        public int Status { get; set; }

        public int MicrotingSdkCaseId { get; set; }
        
        public DateTime? MicrotingSdkCaseDoneAt { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public async Task Create(ItemsPlanningPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            await dbContext.ItemCases.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.ItemCaseVersions.AddAsync(MapVersion(this));
            await dbContext.SaveChangesAsync();

        }

        public async Task Update(ItemsPlanningPnDbContext dbContext)
        {
            ItemCase itemCase = await dbContext.ItemCases.FirstOrDefaultAsync(x => x.Id == Id);

            if (itemCase == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            itemCase.MicrotingSdkSiteId = MicrotingSdkSiteId;
            itemCase.MicrotingSdkeFormId = MicrotingSdkeFormId;
            itemCase.Status = Status;
            itemCase.MicrotingSdkCaseId = MicrotingSdkCaseId;
            itemCase.ItemId = ItemId;
            itemCase.MicrotingSdkCaseDoneAt = MicrotingSdkCaseDoneAt;
            itemCase.WorkflowState = WorkflowState;

            if (dbContext.ChangeTracker.HasChanges())
            {
                itemCase.UpdatedAt = DateTime.UtcNow;
                itemCase.Version += 1;

                await dbContext.ItemCaseVersions.AddAsync(MapVersion(itemCase));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(ItemsPlanningPnDbContext dbContext)
        {
            ItemCase itemCase = await dbContext.ItemCases.FirstOrDefaultAsync(x => x.Id == Id);

            if (itemCase == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            itemCase.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                itemCase.UpdatedAt = DateTime.UtcNow;
                itemCase.Version += 1;

                await dbContext.ItemCaseVersions.AddAsync(MapVersion(itemCase));
                await dbContext.SaveChangesAsync();
            }
        }

        private ItemCaseVersion MapVersion(ItemCase item)
        {
            ItemCaseVersion itemCaseVersion = new ItemCaseVersion
            {
                MicrotingSdkSiteId = item.MicrotingSdkSiteId,
                MicrotingSdkeFormId = item.MicrotingSdkeFormId,
                Status = item.Status,
                MicrotingSdkCaseId = item.MicrotingSdkCaseId,
                ItemId = item.ItemId,
                MicrotingSdkCaseDoneAt = item.MicrotingSdkCaseDoneAt,
                ItemCaseId = item.Id,
                Version = item.Version,
                CreatedAt = item.CreatedAt,
                CreatedByUserId = item.CreatedByUserId,
                UpdatedAt = item.UpdatedAt,
                UpdatedByUserId = item.UpdatedByUserId,
                WorkflowState = item.WorkflowState
            };

            return itemCaseVersion;
        }
    }
}