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

namespace Microting.ItemsGroupPlanningBase.Migrations
{
    using System;
    using Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Setup for SQL Server Provider

            var autoIDGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIDGenStrategy = "MySql:ValueGenerationStrategy";
                autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.CreateTable(
                name: "ItemCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    MicrotingSdkSiteId = table.Column<int>(nullable: false),
                    MicrotingSdkeFormId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MicrotingSdkCaseId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCaseVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    MicrotingSdkSiteId = table.Column<int>(nullable: false),
                    MicrotingSdkeFormId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    MicrotingSdkCaseId = table.Column<int>(nullable: false),
                    ItemCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCaseVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    RelatedeFormId = table.Column<int>(nullable: false),
                    RelatedeFormName = table.Column<string>(nullable: true),
                    RepeatedType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemListVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    RelatedeFormId = table.Column<int>(nullable: false),
                    RelatedeFormName = table.Column<string>(nullable: true),
                    RepeatedType = table.Column<int>(nullable: false),
                    ItemList = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemListVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Sku = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    RepeatType = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginConfigurationValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginConfigurationValueVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValueVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Sku = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    RepeatType = table.Column<string>(nullable: true),
                    ItemListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemLists_ItemListId",
                        column: x => x.ItemListId,
                        principalTable: "ItemLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemListId",
                table: "Items",
                column: "ItemListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCases");

            migrationBuilder.DropTable(
                name: "ItemCaseVersions");

            migrationBuilder.DropTable(
                name: "ItemListVersions");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemVersions");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValues");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValueVersions");

            migrationBuilder.DropTable(
                name: "ItemLists");
        }
    }
}
