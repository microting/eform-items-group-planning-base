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
using System.Collections.Generic;
using System.Threading.Tasks;
using eFormShared;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    using Enums;
    using Microsoft.EntityFrameworkCore;

    public class ItemList : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RepeatEvery { get; set; }
        public RepeatType RepeatType { get; set; }
        public RepeatOn RepeatOn { get; set; }
        public DateTime? RepeatUntil { get; set; }
        public bool Enabled { get; set; }
        public int RelatedEFormId { get; set; }
        public string RelatedEFormName { get; set; }
        public int TemplateId { get; set; }

        public virtual ICollection<Item> Items { get; set; } = new HashSet<Item>();
        
        public async Task Save(ItemsPlanningPnDbContext dbContext)
        {
            ItemList itemList = new ItemList
            {
                Name = Name,
                Description = Description,
                Enabled = Enabled,
                RelatedEFormId = RelatedEFormId,
                RelatedEFormName = RelatedEFormName,
                TemplateId = TemplateId,
                RepeatEvery = RepeatEvery,
                RepeatOn = RepeatOn,
                RepeatType = RepeatType,
                RepeatUntil = RepeatUntil,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created
            };

            await dbContext.ItemLists.AddAsync(itemList);
            await dbContext.SaveChangesAsync();

            await dbContext.ItemListVersions.AddAsync(MapItemListVersion(itemList));
            await dbContext.SaveChangesAsync();

            Id = itemList.Id;
        }

        public async Task Update(ItemsPlanningPnDbContext dbContext)
        {
            ItemList itemList = await dbContext.ItemLists.FirstOrDefaultAsync(x => x.Id == Id);

            if (itemList == null)
            {
                throw new NullReferenceException($"Could not find itemList with id: {Id}");
            }

            itemList.Name = Name;
            itemList.Description = Description;
            itemList.Enabled = Enabled;
            itemList.RepeatUntil = RepeatUntil;
            itemList.RelatedEFormId = RelatedEFormId;
            itemList.RelatedEFormName = RelatedEFormName;
            itemList.TemplateId = TemplateId;
            itemList.RepeatEvery = RepeatEvery;
            itemList.RepeatOn = RepeatOn;
            itemList.RepeatType = RepeatType;
            itemList.WorkflowState = WorkflowState;

            if (dbContext.ChangeTracker.HasChanges())
            {
                itemList.UpdatedAt = DateTime.UtcNow;
                itemList.Version += 1;

                await dbContext.ItemListVersions.AddAsync(MapItemListVersion(itemList));
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(ItemsPlanningPnDbContext dbContext)
        {            
            ItemList itemList = await dbContext.ItemLists.FirstOrDefaultAsync(x => x.Id == Id);

            if (itemList == null)
            {
                throw new NullReferenceException($"Could not find itemList with id: {Id}");
            }

            itemList.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                itemList.UpdatedAt = DateTime.UtcNow;
                itemList.Version += 1;

                await dbContext.ItemListVersions.AddAsync(MapItemListVersion(itemList));
                await dbContext.SaveChangesAsync();
            }
            
        }

        private ItemListVersion MapItemListVersion(ItemList itemList)
        {
            var itemVersion = new ItemListVersion
            {
                Name = itemList.Name,
                Description = itemList.Description,
                Enabled = itemList.Enabled,
                RepeatUntil = itemList.RepeatUntil,
                RelatedEFormId = itemList.RelatedEFormId,
                RelatedEFormName = itemList.RelatedEFormName,
                TemplateId = itemList.TemplateId,
                RepeatOn = itemList.RepeatOn,
                RepeatEvery = itemList.RepeatEvery,
                RepeatType = itemList.RepeatType,
                ItemListId = itemList.Id,
                Version = itemList.Version,
                CreatedAt = itemList.CreatedAt,
                WorkflowState = itemList.WorkflowState,
                UpdatedAt = itemList.UpdatedAt,
            };

            return itemVersion;
        }
    }
}