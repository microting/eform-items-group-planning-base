using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.ItemsPlanningBase.Migrations
{
    public partial class AddingTheFieldStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldStatus",
                table: "ItemCaseVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldStatus",
                table: "ItemCases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldStatus",
                table: "ItemCaseVersions");

            migrationBuilder.DropColumn(
                name: "FieldStatus",
                table: "ItemCases");
        }
    }
}
