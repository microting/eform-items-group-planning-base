using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddTemplateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "ItemVersions");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "ItemLists",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "ItemLists");

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "ItemVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "Items",
                nullable: false,
                defaultValue: 0);
        }
    }
}
