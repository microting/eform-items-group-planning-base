using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddingNewAttributesToItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuildYear",
                table: "ItemVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ItemVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildYear",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildYear",
                table: "ItemVersions");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ItemVersions");

            migrationBuilder.DropColumn(
                name: "BuildYear",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Items");
        }
    }
}
