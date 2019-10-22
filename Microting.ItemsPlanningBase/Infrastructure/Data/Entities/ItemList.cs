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
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microting.ItemsPlanningBase.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Microting.eForm.Infrastructure.Constants;

namespace Microting.ItemsPlanningBase.Infrastructure.Data.Entities
{

    public class ItemList : BaseEntity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int RepeatEvery { get; set; }
        
        public RepeatType RepeatType { get; set; }
        
        public DateTime? RepeatUntil { get; set; }
        
        public DayOfWeek? DayOfWeek { get; set; }
        
        public int? DayOfMonth { get; set; }
        
        public DateTime? LastExecutedTime { get; set; }

        public bool Enabled { get; set; }
        
        public int RelatedEFormId { get; set; }
        
        public string RelatedEFormName { get; set; }
        
        public bool DeployedAtEnabled { get; set; }
        
        public bool DoneAtEnabled { get; set; }
        
        public bool DoneByUserNameEnabled { get; set; }
        
        public bool UploadedDataEnabled { get; set; }
        
        public bool LabelEnabled { get; set; }
        
        public bool DescriptionEnabled { get; set; }
        
        public bool SdkFieldEnabled1 { get; set; }
        
        public bool SdkFieldEnabled2 { get; set; }
        
        public bool SdkFieldEnabled3 { get; set; }
        
        public bool SdkFieldEnabled4 { get; set; }
        
        public bool SdkFieldEnabled5 { get; set; }
        
        public bool SdkFieldEnabled6 { get; set; }
        
        public bool SdkFieldEnabled7 { get; set; }
        
        public bool SdkFieldEnabled8 { get; set; }
        
        public bool SdkFieldEnabled9 { get; set; }
        
        public bool SdkFieldEnabled10 { get; set; }
        
        public bool ItemNumberEnabled { get; set; }
        
        public bool LocationCodeEnabled { get; set; }
        
        public bool BuildYearEnabled { get; set; }
        
        public bool NumberOfImagesEnabled { get; set; }
        
        public bool TypeEnabled { get; set; }
        
        public int? SdkFieldId1 { get; set; }

        public int? SdkFieldId2 { get; set; }

        public int? SdkFieldId3 { get; set; }

        public int? SdkFieldId4 { get; set; }

        public int? SdkFieldId5 { get; set; }

        public int? SdkFieldId6 { get; set; }

        public int? SdkFieldId7 { get; set; }

        public int? SdkFieldId8 { get; set; }

        public int? SdkFieldId9 { get; set; }

        public int? SdkFieldId10 { get; set; }

        public virtual ICollection<Item> Items { get; set; } = new HashSet<Item>();
        
        public async Task Create(ItemsPlanningPnDbContext dbContext)
        {
            WorkflowState = Constants.WorkflowStates.Created;
            Version = 1;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            await dbContext.ItemLists.AddAsync(this);
            await dbContext.SaveChangesAsync();

            await dbContext.ItemListVersions.AddAsync(MapItemListVersion(this));
            await dbContext.SaveChangesAsync();
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
            itemList.RepeatEvery = RepeatEvery;
            itemList.DayOfWeek = DayOfWeek;
            itemList.RepeatType = RepeatType;
            itemList.DayOfMonth = DayOfMonth;
            itemList.WorkflowState = WorkflowState;
            itemList.UpdatedByUserId = UpdatedByUserId;
            itemList.LastExecutedTime = LastExecutedTime;
            itemList.DoneAtEnabled = DoneAtEnabled;
            itemList.DeployedAtEnabled = DeployedAtEnabled;
            itemList.DoneByUserNameEnabled = DoneByUserNameEnabled;
            itemList.UploadedDataEnabled = UploadedDataEnabled;
            itemList.LabelEnabled = LabelEnabled;
            itemList.DescriptionEnabled = DescriptionEnabled;
            itemList.SdkFieldEnabled1 = SdkFieldEnabled1;
            itemList.SdkFieldEnabled2 = SdkFieldEnabled2;
            itemList.SdkFieldEnabled3 = SdkFieldEnabled3;
            itemList.SdkFieldEnabled4 = SdkFieldEnabled4;
            itemList.SdkFieldEnabled5 = SdkFieldEnabled5;
            itemList.SdkFieldEnabled6 = SdkFieldEnabled6;
            itemList.SdkFieldEnabled7 = SdkFieldEnabled7;
            itemList.SdkFieldEnabled8 = SdkFieldEnabled8;
            itemList.SdkFieldEnabled9 = SdkFieldEnabled9;
            itemList.SdkFieldEnabled10 = SdkFieldEnabled10;
            itemList.ItemNumberEnabled = ItemNumberEnabled;
            itemList.LocationCodeEnabled = LocationCodeEnabled;
            itemList.BuildYearEnabled = BuildYearEnabled;
            itemList.TypeEnabled = TypeEnabled;
            itemList.SdkFieldId1 = SdkFieldId1;
            itemList.SdkFieldId2 = SdkFieldId2;
            itemList.SdkFieldId3 = SdkFieldId3;
            itemList.SdkFieldId4 = SdkFieldId4;
            itemList.SdkFieldId5 = SdkFieldId5;
            itemList.SdkFieldId6 = SdkFieldId6;
            itemList.SdkFieldId7 = SdkFieldId7;
            itemList.SdkFieldId8 = SdkFieldId8;
            itemList.SdkFieldId9 = SdkFieldId9;
            itemList.SdkFieldId10 = SdkFieldId10;
            itemList.NumberOfImagesEnabled = NumberOfImagesEnabled;

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
                DayOfWeek = itemList.DayOfWeek,
                RepeatEvery = itemList.RepeatEvery,
                RepeatType = itemList.RepeatType,
                DayOfMonth = itemList.DayOfMonth,
                ItemListId = itemList.Id,
                Version = itemList.Version,
                CreatedAt = itemList.CreatedAt,
                WorkflowState = itemList.WorkflowState,
                UpdatedAt = itemList.UpdatedAt,
                UpdatedByUserId = itemList.UpdatedByUserId,
                CreatedByUserId = itemList.CreatedByUserId,
                LastExecutedTime = itemList.LastExecutedTime,
                DoneAtEnabled = itemList.DoneAtEnabled,
                DeployedAtEnabled = itemList.DeployedAtEnabled,
                DoneByUserNameEnabled = itemList.DoneByUserNameEnabled,
                UploadedDataEnabled = itemList.UploadedDataEnabled,
                LabelEnabled = itemList.LabelEnabled,
                DescriptionEnabled = itemList.DescriptionEnabled,
                SdkFieldEnabled1 = itemList.SdkFieldEnabled1,
                SdkFieldEnabled2 = itemList.SdkFieldEnabled2,
                SdkFieldEnabled3 = itemList.SdkFieldEnabled3,
                SdkFieldEnabled4 = itemList.SdkFieldEnabled4,
                SdkFieldEnabled5 = itemList.SdkFieldEnabled5,
                SdkFieldEnabled6 = itemList.SdkFieldEnabled6,
                SdkFieldEnabled7 = itemList.SdkFieldEnabled7,
                SdkFieldEnabled8 = itemList.SdkFieldEnabled8,
                SdkFieldEnabled9 = itemList.SdkFieldEnabled9,
                SdkFieldEnabled10 = itemList.SdkFieldEnabled10,
                ItemNumberEnabled = itemList.ItemNumberEnabled,
                LocationCodeEnabled = itemList.LocationCodeEnabled,
                BuildYearEnabled = itemList.BuildYearEnabled,
                NumberOfImagesEnabled = itemList.NumberOfImagesEnabled,
                TypeEnabled = itemList.TypeEnabled,
                SdkFieldId1 = itemList.SdkFieldId1,
                SdkFieldId2 = itemList.SdkFieldId2,
                SdkFieldId3 = itemList.SdkFieldId3,
                SdkFieldId4 = itemList.SdkFieldId4,
                SdkFieldId5 = itemList.SdkFieldId5,
                SdkFieldId6 = itemList.SdkFieldId6,
                SdkFieldId7 = itemList.SdkFieldId7,
                SdkFieldId8 = itemList.SdkFieldId8,
                SdkFieldId9 = itemList.SdkFieldId9,
                SdkFieldId10 = itemList.SdkFieldId10
                
                
            };

            return itemVersion;
        }
    }
}