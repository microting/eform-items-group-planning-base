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
using System.Linq;
using System.Threading.Tasks;
using eFormShared;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{
    public class ItemList : BaseEntity
    {               
        
        public ItemList()
        {
            this.Items = new HashSet<Item>();
        }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool Enabled { get; set; }
        
        public int RelatedeFormId { get; set; }
        
        public string RelatedeFormName { get; set; }
        
        public int RepeatedType { get; set; }
        
        public virtual ICollection<Item> Items { get; set; }
        
        public async Task Save(ItemsPlanningPnDbContext dbContext)
        {
            ItemList itemList = new ItemList
            {
                Name = Name,
                Description = Description,
                Enabled = Enabled,
                RelatedeFormId = RelatedeFormId,
                RelatedeFormName = RelatedeFormName,
                RepeatedType = RepeatedType,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created
            };

            dbContext.ItemLists.Add(itemList);
            dbContext.SaveChanges();

            dbContext.ItemListVersions.Add(MapItemListVersion(itemList));
            dbContext.SaveChanges();

            Id = itemList.Id;
        }

        public async Task Update(ItemsPlanningPnDbContext dbContext)
        {
            ItemList itemList = dbContext.ItemLists.FirstOrDefault(x => x.Id == Id);

            if (itemList == null)
            {
                throw new NullReferenceException($"Could not find itemList with id: {Id}");
            }

            itemList.Name = Name;
            itemList.Description = Description;
            itemList.Enabled = Enabled;
            itemList.RelatedeFormId = RelatedeFormId;
            itemList.RelatedeFormName = RelatedeFormName;
            itemList.RepeatedType = RepeatedType;
            itemList.WorkflowState = WorkflowState;

            if (dbContext.ChangeTracker.HasChanges())
            {
                itemList.UpdatedAt = DateTime.UtcNow;
                itemList.Version += 1;

                dbContext.ItemListVersions.Add(MapItemListVersion(itemList));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(ItemsPlanningPnDbContext dbContext)
        {            
            ItemList itemList = dbContext.ItemLists.FirstOrDefault(x => x.Id == Id);

            if (itemList == null)
            {
                throw new NullReferenceException($"Could not find itemList with id: {Id}");
            }

            itemList.WorkflowState = Constants.WorkflowStates.Removed;
            
            if (dbContext.ChangeTracker.HasChanges())
            {
                itemList.UpdatedAt = DateTime.UtcNow;
                itemList.Version += 1;

                dbContext.ItemListVersions.Add(MapItemListVersion(itemList));
                dbContext.SaveChanges();
            }
            
        }

        private ItemListVersion MapItemListVersion(ItemList itemList)
        {
            ItemListVersion itemVersion = new ItemListVersion();

            itemVersion.Name = itemList.Name;
            itemVersion.Description = itemList.Description;
            itemVersion.Enabled = itemList.Enabled;
            itemVersion.RelatedeFormId = itemList.RelatedeFormId;
            itemVersion.RelatedeFormName = itemList.RelatedeFormName;
            itemVersion.RepeatedType = itemList.RepeatedType;
            itemVersion.ItemListId = itemList.Id;
            itemVersion.Version = itemList.Version;
            itemVersion.CreatedAt = itemList.CreatedAt;
            itemVersion.UpdatedAt = itemList.UpdatedAt;
            itemVersion.WorkflowState = itemList.WorkflowState;


            return itemVersion;
        }
    }
}