using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddingCommentAndLocationToItemCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ItemCases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ItemCases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ItemCases");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ItemCases");
        }
    }
}
