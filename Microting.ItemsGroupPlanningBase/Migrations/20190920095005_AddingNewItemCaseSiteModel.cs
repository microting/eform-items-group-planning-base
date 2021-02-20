namespace Microting.ItemsGroupPlanningBase.Migrations
{
    using System;
    using Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddingNewItemCaseSiteModel : Migration
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
                name: "ItemCaseSites",
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
                    FieldStatus = table.Column<string>(nullable: true),
                    MicrotingSdkCaseId = table.Column<int>(nullable: false),
                    MicrotingSdkCaseDoneAt = table.Column<DateTime>(nullable: true),
                    NumberOfImages = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    SdkFieldValue1 = table.Column<string>(nullable: true),
                    SdkFieldValue2 = table.Column<string>(nullable: true),
                    SdkFieldValue3 = table.Column<string>(nullable: true),
                    SdkFieldValue4 = table.Column<string>(nullable: true),
                    SdkFieldValue5 = table.Column<string>(nullable: true),
                    SdkFieldValue6 = table.Column<string>(nullable: true),
                    SdkFieldValue7 = table.Column<string>(nullable: true),
                    SdkFieldValue8 = table.Column<string>(nullable: true),
                    SdkFieldValue9 = table.Column<string>(nullable: true),
                    SdkFieldValue10 = table.Column<string>(nullable: true),
                    DoneByUserId = table.Column<int>(nullable: false),
                    DoneByUserName = table.Column<string>(nullable: true),
                    ItemCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCaseSites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCaseSiteVersions",
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
                    FieldStatus = table.Column<string>(nullable: true),
                    MicrotingSdkCaseId = table.Column<int>(nullable: false),
                    MicrotingSdkCaseDoneAt = table.Column<DateTime>(nullable: true),
                    NumberOfImages = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    ItemCaseSiteId = table.Column<int>(nullable: false),
                    SdkFieldValue1 = table.Column<string>(nullable: true),
                    SdkFieldValue2 = table.Column<string>(nullable: true),
                    SdkFieldValue3 = table.Column<string>(nullable: true),
                    SdkFieldValue4 = table.Column<string>(nullable: true),
                    SdkFieldValue5 = table.Column<string>(nullable: true),
                    SdkFieldValue6 = table.Column<string>(nullable: true),
                    SdkFieldValue7 = table.Column<string>(nullable: true),
                    SdkFieldValue8 = table.Column<string>(nullable: true),
                    SdkFieldValue9 = table.Column<string>(nullable: true),
                    SdkFieldValue10 = table.Column<string>(nullable: true),
                    DoneByUserId = table.Column<int>(nullable: false),
                    DoneByUserName = table.Column<string>(nullable: true),
                    ItemCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCaseSiteVersions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCaseSites");

            migrationBuilder.DropTable(
                name: "ItemCaseSiteVersions");
        }
    }
}
