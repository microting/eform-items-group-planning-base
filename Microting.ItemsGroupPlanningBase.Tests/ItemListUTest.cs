/*
The MIT License (MIT)

Copyright (c) 2007 - 2021 Microting A/S

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

namespace Microting.ItemsGroupPlanningBase.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using eForm.Infrastructure.Constants;
    using Infrastructure.Data.Entities;
    using Infrastructure.Enums;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    [TestFixture]
    public class ItemListUTest : DbTestFixture
    {
        [Test]
        public async Task ItemList_Save_DoesSave()
        {
            // Arrange
            ItemList itemList = new ItemList
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                RelatedEFormId = 35,
                RelatedEFormName = Guid.NewGuid().ToString(),
                RepeatType = RepeatType.Day,
                UpdatedByUserId = 1,
                CreatedByUserId = 1,
                RepeatUntil = new DateTime(2050,1,1,1,1,1),
                DayOfWeek = DayOfWeek.Friday,
                RepeatEvery = 1,
                DayOfMonth = 3,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
            };

            // Act
            await itemList.Create(DbContext);

            List<ItemList> itemLists = DbContext.ItemLists
                .AsNoTracking()
                .ToList();

            List<ItemListVersion> itemListVersions = DbContext.ItemListVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, itemLists.Count);
            Assert.AreEqual(1, itemListVersions.Count);
            Assert.AreEqual(itemList.Name, itemLists[0].Name);
            Assert.AreEqual(itemList.CreatedByUserId, itemLists[0].CreatedByUserId);
            Assert.AreEqual(itemList.UpdatedByUserId, itemLists[0].UpdatedByUserId);
            Assert.AreEqual(itemList.Description, itemLists[0].Description);
            Assert.AreEqual(itemList.Enabled, itemLists[0].Enabled);
            Assert.AreEqual(itemList.RepeatType, itemLists[0].RepeatType);
            Assert.AreEqual(itemList.RelatedEFormId, itemLists[0].RelatedEFormId);
            Assert.AreEqual(itemList.RelatedEFormName, itemLists[0].RelatedEFormName);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemLists[0].WorkflowState);
            Assert.AreEqual(itemList.RepeatUntil, itemLists[0].RepeatUntil);
            Assert.AreEqual(itemList.DayOfWeek, itemLists[0].DayOfWeek);
            Assert.AreEqual(itemList.RepeatEvery, itemLists[0].RepeatEvery);
            Assert.AreEqual(itemList.DayOfMonth, itemLists[0].DayOfMonth);
            Assert.AreEqual(itemList.Id, itemLists[0].Id);
            Assert.AreEqual(1, itemLists[0].Version);
                        
            Assert.AreEqual(itemList.Name, itemListVersions[0].Name);
            Assert.AreEqual(itemList.Description, itemListVersions[0].Description);
            Assert.AreEqual(itemList.Enabled, itemListVersions[0].Enabled);
            Assert.AreEqual(itemList.RepeatType, itemListVersions[0].RepeatType);
            Assert.AreEqual(itemList.RelatedEFormId, itemListVersions[0].RelatedEFormId);
            Assert.AreEqual(itemList.RelatedEFormName, itemListVersions[0].RelatedEFormName);
            Assert.AreEqual(itemList.Id, itemListVersions[0].ItemListId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemListVersions[0].WorkflowState);
            Assert.AreEqual(itemList.RepeatUntil, itemListVersions[0].RepeatUntil);
            Assert.AreEqual(itemList.DayOfWeek, itemListVersions[0].DayOfWeek);
            Assert.AreEqual(itemList.DayOfMonth, itemListVersions[0].DayOfMonth);
            Assert.AreEqual(itemList.RepeatEvery, itemListVersions[0].RepeatEvery);
            Assert.AreEqual(1, itemListVersions[0].Version);
        }

        [Test]
        public async Task ItemList_Update_DoesUpdate()
        {
            // Arrange
            ItemList itemList = new ItemList
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                RelatedEFormId = 35,
                RelatedEFormName = Guid.NewGuid().ToString(),
                RepeatType = RepeatType.Day,
                UpdatedByUserId = 1,
                CreatedByUserId = 1,
                RepeatUntil = new DateTime(2050,1,1,1,1,1),
                DayOfWeek = DayOfWeek.Friday,
                RepeatEvery = 1,
                DayOfMonth = 1,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created,
                
            };
            await itemList.Create(DbContext);

            // Act
            itemList = await DbContext.ItemLists.FirstOrDefaultAsync();

            string oldName = itemList.Name;
            itemList.Name = "hello";
            await itemList.Update(DbContext);

            List<ItemList> itemLists = DbContext.ItemLists.AsNoTracking().ToList();
            List<ItemListVersion> itemListVersions = DbContext.ItemListVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, itemLists.Count);
            Assert.AreEqual(2, itemListVersions.Count);
            Assert.AreEqual(itemList.Name, itemLists[0].Name);
            Assert.AreEqual(itemList.Description, itemLists[0].Description);
            Assert.AreEqual(itemList.Enabled, itemLists[0].Enabled);
            Assert.AreEqual(itemList.UpdatedByUserId, itemLists[0].UpdatedByUserId);
            Assert.AreEqual(itemList.CreatedByUserId, itemLists[0].CreatedByUserId);
            Assert.AreEqual(itemList.RepeatUntil, itemLists[0].RepeatUntil);
            Assert.AreEqual(itemList.DayOfWeek, itemLists[0].DayOfWeek);
            Assert.AreEqual(itemList.RepeatEvery, itemLists[0].RepeatEvery);
            Assert.AreEqual(itemList.RepeatType, itemLists[0].RepeatType);
            Assert.AreEqual(itemList.DayOfMonth, itemLists[0].DayOfMonth);
            Assert.AreEqual(itemList.RelatedEFormId, itemLists[0].RelatedEFormId);
            Assert.AreEqual(itemList.RelatedEFormName, itemLists[0].RelatedEFormName);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemLists[0].WorkflowState);
            Assert.AreEqual(itemList.Id, itemLists[0].Id);
            Assert.AreEqual(2, itemLists[0].Version);
                        
            Assert.AreEqual(oldName, itemListVersions[0].Name);
            Assert.AreEqual(itemList.Description, itemListVersions[0].Description);
            Assert.AreEqual(itemList.Enabled, itemListVersions[0].Enabled);
            Assert.AreEqual(itemList.RepeatType, itemListVersions[0].RepeatType);
            Assert.AreEqual(itemList.RelatedEFormId, itemListVersions[0].RelatedEFormId);
            Assert.AreEqual(itemList.RelatedEFormName, itemListVersions[0].RelatedEFormName);

            Assert.AreEqual(itemList.UpdatedByUserId, itemListVersions[0].UpdatedByUserId);
            Assert.AreEqual(itemList.CreatedByUserId, itemListVersions[0].CreatedByUserId);
            Assert.AreEqual(itemList.RepeatUntil, itemListVersions[0].RepeatUntil);
            Assert.AreEqual(itemList.DayOfWeek, itemListVersions[0].DayOfWeek);
            Assert.AreEqual(itemList.RepeatEvery, itemListVersions[0].RepeatEvery);
            Assert.AreEqual(itemList.Id, itemListVersions[0].ItemListId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemListVersions[0].WorkflowState);
            Assert.AreEqual(1, itemListVersions[0].Version);
            Assert.AreEqual("hello", itemListVersions[1].Name);
            Assert.AreEqual(itemList.Description, itemListVersions[1].Description);
            Assert.AreEqual(itemList.Enabled, itemListVersions[1].Enabled);
            Assert.AreEqual(itemList.RepeatType, itemListVersions[1].RepeatType);
            Assert.AreEqual(itemList.RelatedEFormId, itemListVersions[1].RelatedEFormId);
            Assert.AreEqual(itemList.RelatedEFormName, itemListVersions[1].RelatedEFormName);

            Assert.AreEqual(itemList.UpdatedByUserId, itemListVersions[1].UpdatedByUserId);
            Assert.AreEqual(itemList.CreatedByUserId, itemListVersions[1].CreatedByUserId);
            Assert.AreEqual(itemList.RepeatUntil, itemListVersions[1].RepeatUntil);
            Assert.AreEqual(itemList.DayOfWeek, itemListVersions[1].DayOfWeek);
            Assert.AreEqual(itemList.RepeatEvery, itemListVersions[1].RepeatEvery);

            Assert.AreEqual(itemList.Id, itemListVersions[1].ItemListId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemListVersions[1].WorkflowState);
            Assert.AreEqual(2, itemListVersions[1].Version);
        }

        [Test]
        public async Task ItemList_Delete_DoesDelete()
        {
            // Arrange
            ItemList itemList = new ItemList
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                RelatedEFormId = 35,
                RelatedEFormName = Guid.NewGuid().ToString(),
                RepeatType = RepeatType.Day,
                UpdatedByUserId = 1,
                CreatedByUserId = 1,
                RepeatEvery = 1,
                DayOfMonth = 1,
                RepeatUntil = new DateTime(2050,1,1,1,1,1),
                WorkflowState = Constants.WorkflowStates.Created,
                DayOfWeek = DayOfWeek.Friday,
            };
            await itemList.Create(DbContext);

            // Act
            itemList = await DbContext.ItemLists.FirstOrDefaultAsync();

            Assert.AreEqual(Constants.WorkflowStates.Created, itemList.WorkflowState);

            await itemList.Delete(DbContext);

            List<ItemList> itemLists = DbContext.ItemLists.AsNoTracking().ToList();
            List<ItemListVersion> itemListVersions = DbContext.ItemListVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, itemLists.Count);
            Assert.AreEqual(2, itemListVersions.Count);
            Assert.AreEqual(itemList.Name, itemLists[0].Name);
            Assert.AreEqual(itemList.Description, itemLists[0].Description);
            Assert.AreEqual(itemList.Enabled, itemLists[0].Enabled);
            Assert.AreEqual(itemList.RepeatType, itemLists[0].RepeatType);
            Assert.AreEqual(itemList.RelatedEFormId, itemLists[0].RelatedEFormId);
            Assert.AreEqual(itemList.RelatedEFormName, itemLists[0].RelatedEFormName);

            Assert.AreEqual(itemList.UpdatedByUserId, itemLists[0].UpdatedByUserId);
            Assert.AreEqual(itemList.CreatedByUserId, itemLists[0].CreatedByUserId);
            Assert.AreEqual(itemList.RepeatEvery, itemLists[0].RepeatEvery);
            Assert.AreEqual(itemList.RepeatUntil, itemLists[0].RepeatUntil);
            Assert.AreEqual(itemList.DayOfWeek, itemLists[0].DayOfWeek);
            Assert.AreEqual(itemList.DayOfMonth, itemLists[0].DayOfMonth);

            Assert.AreEqual(Constants.WorkflowStates.Removed, itemLists[0].WorkflowState);
            Assert.AreEqual(itemList.Id, itemLists[0].Id);
            Assert.AreEqual(2, itemLists[0].Version);
                        
            Assert.AreEqual(itemList.Name, itemListVersions[0].Name);
            Assert.AreEqual(itemList.Description, itemListVersions[0].Description);
            Assert.AreEqual(itemList.Enabled, itemListVersions[0].Enabled);
            Assert.AreEqual(itemList.RepeatType, itemListVersions[0].RepeatType);
            Assert.AreEqual(itemList.RelatedEFormId, itemListVersions[0].RelatedEFormId);
            Assert.AreEqual(itemList.RelatedEFormName, itemListVersions[0].RelatedEFormName);

            Assert.AreEqual(itemList.UpdatedByUserId, itemListVersions[0].UpdatedByUserId);
            Assert.AreEqual(itemList.CreatedByUserId, itemListVersions[0].CreatedByUserId);
            Assert.AreEqual(itemList.RepeatEvery, itemListVersions[0].RepeatEvery);
            Assert.AreEqual(itemList.RepeatUntil, itemListVersions[0].RepeatUntil);
            Assert.AreEqual(itemList.DayOfWeek, itemListVersions[0].DayOfWeek);
            Assert.AreEqual(itemList.DayOfMonth, itemListVersions[0].DayOfMonth);

            Assert.AreEqual(itemList.Id, itemListVersions[0].ItemListId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemListVersions[0].WorkflowState);
            Assert.AreEqual(1, itemListVersions[0].Version);
            
            Assert.AreEqual(itemList.Name, itemListVersions[1].Name);
            Assert.AreEqual(itemList.Description, itemListVersions[1].Description);
            Assert.AreEqual(itemList.Enabled, itemListVersions[1].Enabled);
            Assert.AreEqual(itemList.RepeatType, itemListVersions[1].RepeatType);
            Assert.AreEqual(itemList.RelatedEFormId, itemListVersions[1].RelatedEFormId);
            Assert.AreEqual(itemList.RelatedEFormName, itemListVersions[1].RelatedEFormName);
            Assert.AreEqual(itemList.UpdatedByUserId, itemListVersions[1].UpdatedByUserId);
            Assert.AreEqual(itemList.CreatedByUserId, itemListVersions[1].CreatedByUserId);
            Assert.AreEqual(itemList.RepeatEvery, itemListVersions[1].RepeatEvery);
            Assert.AreEqual(itemList.RepeatUntil, itemListVersions[1].RepeatUntil);
            Assert.AreEqual(itemList.DayOfWeek, itemListVersions[1].DayOfWeek);

            Assert.AreEqual(itemList.Id, itemListVersions[1].ItemListId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, itemListVersions[1].WorkflowState);
            Assert.AreEqual(2, itemListVersions[1].Version);
        }
    }
}