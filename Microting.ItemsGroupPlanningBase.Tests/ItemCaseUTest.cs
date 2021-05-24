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
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    [TestFixture]
    public class ItemCaseUTest : DbTestFixture
    {
        [Test]
        public async Task ItemCase_Save_DoesSave()
        {
            // Arrange
            ItemList itemList = new ItemList
            {
                Name = Guid.NewGuid().ToString()
            };

            await itemList.Create(DbContext);
            
            Item item = new Item
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                ItemListId = itemList.Id,
            };
            
            await item.Create(DbContext);
            
            ItemCase itemCase = new ItemCase
            {
                MicrotingSdkSiteId = 24,
                MicrotingSdkCaseId = 34,
                MicrotingSdkeFormId = 234,
                Status = 66,
                ItemId = item.Id,
            };

            // Act
            await itemCase.Create(DbContext);

            List<ItemCase> itemCases = DbContext.ItemCases.AsNoTracking().ToList();
            List<ItemCaseVersion> itemCaseVersions = DbContext.ItemCaseVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, itemCases.Count);
            Assert.AreEqual(1, itemCaseVersions.Count);
            Assert.AreEqual(itemCase.MicrotingSdkSiteId, itemCases[0].MicrotingSdkSiteId);
            Assert.AreEqual(itemCase.MicrotingSdkCaseId, itemCases[0].MicrotingSdkCaseId);
            Assert.AreEqual(itemCase.MicrotingSdkeFormId, itemCases[0].MicrotingSdkeFormId);
            Assert.AreEqual(itemCase.Status, itemCases[0].Status);
            Assert.AreEqual(itemCase.ItemId, itemCases[0].ItemId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemCases[0].WorkflowState);
            Assert.AreEqual(itemCase.Id, itemCases[0].Id);
            Assert.AreEqual(1, itemCases[0].Version);
                        
            Assert.AreEqual(itemCase.MicrotingSdkSiteId, itemCaseVersions[0].MicrotingSdkSiteId);
            Assert.AreEqual(itemCase.MicrotingSdkCaseId, itemCaseVersions[0].MicrotingSdkCaseId);
            Assert.AreEqual(itemCase.MicrotingSdkeFormId, itemCaseVersions[0].MicrotingSdkeFormId);
            Assert.AreEqual(itemCase.Status, itemCaseVersions[0].Status);
            Assert.AreEqual(itemCase.ItemId, itemCaseVersions[0].ItemId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemCaseVersions[0].WorkflowState);
            Assert.AreEqual(itemCase.Id, itemCaseVersions[0].ItemCaseId);
            Assert.AreEqual(1, itemCaseVersions[0].Version);
        }

        [Test]
        public async Task ItemCase_Update_DoesUpdate()
        {
            // Arrange
            ItemList itemList = new ItemList
            {
                Name = Guid.NewGuid().ToString()
            };

            await itemList.Create(DbContext);
            
            Item item = new Item
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                ItemListId = itemList.Id
            };
            
            await item.Create(DbContext);
            
            ItemCase itemCase = new ItemCase
            {
                MicrotingSdkSiteId = 24,
                MicrotingSdkCaseId = 34,
                MicrotingSdkeFormId = 234,
                Status = 66,
                ItemId = item.Id
            };

            await itemCase.Create(DbContext);
            // Act
            itemCase = await DbContext.ItemCases.FirstOrDefaultAsync();

            itemCase.Status = 77;
            await itemCase.Update(DbContext);

            List<ItemCase> itemCases = DbContext.ItemCases.AsNoTracking().ToList();
            List<ItemCaseVersion> itemCaseVersions = DbContext.ItemCaseVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, itemCases.Count);
            Assert.AreEqual(2, itemCaseVersions.Count);
            Assert.AreEqual(itemCase.MicrotingSdkSiteId, itemCases[0].MicrotingSdkSiteId);
            Assert.AreEqual(itemCase.MicrotingSdkCaseId, itemCases[0].MicrotingSdkCaseId);
            Assert.AreEqual(itemCase.MicrotingSdkeFormId, itemCases[0].MicrotingSdkeFormId);
            Assert.AreEqual(77, itemCases[0].Status);
            Assert.AreEqual(itemCase.ItemId, itemCases[0].ItemId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemCases[0].WorkflowState);
            Assert.AreEqual(itemCase.Id, itemCases[0].Id);
            Assert.AreEqual(2, itemCases[0].Version);
                        
            Assert.AreEqual(itemCase.MicrotingSdkSiteId, itemCaseVersions[0].MicrotingSdkSiteId);
            Assert.AreEqual(itemCase.MicrotingSdkCaseId, itemCaseVersions[0].MicrotingSdkCaseId);
            Assert.AreEqual(itemCase.MicrotingSdkeFormId, itemCaseVersions[0].MicrotingSdkeFormId);
            Assert.AreEqual(66, itemCaseVersions[0].Status);
            Assert.AreEqual(itemCase.ItemId, itemCaseVersions[0].ItemId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemCaseVersions[0].WorkflowState);
            Assert.AreEqual(itemCase.Id, itemCaseVersions[0].ItemCaseId);
            Assert.AreEqual(1, itemCaseVersions[0].Version);
                        
            Assert.AreEqual(itemCase.MicrotingSdkSiteId, itemCaseVersions[1].MicrotingSdkSiteId);
            Assert.AreEqual(itemCase.MicrotingSdkCaseId, itemCaseVersions[1].MicrotingSdkCaseId);
            Assert.AreEqual(itemCase.MicrotingSdkeFormId, itemCaseVersions[1].MicrotingSdkeFormId);
            Assert.AreEqual(77, itemCaseVersions[1].Status);
            Assert.AreEqual(itemCase.ItemId, itemCaseVersions[1].ItemId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemCaseVersions[1].WorkflowState);
            Assert.AreEqual(itemCase.Id, itemCaseVersions[1].ItemCaseId);
            Assert.AreEqual(2, itemCaseVersions[1].Version);
        }

        [Test]
        public async Task ItemCase_Delete_DoesDelete()
        {
            // Arrange
            ItemList itemList = new ItemList
            {
                Name = Guid.NewGuid().ToString()
            };

            await itemList.Create(DbContext);
            
            Item item = new Item
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Enabled = true,
                ItemListId = itemList.Id
            };
            
            await item.Create(DbContext);
            
            ItemCase itemCase = new ItemCase
            {
                MicrotingSdkSiteId = 24,
                MicrotingSdkCaseId = 34,
                MicrotingSdkeFormId = 234,
                Status = 66,
                ItemId = item.Id
            };

            await itemCase.Create(DbContext);
            // Act
            itemCase = await DbContext.ItemCases.FirstOrDefaultAsync();

            await itemCase.Delete(DbContext);

            List<ItemCase> itemCases = DbContext.ItemCases.AsNoTracking().ToList();
            List<ItemCaseVersion> itemCaseVersions = DbContext.ItemCaseVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, itemCases.Count);
            Assert.AreEqual(2, itemCaseVersions.Count);
            Assert.AreEqual(itemCase.MicrotingSdkSiteId, itemCases[0].MicrotingSdkSiteId);
            Assert.AreEqual(itemCase.MicrotingSdkCaseId, itemCases[0].MicrotingSdkCaseId);
            Assert.AreEqual(itemCase.MicrotingSdkeFormId, itemCases[0].MicrotingSdkeFormId);
            Assert.AreEqual(itemCase.Status, itemCases[0].Status);
            Assert.AreEqual(itemCase.ItemId, itemCases[0].ItemId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, itemCases[0].WorkflowState);
            Assert.AreEqual(itemCase.Id, itemCases[0].Id);
            Assert.AreEqual(2, itemCases[0].Version);
                        
            Assert.AreEqual(itemCase.MicrotingSdkSiteId, itemCaseVersions[0].MicrotingSdkSiteId);
            Assert.AreEqual(itemCase.MicrotingSdkCaseId, itemCaseVersions[0].MicrotingSdkCaseId);
            Assert.AreEqual(itemCase.MicrotingSdkeFormId, itemCaseVersions[0].MicrotingSdkeFormId);
            Assert.AreEqual(itemCase.Status, itemCaseVersions[0].Status);
            Assert.AreEqual(itemCase.ItemId, itemCaseVersions[0].ItemId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemCaseVersions[0].WorkflowState);
            Assert.AreEqual(itemCase.Id, itemCaseVersions[0].ItemCaseId);
            Assert.AreEqual(1, itemCaseVersions[0].Version);
                        
            Assert.AreEqual(itemCase.MicrotingSdkSiteId, itemCaseVersions[1].MicrotingSdkSiteId);
            Assert.AreEqual(itemCase.MicrotingSdkCaseId, itemCaseVersions[1].MicrotingSdkCaseId);
            Assert.AreEqual(itemCase.MicrotingSdkeFormId, itemCaseVersions[1].MicrotingSdkeFormId);
            Assert.AreEqual(itemCase.Status, itemCaseVersions[1].Status);
            Assert.AreEqual(itemCase.ItemId, itemCaseVersions[1].ItemId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, itemCaseVersions[1].WorkflowState);
            Assert.AreEqual(itemCase.Id, itemCaseVersions[1].ItemCaseId);
            Assert.AreEqual(2, itemCaseVersions[1].Version);
        }
    }
}