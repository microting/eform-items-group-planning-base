using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddingDeployedAtEnabled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeployedAtEnabled",
                table: "ItemListVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeployedAtEnabled",
                table: "ItemLists",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeployedAtEnabled",
                table: "ItemListVersions");

            migrationBuilder.DropColumn(
                name: "DeployedAtEnabled",
                table: "ItemLists");
        }
    }
}
