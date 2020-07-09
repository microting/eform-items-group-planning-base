namespace Microting.ItemsGroupPlanningBase.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddingMoreEnabledFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BuildYearEnabled",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ItemNumberEnabled",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LocationCodeEnabled",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TypeEnabled",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BuildYearEnabled",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ItemNumberEnabled",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LocationCodeEnabled",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TypeEnabled",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildYearEnabled",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "ItemNumberEnabled",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "LocationCodeEnabled",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "TypeEnabled",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "BuildYearEnabled",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "ItemNumberEnabled",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "LocationCodeEnabled",
                table: "ItemLists");

            migrationBuilder.DropColumn(
                name: "TypeEnabled",
                table: "ItemLists");
        }
    }
}
