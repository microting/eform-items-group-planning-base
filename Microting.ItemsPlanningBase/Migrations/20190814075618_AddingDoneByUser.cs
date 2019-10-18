using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddingDoneByUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoneByUserId",
                table: "ItemCaseVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DoneByUserName",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoneByUserId",
                table: "ItemCases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DoneByUserName",
                table: "ItemCases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoneByUserId",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "DoneByUserName",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "DoneByUserId",
                table: "ItemCases");

            migrationBuilder.DropColumn(
                name: "DoneByUserName",
                table: "ItemCases");
        }
    }
}
