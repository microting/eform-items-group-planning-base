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
using System.Linq;
using System.Threading.Tasks;
using eFormShared;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class Item : BaseEntity
    {
        public string Sku { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool Enabled { get; set; }
        
        public string RepeatType { get; set; }
        
        [ForeignKey("ItemList")]
        public int ItemListId { get; set; }
                    
        public async Task Save(ItemsPlanningPnDbContext dbContext)
        {
            Item item = new Item
            {
                Sku = Sku,
                Name = Name,
                Description = Description,
                Enabled = Enabled,
                RepeatType = RepeatType,
                ItemListId = ItemListId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created
            };

            dbContext.Items.Add(item);
            dbContext.SaveChanges();

            dbContext.ItemVersions.Add(MapItemVersion(item));
            dbContext.SaveChanges();
        }

        public async Task Update(ItemsPlanningPnDbContext dbContext)
        {
            Item item = dbContext.Items.FirstOrDefault(x => x.Id == Id);

            if (item == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            item.Sku = Sku;
            item.Name = Name;
            item.Description = Description;
            item.WorkflowState = WorkflowState;

            if (dbContext.ChangeTracker.HasChanges())
            {
                item.UpdatedAt = DateTime.UtcNow;
                item.Version += 1;

                dbContext.ItemVersions.Add(MapItemVersion(item));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(ItemsPlanningPnDbContext dbContext)
        {            
            Item item = dbContext.Items.FirstOrDefault(x => x.Id == Id);

            if (item == null)
            {
                throw new NullReferenceException($"Could not find item with id: {Id}");
            }

            item.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                item.UpdatedAt = DateTime.UtcNow;
                item.Version += 1;

                dbContext.ItemVersions.Add(MapItemVersion(item));
                dbContext.SaveChanges();
            }
            
        }

        private ItemVersion MapItemVersion(Item item)
        {
            ItemVersion itemVersion = new ItemVersion();

            itemVersion.Sku = item.Sku;
            itemVersion.Name = item.Name;
            itemVersion.Description = item.Description;
            itemVersion.Enabled = item.Enabled;
            itemVersion.RepeatType = item.RepeatType;
            itemVersion.ItemListId = item.ItemListId;
            itemVersion.Version = item.Version;
            itemVersion.ItemId = item.Id;
            itemVersion.CreatedAt = item.CreatedAt;
            itemVersion.UpdatedAt = item.UpdatedAt;
            itemVersion.WorkflowState = item.WorkflowState;


            return itemVersion;
        }
    }
}