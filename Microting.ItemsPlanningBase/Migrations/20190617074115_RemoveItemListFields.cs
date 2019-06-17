using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class RemoveItemListFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecutedCount",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "MaxExecutedCount",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "ExecutedCount",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "MaxExecutedCount",
                table: "ItemLists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExecutedCount",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxExecutedCount",
                table: "ItemListVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExecutedCount",
                table: "ItemLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxExecutedCount",
                table: "ItemLists",
                nullable: true);
        }
    }
}
