namespace Microting.ItemsGroupPlanningBase.Migrations
{
    using System;
    using Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddingUploadedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Setup for SQL Server Provider

            var autoIDGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIDGenStrategyValue = SqlServerValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIDGenStrategy = "MySql:ValueGenerationStrategy";
                autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.AddColumn<DateTime>(
                name: "MicrotingSdkCaseDoneAt",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MicrotingSdkCaseDoneAt",
                table: "ItemCases",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UploadedDatas",
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
                    ItemCaseId = table.Column<int>(nullable: false),
                    Checksum = table.Column<string>(maxLength: 255, nullable: true),
                    Extension = table.Column<string>(maxLength: 255, nullable: true),
                    CurrentFile = table.Column<string>(maxLength: 255, nullable: true),
                    UploaderType = table.Column<string>(maxLength: 255, nullable: true),
                    FileLocation = table.Column<string>(maxLength: 255, nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedDataVersions",
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
                    ItemCaseId = table.Column<int>(nullable: false),
                    Checksum = table.Column<string>(maxLength: 255, nullable: true),
                    Extension = table.Column<string>(maxLength: 255, nullable: true),
                    CurrentFile = table.Column<string>(maxLength: 255, nullable: true),
                    UploaderType = table.Column<string>(maxLength: 255, nullable: true),
                    FileLocation = table.Column<string>(maxLength: 255, nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    UploadedDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDataVersions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UploadedDatas");

            migrationBuilder.DropTable(
                name: "UploadedDataVersions");

            migrationBuilder.DropColumn(
                name: "MicrotingSdkCaseDoneAt",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "MicrotingSdkCaseDoneAt",
                table: "ItemCases");
        }
    }
}
