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
using Microsoft.EntityFrameworkCore;
using Microting.ItemsPlanningBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace Microting.ItemsPlanningBase.Tests
{
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
                RelatedeFormId = 35,
                RelatedeFormName = Guid.NewGuid().ToString(),
                RepeatedType = 42
            };

            // Act
            await itemList.Save(DbContext);

            List<ItemList> itemLists = DbContext.ItemLists.AsNoTracking().ToList();
            List<ItemListVersion> itemListVersions = DbContext.ItemListVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, itemLists.Count);
            Assert.AreEqual(1, itemListVersions.Count);
            Assert.AreEqual(itemList.Name, itemLists[0].Name);
            Assert.AreEqual(itemList.Description, itemLists[0].Description);
            Assert.AreEqual(itemList.Enabled, itemLists[0].Enabled);
            Assert.AreEqual(itemList.RepeatedType, itemLists[0].RepeatedType);
            Assert.AreEqual(itemList.RelatedeFormId, itemLists[0].RelatedeFormId);
            Assert.AreEqual(itemList.RelatedeFormName, itemLists[0].RelatedeFormName);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemLists[0].WorkflowState);
            Assert.AreEqual(itemList.Id, itemLists[0].Id);
            Assert.AreEqual(1, itemLists[0].Version);
                        
            Assert.AreEqual(itemList.Name, itemListVersions[0].Name);
            Assert.AreEqual(itemList.Description, itemListVersions[0].Description);
            Assert.AreEqual(itemList.Enabled, itemListVersions[0].Enabled);
            Assert.AreEqual(itemList.RepeatedType, itemListVersions[0].RepeatedType);
            Assert.AreEqual(itemList.RelatedeFormId, itemListVersions[0].RelatedeFormId);
            Assert.AreEqual(itemList.RelatedeFormName, itemListVersions[0].RelatedeFormName);
            Assert.AreEqual(itemList.Id, itemListVersions[0].ItemListId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemListVersions[0].WorkflowState);
            Assert.AreEqual(itemList.Id, itemListVersions[0].Id);
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
                RelatedeFormId = 35,
                RelatedeFormName = Guid.NewGuid().ToString(),
                RepeatedType = 42
            };
            await itemList.Save(DbContext);

            // Act
            itemList = await DbContext.ItemLists.AsNoTracking().FirstOrDefaultAsync();

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
            Assert.AreEqual(itemList.RepeatedType, itemLists[0].RepeatedType);
            Assert.AreEqual(itemList.RelatedeFormId, itemLists[0].RelatedeFormId);
            Assert.AreEqual(itemList.RelatedeFormName, itemLists[0].RelatedeFormName);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemLists[0].WorkflowState);
            Assert.AreEqual(itemList.Id, itemLists[0].Id);
            Assert.AreEqual(2, itemLists[0].Version);
                        
            Assert.AreEqual(oldName, itemListVersions[0].Name);
            Assert.AreEqual(itemList.Description, itemListVersions[0].Description);
            Assert.AreEqual(itemList.Enabled, itemListVersions[0].Enabled);
            Assert.AreEqual(itemList.RepeatedType, itemListVersions[0].RepeatedType);
            Assert.AreEqual(itemList.RelatedeFormId, itemListVersions[0].RelatedeFormId);
            Assert.AreEqual(itemList.RelatedeFormName, itemListVersions[0].RelatedeFormName);
            Assert.AreEqual(itemList.Id, itemListVersions[0].ItemListId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemListVersions[0].WorkflowState);
            Assert.AreEqual(1, itemListVersions[0].Version);
            
            Assert.AreEqual("hello", itemListVersions[1].Name);
            Assert.AreEqual(itemList.Description, itemListVersions[1].Description);
            Assert.AreEqual(itemList.Enabled, itemListVersions[1].Enabled);
            Assert.AreEqual(itemList.RepeatedType, itemListVersions[1].RepeatedType);
            Assert.AreEqual(itemList.RelatedeFormId, itemListVersions[1].RelatedeFormId);
            Assert.AreEqual(itemList.RelatedeFormName, itemListVersions[1].RelatedeFormName);
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
                RelatedeFormId = 35,
                RelatedeFormName = Guid.NewGuid().ToString(),
                RepeatedType = 42
            };
            await itemList.Save(DbContext);

            // Act
            itemList = await DbContext.ItemLists.AsNoTracking().FirstOrDefaultAsync();

            await itemList.Delete(DbContext);

            List<ItemList> itemLists = DbContext.ItemLists.AsNoTracking().ToList();
            List<ItemListVersion> itemListVersions = DbContext.ItemListVersions.AsNoTracking().ToList();
            
            // Assert
            Assert.AreEqual(1, itemLists.Count);
            Assert.AreEqual(2, itemListVersions.Count);
            Assert.AreEqual(itemList.Name, itemLists[0].Name);
            Assert.AreEqual(itemList.Description, itemLists[0].Description);
            Assert.AreEqual(itemList.Enabled, itemLists[0].Enabled);
            Assert.AreEqual(itemList.RepeatedType, itemLists[0].RepeatedType);
            Assert.AreEqual(itemList.RelatedeFormId, itemLists[0].RelatedeFormId);
            Assert.AreEqual(itemList.RelatedeFormName, itemLists[0].RelatedeFormName);
            Assert.AreEqual(Constants.WorkflowStates.Removed, itemLists[0].WorkflowState);
            Assert.AreEqual(itemList.Id, itemLists[0].Id);
            Assert.AreEqual(2, itemLists[0].Version);
                        
            Assert.AreEqual(itemList.Name, itemListVersions[0].Name);
            Assert.AreEqual(itemList.Description, itemListVersions[0].Description);
            Assert.AreEqual(itemList.Enabled, itemListVersions[0].Enabled);
            Assert.AreEqual(itemList.RepeatedType, itemListVersions[0].RepeatedType);
            Assert.AreEqual(itemList.RelatedeFormId, itemListVersions[0].RelatedeFormId);
            Assert.AreEqual(itemList.RelatedeFormName, itemListVersions[0].RelatedeFormName);
            Assert.AreEqual(itemList.Id, itemListVersions[0].ItemListId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemListVersions[0].WorkflowState);
            Assert.AreEqual(1, itemListVersions[0].Version);
            
            Assert.AreEqual(itemList.Name, itemListVersions[1].Name);
            Assert.AreEqual(itemList.Description, itemListVersions[1].Description);
            Assert.AreEqual(itemList.Enabled, itemListVersions[1].Enabled);
            Assert.AreEqual(itemList.RepeatedType, itemListVersions[1].RepeatedType);
            Assert.AreEqual(itemList.RelatedeFormId, itemListVersions[1].RelatedeFormId);
            Assert.AreEqual(itemList.RelatedeFormName, itemListVersions[1].RelatedeFormName);
            Assert.AreEqual(itemList.Id, itemListVersions[1].ItemListId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, itemListVersions[1].WorkflowState);
            Assert.AreEqual(2, itemListVersions[1].Version);
        }
    }
}